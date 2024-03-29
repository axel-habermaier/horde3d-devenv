using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Infrastructure.Core.Communication;
using System.Diagnostics;
using System.Threading;
using Infrastructure.Core.Messages;
using Horde3DNET;
using Server.NativeInterop;
using Infrastructure.Core.Resources;
using Infrastructure.Core.SceneNodes;
using Infrastructure.Core.Profiling;
using System.ServiceModel.Description;

namespace Infrastructure.Core.Server
{
	public class Horde3DDebugger : Singleton<Horde3DDebugger>
	{
		/// <summary>
		/// Gets the ProxyHandler that manages the current Horde3D proxy.
		/// </summary>
		public IProxyHandler ProxyHandler { get; private set; }

		/// <summary>
		/// The log message handler.
		/// </summary>
		private Horde3DMessagesHandler Horde3DMessagesHandler { get; set; }

		/// <summary>
		/// The server's configuration settings.
		/// </summary>
		public ServerConfiguration Configuration { get; set; }

		/// <summary>
		/// The render watcher.
		/// </summary>
		private Horde3DStateWatcher StateWatcher { get; set; }

		/// <summary>
		/// The strategy that is responsible for suspending and resuming the application.
		/// </summary>
		private SuspendApplicationStrategy SuspendStrategy { get; set; }

		/// <summary>
		/// Gets the time when the application was started.
		/// </summary>
		internal DateTime StartTime;

		/// <summary>
		/// Gets the synchronization context of the thread that runs Horde3D.
		/// </summary>
		public Horde3DSynchronizationContext Horde3DContext { get; private set; }

		/// <summary>
		/// The application's current state.
		/// </summary>
		internal ApplicationState ApplicationState { get; private set; }

		public void Initialize(IProxyHandler proxyHandler)
		{
			try
			{
				StateWatcher = new Horde3DStateWatcher();
				ApplicationState = ApplicationState.Running;

				StartTime = DateTime.Now;
				this.ProxyHandler = proxyHandler;

				Configuration = XmlSerializer<ServerConfiguration>.Deserialize(Infrastructure.Core.Properties.Settings.Default.ServerSettingsFileName);

				Interop.LoadDlls(Configuration.OriginalHorde3DDllPath, Configuration.OriginalHorde3DUtilsDllPath);

				if (Configuration.LaunchDebugger)
					Debugger.Launch();

				Horde3DContext = new Horde3DSynchronizationContext();

#if DEBUG
				if (String.IsNullOrEmpty(Thread.CurrentThread.Name))
					Thread.CurrentThread.Name = "Horde3D Thread";
#endif

				Horde3DCall.Init += OnInit;
				Horde3DCall.Release += OnRelease;
				Horde3DCall.BeforeFunctionCalled += e => Horde3DContext.Execute();

				this.Horde3DMessagesHandler = new Horde3DMessagesHandler();

				var host = new ServiceHost(typeof(DebuggerService));

				var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);

				binding.MaxReceivedMessageSize = Int32.MaxValue;
				binding.MaxBufferSize = Int32.MaxValue;
				binding.ReaderQuotas.MaxArrayLength = Int32.MaxValue;
				binding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;
				binding.ReaderQuotas.MaxBytesPerRead = Int32.MaxValue;

				host.AddServiceEndpoint(typeof(IDebuggerService), binding, Configuration.CommunicationAddress);

				host.Open();

				if (Horde3DCall.Horde3DVersion != Horde3D.getVersionString())
				{
					throw new InvalidProgramException("Incompatible Horde3D.dll version loaded. Expected Horde3D version '" + Horde3DCall.Horde3DVersion
						+ "' but the dll has the version '" + Horde3DNET.Horde3D.getVersionString() + "'.");
				}
			}
			catch (Exception e)
			{
				Interop.ShowMessageBox(e.Message, "Debugging Error");
				Environment.Exit(2);
			}
		}

		internal bool Suspend()
		{
			if (ApplicationState != ApplicationState.Running || !DebuggerService.IsClientConnected)
				return false;

			ApplicationState = ApplicationState.Suspended;
			SuspendStrategy.Suspend();
			return true;
		}

		internal bool Resume()
		{
			if (ApplicationState != ApplicationState.Suspended || !DebuggerService.IsClientConnected)
				return false;

			ApplicationState = ApplicationState.Running;
			SuspendStrategy.Resume();
			return true;
		}

		private void SuspendRequested(object sender, EventArgs e)
		{
			if (Suspend())
				DebuggerService.OnSuspended();
		}

		private void ResumeRequested(object sender, EventArgs e)
		{
			if (Resume())
				DebuggerService.OnResumed();
		}

		private void ProfilingRequested(object sender, EventArgs e)
		{
			if (!FrameProfiler.Instance.Profiling)
				FrameProfiler.Instance.Profile();
		}

		private void OnInit(bool returnValue)
		{
			if (SuspendStrategy != null)
				return;

			SuspendStrategy = new SuspendApplicationStrategy();
			SuspendStrategy.SuspendRequested += SuspendRequested;
			SuspendStrategy.ResumeRequested += ResumeRequested;
			SuspendStrategy.ProfilingRequested += ProfilingRequested;
		}

		private void OnRelease()
		{
			if (SuspendStrategy == null)
				return;

			SuspendStrategy.SuspendRequested -= SuspendRequested;
			SuspendStrategy.ResumeRequested -= ResumeRequested;
			SuspendStrategy.ProfilingRequested -= ProfilingRequested;
			SuspendStrategy.Dispose();
			SuspendStrategy = null;
		}
	}
}
