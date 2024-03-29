using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Infrastructure.Core.Messages;
using Infrastructure.Core.Communication;
using Infrastructure.Core.SceneNodes;
using Infrastructure.Core.Resources;
using System.ServiceModel.Description;

namespace Client.Models
{
	public class DebuggerServiceProxy
	{
		private Binding binding;
		private EndpointAddress remoteAddress;

		public DebuggerServiceProxy(IDebuggerServiceCallback callbackHandler, Binding binding, EndpointAddress remoteAddress)
		{
			this.binding = binding;
			this.remoteAddress = remoteAddress;

			this.CallbackProxy = callbackHandler;
		}

		#region Properties
		/// <summary>
		/// Object used for thread synchronization.
		/// </summary>
		private object lockObject = new object();

		private bool abortPendingConnectionAttempts = false;
		/// <summary>
		/// Gets or sets a value that indicates to the proxy whether to abort all pending connection attempts.
		/// </summary>
		private bool AbortPendingConnectionAttempts
		{
			get
			{
				lock (lockObject)
					return abortPendingConnectionAttempts;
			}
			set
			{
				lock (lockObject)
					abortPendingConnectionAttempts = value;
			}
		}

		private WcfClientProxy clientProxy = null;
		/// <summary>
		/// The WCF client proxy used to communicate with the server.
		/// </summary>
		private WcfClientProxy ClientProxy
		{
			get
			{
				lock (lockObject)
					return clientProxy;
			}
			set
			{
				lock (lockObject)
					clientProxy = value;
			}
		}

		/// <summary>
		/// The WCF client callback proxy used to receive notifications from the server.
		/// </summary>
		private IDebuggerServiceCallback CallbackProxy { get; set; }

		/// <summary>
		/// Indicates whether the connection to the server is opened and ready to use.
		/// </summary>
		public bool ConnectionOpen
		{
			get
			{
				lock (lockObject)
					return clientProxy != null && clientProxy.State == CommunicationState.Opened;
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Opens a connection to the server.
		/// </summary>
		public void OpenConnection()
		{
			Invoke(null);
		}

		/// <summary>
		/// Closes the connection to the server.
		/// </summary>
		public void Close()
		{
			DebuggerShell.Current.MessagesDispatcher.AddDebugSessionMessage("Closing connection to the server...");
			AbortPendingConnectionAttempts = true;

			if (!ConnectionOpen)
			{
				DebuggerShell.Current.MessagesDispatcher.AddSystemDebugMessage("The connection to the server has already been closed.");
				return;
			}

			try
			{
				ClientProxy.Close();
				DebuggerShell.Current.MessagesDispatcher.AddDebugSessionMessage("Connection closed.");
			}
			catch (TimeoutException)
			{
				DebuggerShell.Current.MessagesDispatcher.AddSystemDebugMessage("There was a timeout while trying to disconnect from the server.");
			}
			catch (CommunicationObjectFaultedException)
			{
				DebuggerShell.Current.MessagesDispatcher.AddSystemDebugMessage("The connection to the server was faulted and therefore already closed.");
			}
			catch (CommunicationException)
			{
				DebuggerShell.Current.MessagesDispatcher.AddSystemDebugMessage("The connection is already being closed by the server.");
			}
			finally
			{
				ClientProxy = null;
			}
		}

		private void InvokeService(Action<IDebuggerService> invoke)
		{
			if (invoke == null)
				return;

			try
			{
				invoke(ClientProxy);
			}
			catch (Exception e)
			{
				DebuggerShell.Current.MessagesDispatcher.AddSystemErrorMessage("There is a problem with the connection to the server: " + e.Message);
			}
		}

		/// <summary>
		/// Invokes the given method after a connection to the server has been established.
		/// </summary>
		/// <param name="invoke">A method to invoke after the connection has been established.</param>
		public void Invoke(Action<IDebuggerService> invoke)
		{
			new Thread(() =>
			{
				lock (lockObject)
				{
					if (ConnectionOpen)
					{
						InvokeService(invoke);
						return;
					}
				}

				while (!AbortPendingConnectionAttempts)
				{
					lock (lockObject)
					{
						if (AbortPendingConnectionAttempts)
							return;

						var proxy = new WcfClientProxy(CallbackProxy, binding, remoteAddress);

						if (proxy.State == CommunicationState.Opened)
							break;

						try
						{
							proxy.Open();

							ClientProxy = proxy;
							DebuggerShell.Current.MessagesDispatcher.AddDebugSessionMessage("Established the connection to the server.");

							ClientProxy.RegisterClient();
							DebuggerShell.Current.MessagesDispatcher.AddDebugSessionMessage("Registered callback channel on server.");

							InvokeService(invoke);
							return;
						}
						catch (TimeoutException)
						{
							DebuggerShell.Current.MessagesDispatcher.AddSystemDebugMessage("Connection attempt failed (timeout). Retrying...");
						}
						catch (EndpointNotFoundException)
						{
							DebuggerShell.Current.MessagesDispatcher.AddSystemDebugMessage("Connection attempt failed (the endpoint could not be found. The application might not yet be fully initialized). Retrying...");
						}
						catch (Exception e)
						{
							DebuggerShell.Current.MessagesDispatcher.AddMessage(new Infrastructure.Core.Messages.Message("Connection attempt failed. Reason: " + e.Message, MessageType.Error, DateTime.Now, MessageCategory.DebugSession));
						}
					}

					// Wait 150ms before retrying. Otherwise we would get spammed with "connection attempt failed" messages.
					Thread.Sleep(150);
				}

				DebuggerShell.Current.MessagesDispatcher.AddSystemDebugMessage("No connection established. Stopped trying.");
			}).Start();
		}
		#endregion

		#region Private WCF Implementations
		[DebuggerStepThrough]
		private class WcfClientProxy : DuplexClientBase<IDebuggerService>, IDebuggerService
		{
			public WcfClientProxy(object callbackContext, Binding binding, EndpointAddress remoteAddress)
				: base(callbackContext, binding, remoteAddress)
			{

			}

			#region Service Implementation
			/// <summary>
			/// Registers the client callback.
			/// </summary>
			public void RegisterClient()
			{
				VerifyThread();
				base.Channel.RegisterClient();
			}

			/// <summary>
			/// Suspends the execution of the application.
			/// </summary>
			public void Suspend()
			{
				VerifyThread();
				base.Channel.Suspend();
			}

			/// <summary>
			/// Resumes the execution of the application.
			/// </summary>
			public void Resume()
			{
				VerifyThread();
				base.Channel.Resume();
			}

			/// <summary>
			/// Profiles the application.
			/// </summary>
			public void Profile()
			{
				VerifyThread();
				base.Channel.Profile();
			}

			/// <summary>
			/// Asks the server to send the debug information using the callback contract.
			/// </summary>
			public void RequestDebugData()
			{
				VerifyThread();
				base.Channel.RequestDebugData();
			}

			/// <summary>
			/// Asks the server to profile a frame and send the information using the callback contract.
			/// </summary>
			public void RequestFrameProfilingData()
			{
				VerifyThread();
				base.Channel.RequestFrameProfilingData();
			}

			/// <summary>
			/// Copies the changes made to the given resource to the resource currently used by the application.
			/// </summary>
			/// <param name="resource">The resource that should be updated.</param>
			public void UpdateResource(EditableResource resource)
			{
				VerifyThread();
				base.Channel.UpdateResource(resource);
			}

			/// <summary>
			/// Gets the current data of the specified render target.
			/// </summary>
			/// <param name="pipelineResHandle">The render target's pipeline's resource handle.</param>
			/// <param name="renderTargetName">The render target's name.</param>
			/// <param name="colorBufferIndex">The color buffer index.</param>
			public byte[] GetRenderTargetData(int pipelineResHandle, string renderTargetName, int colorBufferIndex)
			{
				VerifyThread();
				return base.Channel.GetRenderTargetData(pipelineResHandle, renderTargetName, colorBufferIndex);
			}
			#endregion

			[Conditional("DEBUG")]
			private void VerifyThread()
			{
				Debug.Assert(Thread.CurrentThread.Name != "H3DDevEnv", "Service invoked on the main thread.");
			}
		}
		#endregion
	}
}
