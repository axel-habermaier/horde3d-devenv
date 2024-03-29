using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;

namespace Infrastructure.Core.Server
{
	/// <summary>
	/// A simple synchronization context implementation that ensures that all service methods are executed on the Horde3D thread.
	/// Both the Send and the Post method are invoking the given delegate asynchronously.
	/// </summary>
	public class Horde3DSynchronizationContext : SynchronizationContext
	{
		/// <summary>
		/// Contains all necessary information to run the given delegate.
		/// </summary>
		struct MethodExecution
		{
			/// <summary>
			/// The state that should be passed to the delegate.
			/// </summary>
			public object State { get; set; }

			/// <summary>
			/// The delegate that should be executed on the Horde3D thread.
			/// </summary>
			public SendOrPostCallback Method { get; set; }
		}

		/// <summary>
		/// A queue of pending method executions.
		/// </summary>
		Queue<MethodExecution> queue = new Queue<MethodExecution>();

		/// <summary>
		/// The Horde3D thread's thread id.
		/// </summary>
		int threadID = -1;

		/// <summary>
		/// Initializes a new synchronization context instance. The context must be created on the Horde3D thread.
		/// </summary>
		public Horde3DSynchronizationContext()
		{
			threadID = Thread.CurrentThread.ManagedThreadId;
		}

		/// <summary>
		/// Queues the given delegate and eventually invokes it on the Horde3D thread.
		/// </summary>
		/// <param name="d">The delegate that should be invoked on the Horde3D thread.</param>
		/// <param name="state">The state that should be passed to the delegate.</param>
		public override void Post(SendOrPostCallback d, object state)
		{
			lock (queue)
				queue.Enqueue(new MethodExecution { State = state, Method = d });
		}

		/// <summary>
		/// Queues the given delegate and eventually invokes it on the Horde3D thread. Note: This method is 
		/// implemented asynchronously and has the same effect as calling Post directly.
		/// </summary>
		/// <param name="d">The delegate that should be invoked on the Horde3D thread.</param>
		/// <param name="state">The state that should be passed to the delegate.</param>
		public override void Send(SendOrPostCallback d, object state)
		{
			Post(d, state);
		}

		/// <summary>
		/// Executes all pending delegates. This method must be called on the Horde3D thread.
		/// </summary>
		public void Execute()
		{
			if (Thread.CurrentThread.ManagedThreadId != threadID)
				throw new InvalidOperationException("Horde3DSynchronizationContext.Execute must be called on the thread the object was created on." +
					"The call was issued on the thread '" + Thread.CurrentThread.ManagedThreadId.ToString() + "' but the object was created on thread '" + threadID.ToString() + "'.");

			int queueCount = 0;
			lock (queue)
				queueCount = queue.Count;

			while (queueCount > 0)
			{
				MethodExecution execute;
				lock (queue)
				{
					execute = queue.Dequeue();
					queueCount = queue.Count;
				}

				execute.Method(execute.State);
			}
		}
	}

	/// <summary>
	/// This attribute forces the service to call all service methods on the Horde3D thread.
	/// </summary>
	class Horde3DThreadAffinityAttribute : Attribute, IContractBehavior
	{
		public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
		{
		}

		public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
		{
			dispatchRuntime.SynchronizationContext = Horde3DDebugger.Instance.Horde3DContext;
		}

		public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
		{
		}
	}
}
