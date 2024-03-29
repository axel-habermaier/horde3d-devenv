using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views;
using WeifenLuo.WinFormsUI.Docking;
using Infrastructure.UserInterface;
using Client.Commands;
using Infrastructure.UserInterface.WinForms;
using Client.Models;
using System.Collections.Specialized;
using System.IO;
using Client.Presenters.Resources;
using Client.Presenters.SceneNodes;


namespace Client.Presenters
{
	class ShellPresenter : DebuggerPresenter<ShellView>, IShellPresenter
	{
		public DockPanel DockPanel
		{
			get 
			{
				DockPanel panel = null;
				UpdateView(view => panel = view.DockPanel);
				return panel;
			}
		}

		protected override bool InitializeEvents()
		{
			UpdateView(view => view.ExitRequest += () => HandleCommand(new ExitCommand()));
			UpdateView(view => view.NewApplicationRequest += () => HandleCommand(new NewApplicationCommand()));
			UpdateView(view => view.CloseApplicationRequest += () => HandleCommand(new CloseApplicationCommand()));
			UpdateView(view => view.LoadApplicationRequest += () => HandleCommand(new LoadApplicationCommand()));
			UpdateView(view => view.SaveAllRequest += () => HandleCommand(new SaveCommand(true)));
			UpdateView(view => view.SaveRequest += () => HandleCommand(new SaveCommand(false)));
			UpdateView(view => view.ChangeApplicationSettingsRequest += () => Shell.RegisterPresenter(new ApplicationSettingsPresenter()));
			UpdateView(view => view.StartDebuggingRequest += () => HandleCommand(new StartApplicationCommand()));
			UpdateView(view => view.StopDebuggingRequest += () => HandleCommand(new StopApplicationCommand()));
			UpdateView(view => view.SuspendApplicationRequest += () => HandleCommand(new SuspendApplicationCommand()));
			UpdateView(view => view.ShowConsoleOutputRequest += () => Shell.RegisterPresenter(new ConsoleOutputPresenter()));
			UpdateView(view => view.ShowErrorListRequest += () => Shell.RegisterPresenter(new ErrorListPresenter()));
			UpdateView(view => view.ShowFunctionCallHistory += () => Shell.RegisterPresenter(new ProfilingPresenter()));
			UpdateView(view => view.LoadRecentApplicationRequest += app => HandleCommand(new LoadApplicationCommand(app)));
			UpdateView(view => view.ProfileFrameRequest += () => HandleCommand(new ProfileFrameCommand()));
			UpdateView(view => view.ShowResourcesExplorerRequest += () => Shell.RegisterPresenter(new ResourcesExplorerPresenter()));
			UpdateView(view => view.ShowSceneGraphExplorerRequest += () => Shell.RegisterPresenter(new SceneGraphExplorerPresenter()));
			UpdateView(view => view.UndoRequest += () => Shell.CommandDispatcher.Undo());
			UpdateView(view => view.RedoRequest += () => Shell.CommandDispatcher.Redo());
			UpdateView(view => view.AboutRequest += () => Shell.RegisterPresenter(new DebuggerPresenter<AboutView>()));
			UpdateView(view => view.DebugRenderTargetsRequest += () => Shell.RegisterPresenter(new RenderTargetsPresenter()));
			UpdateView(view => view.ShowStartPageRequest += () => Shell.RegisterPresenter(new StartPresenter()));
			UpdateView(view => view.CloseAllDocumentsRequest += () => Shell.CloseAllDocuments(null));

			if (Shell.State != ApplicationState.Unloaded)
				Shell.Application.NameChanged += OnNameChanged;

			Shell.ApplicationStateChanged += OnStateChanged;
			Shell.ApplicationChanged += OnApplicationChanged;
			Shell.CommandDispatcher.CanRedoChanged += CanRedoChanged;
			Shell.CommandDispatcher.CanUndoChanged += CanUndoChanged;

			return base.InitializeEvents();
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.State = DebuggerShell.Current.State);
			OnNameChanged(null, EventArgs.Empty);
			UpdateRecentApplications();

			return base.Initialize();
		}

		protected override void Release()
		{
			if (DebuggerShell.Current.State != ApplicationState.Unloaded)
				DebuggerShell.Current.Application.NameChanged -= OnNameChanged;

			DebuggerShell.Current.ApplicationStateChanged -= OnStateChanged;
			DebuggerShell.Current.ApplicationChanged -= OnApplicationChanged;
			Shell.CommandDispatcher.CanRedoChanged -= CanRedoChanged;
			Shell.CommandDispatcher.CanUndoChanged -= CanUndoChanged;
		}

		private void OnNameChanged(object sender, EventArgs e)
		{
			UpdateView(view => view.UpdateTitle(DebuggerShell.Current.Application == null ? null : DebuggerShell.Current.Application.Name));
			UpdateRecentApplications();
		}

		private void OnStateChanged(object sender, ApplicationStateChangedEventArgs e)
		{
			UpdateView(view => view.State = e.CurrentState);
		}

		private void OnApplicationChanged(object sender, ApplicationChangedEventArgs e)
		{
			if (e.PreviousApplication != null)
				e.PreviousApplication.NameChanged -= OnNameChanged;
			if (e.CurrentApplication != null)
				e.CurrentApplication.NameChanged += OnNameChanged;

			OnNameChanged(null, EventArgs.Empty);

			UpdateRecentApplications();
		}

		private void CanUndoChanged(object sender, EventArgs e)
		{
			UpdateView(view => view.EnableUndo = Shell.CommandDispatcher.CanUndo);
		}

		private void CanRedoChanged(object sender, EventArgs e)
		{
			UpdateView(view => view.EnableRedo = Shell.CommandDispatcher.CanRedo);
		}

		private void UpdateRecentApplications()
		{
			var applications = Properties.Settings.Default.RecentApplications;
			if (applications == null)
			{
				applications = new StringCollection();
				Properties.Settings.Default.RecentApplications = applications;
			}

			if (DebuggerShell.Current.Application != null && !String.IsNullOrEmpty(DebuggerShell.Current.Application.FilePath))
			{
				applications.Remove(DebuggerShell.Current.Application.FilePath);
				applications.Insert(0, DebuggerShell.Current.Application.FilePath);
			}

			// Check if all recent application files still exist.
			var removeFiles = new StringCollection();
			foreach (var app in applications)
				if (!File.Exists(app))
					removeFiles.Add(app);

			foreach (var app in removeFiles)
				applications.Remove(app);

			UpdateView(view => view.RecentApplications = applications);

			Properties.Settings.Default.Save();
		}
	}
}
