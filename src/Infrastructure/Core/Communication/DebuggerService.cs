using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;
using Infrastructure.Core.Server;
using System.Threading;
using Infrastructure.Core.Messages;
using Infrastructure.Core.Profiling;
using Infrastructure.Core.Misc;
using Infrastructure.Core.SceneNodes;
using Infrastructure.Core.Resources;
using Server.NativeInterop;
using System.IO;
using System.Drawing;

namespace Infrastructure.Core.Communication
{
	[ServiceBehavior(
		InstanceContextMode = InstanceContextMode.Single,
		ConcurrencyMode = ConcurrencyMode.Reentrant,
		UseSynchronizationContext = true,
		IncludeExceptionDetailInFaults = true)]
	[Horde3DThreadAffinity]
	[DeliveryRequirements(RequireOrderedDelivery = true)]
	internal class DebuggerService : IDebuggerService
	{
		#region Callbacks
		/// <summary>
		/// The callback channel to the client.
		/// </summary>
		private static IDebuggerServiceCallback callback = null;

		/// <summary>
		/// Object used for thread synchronization.
		/// </summary>
		private static object lockObject = new object();

		/// <summary>
		/// Indicates whether the client is currently connected.
		/// </summary>
		public static bool IsClientConnected
		{
			get
			{
				lock (lockObject)
					return callback != null;
			}
		}

		/// <summary>
		/// Sends the given function calls to the client.
		/// </summary>
		/// <param name="functionCalls">The function call objects that should be sent.</param>
		public static void SendFunctionCalls(IEnumerable<FunctionCall> functionCalls)
		{
			InvokeCallback(c => functionCalls.Foreach(f => c.AddFunctionCall(f)));
		}

		/// <summary>
		/// Sends the given scene nodes to the client.
		/// </summary>
		/// <param name="sceneNodes">The scene nodes that should be sent.</param>
		public static void SendSceneNodes(IEnumerable<SceneNode> sceneNodes)
		{
			InvokeCallback(c => sceneNodes.Foreach(s => c.AddSceneNode(s)));
		}

		/// <summary>
		/// Sends the given resources to the client.
		/// </summary>
		/// <param name="resources">The resources that should be sent.</param>
		public static void SendResources(IEnumerable<Resource> resources)
		{
			InvokeCallback(c => resources.Foreach(r => c.AddResource(r)));
		}

		/// <summary>
		/// Sends the given message to the client.
		/// </summary>
		/// <param name="message">The message that should be sent.</param>
		public static void SendMessage(Horde3DMessage message)
		{
			InvokeCallback(c => c.OnMessageGenerated(message));
		}

		/// <summary>
		/// Informs the client that the application was suspended.
		/// </summary>
		internal static void OnSuspended()
		{
			InvokeCallback(c => c.OnSuspended());
		}

		/// <summary>
		/// Informs the client that the application was resumed.
		/// </summary>
		internal static void OnResumed()
		{
			InvokeCallback(c => c.OnResumed());
		}

		/// <summary>
		/// Informs the client that the application was profiled.
		/// </summary>
		internal static void OnProfiled()
		{
			InvokeCallback(c => c.OnProfiled());
		}

		private static void InvokeCallback(Action<IDebuggerServiceCallback> action)
		{
			ThreadPool.QueueUserWorkItem(o =>
			{
				Debug.Assert(Thread.CurrentThread.Name != "Horde3D Thread", "This method must not be called on the 'Horde3D Thread'.");
				while (true)
				{
					try
					{
						IDebuggerServiceCallback c = null;
						lock (lockObject)
							c = callback;

						if (c != null)
						{
							action(c);
							return;
						}
					}
					catch (Exception e)
					{
						Debug.WriteLine("Could not invoke callback: " + e.Message);
					}
					Thread.Sleep(50);
				}
			});
		}
		#endregion

		#region Service Implementation
		/// <summary>
		/// Registers the client callback and raises the client registered event.
		/// </summary>
		public void RegisterClient()
		{
			Debug.Assert(Thread.CurrentThread.Name == "Horde3D Thread", "This method must be called on the 'Horde3D Thread'.");
			lock (lockObject)
				callback = OperationContext.Current.GetCallbackChannel<IDebuggerServiceCallback>();
		}

		/// <summary>
		/// Suspends the execution of the application.
		/// </summary>
		public void Suspend()
		{
			Debug.Assert(Thread.CurrentThread.Name == "Horde3D Thread", "This method must be called on the 'Horde3D Thread'.");

			if (Horde3DDebugger.Instance.ApplicationState != ApplicationState.Running)
				return;

			if (Horde3DDebugger.Instance.Suspend())
				OnSuspended();
		}

		/// <summary>
		/// Resumes the execution of the application.
		/// </summary>
		public void Resume()
		{
			Debug.Assert(Thread.CurrentThread.Name == "Horde3D Thread", "This method must be called on the 'Horde3D Thread'.");

			if (Horde3DDebugger.Instance.ApplicationState != ApplicationState.Suspended)
				return;

			if (Horde3DDebugger.Instance.Resume())
				OnResumed();
		}

		/// <summary>
		/// Profiles the application.
		/// </summary>
		public void Profile()
		{
			Debug.Assert(Thread.CurrentThread.Name == "Horde3D Thread", "This method must be called on the 'Horde3D Thread'.");

			if (!FrameProfiler.Instance.Profiling)
				FrameProfiler.Instance.Profile();
		}

		/// <summary>
		/// Asks the server to send the debug information using the callback contract.
		/// </summary>
		public void RequestDebugData()
		{
			Debug.Assert(Thread.CurrentThread.Name == "Horde3D Thread", "This method must be called on the 'Horde3D Thread'.");

			if (Horde3DDebugger.Instance.ApplicationState != ApplicationState.Suspended)
				return;

			var sceneNodes = SceneGraph.GetSceneGraphFromHorde3D();
			var resources = ResourceGraph.GetResourceGraphFromHorde3D();

			SendSceneNodes(sceneNodes);
			SendResources(resources);
		}

		/// <summary>
		/// Asks the server to profile a frame and send the information using the callback contract.
		/// </summary>
		public void RequestFrameProfilingData()
		{
			Debug.Assert(Thread.CurrentThread.Name == "Horde3D Thread", "This method must be called on the 'Horde3D Thread'.");

			SendFunctionCalls(Horde3DCall.FunctionCalls);
		}

		/// <summary>
		/// Copies the changes made to the given resource to the resource currently used by the application.
		/// </summary>
		/// <param name="resource">The resource that should be updated.</param>
		public void UpdateResource(EditableResource resource)
		{
			Debug.Assert(Thread.CurrentThread.Name == "Horde3D Thread", "This method must be called on the 'Horde3D Thread'.");

			try
			{
				resource.UpdateHorde3D();
			}
			catch (InvalidOperationException e)
			{
				throw new FaultException<InvalidOperationException>(e);
			}
		}

		/// <summary>
		/// Gets the current data of the specified render target.
		/// </summary>
		/// <param name="pipelineResHandle">The render target's pipeline's resource handle.</param>
		/// <param name="renderTargetName">The render target's name.</param>
		/// <param name="colorBufferIndex">The color buffer index.</param>
		public byte[] GetRenderTargetData(int pipelineResHandle, string renderTargetName, int colorBufferIndex)
		{
			Debug.Assert(Thread.CurrentThread.Name == "Horde3D Thread", "This method must be called on the 'Horde3D Thread'.");

			var data = Interop.GetRenderTargetData(pipelineResHandle, renderTargetName, colorBufferIndex);
			using (var writer = new MemoryStream())
			{
				data.Save(writer, System.Drawing.Imaging.ImageFormat.Bmp);
				data.Dispose();

				return writer.ToArray();
			}
		}
		#endregion
	}
}
