using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views;
using Client.Models;
using Client.Commands;

namespace Client.Presenters
{
	class ProfilingPresenter : DebuggerPresenter<ProfilingView>
	{
		EventHandler<ProfilingDataChangedEventArgs> profilingDataChangedDelegate;
		ApplicationStateChangedHandler applicationStateChangedDelegate = null;

		public ProfilingPresenter()
		{
			profilingDataChangedDelegate = new EventHandler<ProfilingDataChangedEventArgs>(OnProfilingDataChanged);
			applicationStateChangedDelegate = new ApplicationStateChangedHandler(OnApplicationStateChanged);
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.ProfilingData = Shell.ProfilingDataManager.ProfilingData);
			UpdateView(view => view.State = Shell.State);

			return base.Initialize();
		}

		protected override bool InitializeEvents()
		{
			Shell.ProfilingDataManager.ProfilingDataChanged += profilingDataChangedDelegate;
			UpdateView(view => view.ProfileRequest += () => HandleCommand(new ProfileFrameCommand()));
			Shell.ApplicationStateChanged += applicationStateChangedDelegate;

			return base.InitializeEvents();
		}

		protected override void Release()
		{
			Shell.ProfilingDataManager.ProfilingDataChanged -= profilingDataChangedDelegate;
			Shell.ApplicationStateChanged -= applicationStateChangedDelegate;

			base.Release();
		}

		private void OnProfilingDataChanged(object sender, ProfilingDataChangedEventArgs e)
		{
			Shell.RunSync(() => UpdateView(view => view.ProfilingData = e.FunctionCalls));
		}

		private void OnApplicationStateChanged(object sender, ApplicationStateChangedEventArgs e)
		{
			UpdateView(view => view.State = e.CurrentState);
		}
	}
}
