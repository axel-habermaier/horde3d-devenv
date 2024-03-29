using System;
using System.Linq;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Infrastructure.UserInterface.WinForms.Commands;
using System.Windows.Forms;
using System.Threading;

namespace Infrastructure.UserInterface.WinForms
{
	/// <summary>
	/// Basic Shell implementation.
	/// </summary>
	/// <typeparam name="TShell">The shell's type.</typeparam>
	/// <typeparam name="TPresenter">The shell presenter's type.</typeparam>
	public abstract class Shell<TShell>
		where TShell : Shell<TShell>
	{
		/// <summary>
		/// Gets all active presenters.
		/// </summary>
		protected internal Dictionary<string, Presenter<TShell>> Presenters { get; private set; }

		/// <summary>
		/// Gets the currently running debugger shell instance.
		/// </summary>
		public static TShell Current { get; private set; }

		/// <summary>
		/// Gets a read-only list of all currently registered presenters.
		/// </summary>
		protected ReadOnlyCollection<Presenter<TShell>> RegisteredPresenters
		{
			get { return (from p in Presenters select p.Value).ToList().AsReadOnly(); }
		}

		/// <summary>
		/// The command dispatcher instance that handles the shell's commands.
		/// </summary>
		public CommandDispatcher<TShell> CommandDispatcher { get; private set; }

		/// <summary>
		/// The saveable content manager that manages the shell's saveable content views.
		/// </summary>
		internal SaveableContentManager SaveableContentManager { get; private set; }

		/// <summary>
		/// Raised when content has been saved.
		/// </summary>
		public event ContentSavedHandler ContentSaved
		{
			add { SaveableContentManager.ContentSaved += value; }
			remove { SaveableContentManager.ContentSaved -= value; }
		}

		/// <summary>
		/// Gets the Gui's synchronization context.
		/// </summary>
		internal protected SynchronizationContext SyncContext { get; set; }

		/// <summary>
		/// Posts the given method on the GUI thread and returns immediately.
		/// </summary>
		/// <param name="func">The method to run on the GUI thread.</param>
		public void RunSync(Action func)
		{
			Debug.Assert(SyncContext != null, "Synchronization context expected.");
			if (SyncContext == SynchronizationContext.Current)
				func();
			else
				SyncContext.Post(o => func(), null);
		}

		/// <summary>
		/// Runs the given method on the GUI thread and returns after the method has returned.
		/// </summary>
		/// <param name="func">The method to run on the GUI thread.</param>
		public void RunSyncWait(Action func)
		{
			Debug.Assert(SyncContext != null, "Synchronization context expected.");
			if (SyncContext == SynchronizationContext.Current)
				func();
			else
				SyncContext.Send(o => func(), null);
		}

		/// <summary>
		/// Initializes a new shell instance.
		/// </summary>
		public Shell()
		{
			if (Current != null)
				throw new InvalidOperationException("Only one Shell instance per AppDomain allowed.");

			Current = this as TShell;
			CommandDispatcher = new CommandDispatcher<TShell>();
			Presenters = new Dictionary<string, Presenter<TShell>>();
			SaveableContentManager = new SaveableContentManager();

			if (SynchronizationContext.Current == null)
				SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());

			SyncContext = SynchronizationContext.Current;
			Debug.Assert(SyncContext != null, "Could not retrieve the Gui's synchronization context.");
		}

		/// <summary>
		/// Searches for the presenter that belongs to the view.
		/// </summary>
		/// <param name="view">The view for which to return the presenter.</param>
		/// <returns>Returns the view's presenter or null if the presenter is not found.</returns>
		internal Presenter<TShell> FindPresenter(IView view)
		{
			if (view == null)
				return null;

			return (from p in RegisteredPresenters where p.IView == view select p).SingleOrDefault();
		}

		/// <summary>
		/// Registers and shows the given presenter.
		/// </summary>
		/// <param name="presenter">The presenter that should be registered.</param>
		/// <returns>Returns true if the presenter was registered, false if it has already been registered.</returns>
		public bool RegisterPresenter(Presenter<TShell> presenter)
		{
			return RegisterPresenter(presenter, true);
		}

		/// <summary>
		/// Registers the given presenter. If show is true, the presenter is immediately shown.
		/// </summary>
		/// <param name="presenter">The presenter that should be registered.</param>
		/// <param name="show">Indicates whether the presenter should be immediately shown.</param>
		/// <returns>Returns true if the presenter was registered, false if it has already been registered.</returns>
		public bool RegisterPresenter(Presenter<TShell> presenter, bool show)
		{
			if (presenter == null)
				throw new ArgumentNullException("presenter");

			Presenter<TShell> existingPresenter = null;
			if (Presenters.TryGetValue(presenter.Name, out existingPresenter))
			{
				Focus(existingPresenter);
				return false;
			}

			if (presenter.Initialize(this as TShell))
			{
				Presenters.Add(presenter.Name, presenter);

				if (show)
					Show(presenter);

				return true;
			}

			return false;
		}

		/// <summary>
		/// Unregisters the given presenter.
		/// </summary>
		/// <param name="presenter">The presenter that should be unregistered.</param>
		/// <returns>Returns true if the presenter was removed, false if it hasn't been registered.</returns>
		public bool UnregisterPresenter(Presenter<TShell> presenter)
		{
			if (presenter == null)
				throw new ArgumentNullException("presenter");

			if (Presenters.ContainsKey(presenter.Name))
			{
				CommandDispatcher.RemovePresenterCommands(presenter);
				Remove(presenter);
				presenter.Uninitialize();
				Presenters.Remove(presenter.Name);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Shows the given presenter's view on the shell.
		/// </summary>
		/// <param name="presenter">The given presenter's view will be shown on the shell. 
		/// The presenter must already be registered on the shell.</param>
		public void Show(Presenter<TShell> presenter)
		{
			Show(presenter.IView);
		}

		/// <summary>
		/// Brings the given presenter's view into focus.
		/// </summary>
		/// <param name="presenter">The given presenter's view will be shown on the shell. 
		/// The presenter must already be registered on the shell.</param>
		public void Focus(Presenter<TShell> presenter)
		{
			Focus(presenter.IView);
		}

		/// <summary>
		/// Removes the given presenter's view from the shell.
		/// </summary>
		/// <param name="presenter">The given presenter's view will be shown on the shell. 
		/// The presenter must already be registered on the shell.</param>
		public void Remove(Presenter<TShell> presenter)
		{
			Remove(presenter.IView);
		}

		/// <summary>
		/// Depending on the saveAll parameter, all open and modified documents or the currently focused document are saved.
		/// </summary>
		/// <param name="saveAll">Indicates whether all or just the currently focused document should be saved.</param>
		/// <returns>Indicates whether the saving process has been completed successfully.</returns>
		public abstract bool SaveDocuments(bool saveAll);

		/// <summary>
		/// Shows the given view on the shell.
		/// </summary>
		/// <param name="view">The view that should be shown.</param>
		protected abstract void Show(IView view);

		/// <summary>
		/// Brings the given view into focus.
		/// </summary>
		/// <param name="view">The view that should be brought into focus.</param>
		protected abstract void Focus(IView view);

		/// <summary>
		/// Removes the given view from the shell.
		/// </summary>
		/// <param name="view">The view that should be removed.</param>
		protected abstract void Remove(IView view);
	}

	/// <summary>
	/// Basic Shell implementation.
	/// </summary>
	/// <typeparam name="TShell">The shell's type.</typeparam>
	/// <typeparam name="TPresenter">The shell presenter's type.</typeparam>
	public abstract class Shell<TShell, TPresenter>
		: Shell<TShell>
		where TShell : Shell<TShell>
		where TPresenter : Presenter<TShell>, IShellPresenter, new()
	{
		/// <summary>
		/// The shell's presenter which handles the shell's main view.
		/// </summary>
		protected TPresenter ShellPresenter { get; private set; }

		/// <summary>
		/// Initializes a new shell instance.
		/// </summary>
		public Shell()
			: base()
		{
			ShellPresenter = new TPresenter();

			if (!ShellPresenter.Initialize(this as TShell))
				throw new InvalidOperationException("The shell presenter could not be initialized.");

			Show(ShellPresenter);
		}

		/// <summary>
		/// Initializes and shows the shell presenter.
		/// </summary>
		protected void InitializeShellPresenter()
		{
			
		}

		/// <summary>
		/// Gets the shell's dock panel.
		/// </summary>
		protected DockPanel DockPanel
		{
			get { return ShellPresenter.DockPanel; }
		}

		/// <summary>
		/// Persists the current dock layout.
		/// </summary>
		public void PersistLayout()
		{
			ShellLayoutPersister.PersistLayout(DockPanel);
		}

		/// <summary>
		/// Loads a previously saved dock layout.
		/// </summary>
		public void LoadLayout(DeserializeDockContent viewDeserializer)
		{
			ShellLayoutPersister.LoadLayout(DockPanel, viewDeserializer);
		}

		/// <summary>
		/// Restores the given presenter, i.e. initializes the presenter, 
		/// attaches the given view to the presenter and registers the presenter on the shell.
		/// Throws an exception if the presenter has already been registered on the shell.
		/// </summary>
		/// <param name="presenter">The presenter that should be registered.</param>
		/// <param name="view">The already existing view that should be attached to the presenter.</param>
		/// <returns>Returns true if the presenter was reloaded, false if it has already been registered.</returns>
		protected bool RestorePresenter<TView>(Presenter<TView, TShell> presenter, TView view)
			where TView : DockView, new()
		{
			if (presenter == null)
				throw new ArgumentNullException("presenter");

			if (view == null)
				throw new ArgumentNullException("view");

			if (Presenters.ContainsKey(presenter.Name))
				throw new InvalidOperationException("A presenter with the name '" + presenter.Name + "' already exists in this shell.");

			view.DockHandler.TabText = view.Title;
			view.DockHandler.ToolTipText = view.Title;
			view.DockHandler.DockAreas = view.AllowedDockAreas;

			if (presenter.Initialize(this as TShell, view))
			{
				Presenters.Add(presenter.Name, presenter);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Shows the given view on the shell.
		/// </summary>
		/// <param name="view">The view that should be shown.</param>
		protected override void Show(IView view)
		{
			// If the view can be docked, add it to the dock panel.
			var dockView = view as DockView;
			if (dockView != null)
			{
				dockView.TabText = view.Title;
				dockView.ToolTipText = view.Title;
				dockView.Text = view.Title;
				dockView.DockAreas = dockView.AllowedDockAreas;
				dockView.Show(DockPanel, dockView.DefaultDockState);

				return;
			}

			// If the view is a form, show the form.
			var formView = view as FormView;
			if (formView != null)
			{
				formView.Text = view.Title;
				if (formView.IsModal)
				{
					Debug.Assert(this.ShellPresenter.IView is Form, "The shell's main view must be derived from System.Windows.Forms.Form.");
					formView.ShowDialog(this.ShellPresenter.IView as Form);
				}
				else
					formView.Show();

				return;
			}

			// If the view is a user control, show the user control.
			var userControlView = view as UserControlView;
			if (userControlView != null)
			{
				userControlView.Dock = DockStyle.Fill;
				userControlView.Show();
				return;
			}
		}

		/// <summary>
		/// Brings the given view into focus.
		/// </summary>
		/// <param name="view">The view that should be brought into focus.</param>
		protected override void Focus(IView view)
		{
			var dockView = view as DockView;
			if (dockView != null)
				dockView.Show();

			var formView = view as FormView;
			if (formView != null)
			{
				formView.BringToFront();
				formView.Focus();
			}
		}

		/// <summary>
		/// Removes the given view from the shell.
		/// </summary>
		/// <param name="view">The view that should be removed.</param>
		protected override void Remove(IView view)
		{
			// If the view can be docked, remove it from the dock panel.
			var dockView = view as DockContent;
			if (dockView != null && dockView.DockHandler.DockState != DockState.Unknown)
			{
				dockView.Close();
				dockView.Dispose();
				return;
			}

			// If the view is a form, close the form.
			var formView = view as FormView;
			if (formView != null)
			{
				if (!formView.IsDisposed)
					formView.Dispose();
				return;
			}

			// If the view is a user control, show the user control.
			var userControlView = view as UserControlView;
			if (userControlView != null)
			{
				if (userControlView.Parent != null)
					userControlView.Parent.Controls.Remove(userControlView);

				userControlView.Hide();
				userControlView.Dispose();
				return;
			}
		}

		/// <summary>
		/// Depending on the saveAll parameter, all open and modified documents or the currently focused document are saved.
		/// </summary>
		/// <param name="saveAll">Indicates whether all or just the currently focused document should be saved.</param>
		/// <returns>Indicates whether the saving process has been completed successfully.</returns>
		public override bool SaveDocuments(bool saveAll)
		{
			if (!saveAll)
			{
				var presenter = FindPresenter(DockPanel.ActiveDocument as IView) as ISaveableContentPresenter;
				if (presenter != null)
					return SaveableContentManager.Save(presenter);
				else
					return false;
			}
			else
				return SaveableContentManager.SaveAll();
		}

		/// <summary>
		/// Closes all documents. If there are modified documents, the user is asked whether he wants to save the changes.
		/// </summary>
		/// <param name="exceptions">A list of documents that is allowed to stay open.</param>
		/// <returns>Indicates whether the the saving process has been completed successfully.</returns>
		public bool CloseAllDocuments(IEnumerable<Presenter<TShell>> exceptions)
		{
			if (!SaveableContentManager.AskAndSaveAllDocuments())
				return false;

			foreach (var presenter in SaveableContentManager.Presenters)
			{
				if (exceptions != null && exceptions.Where(p => p == presenter).Count() != 0)
					continue;

				SaveableContentManager.UnregisterPresenter(presenter);
				UnregisterPresenter(presenter as Presenter<TShell>);
			}

			var t = new List<IDockContent>(ShellPresenter.DockPanel.Documents.Where(p => exceptions == null || exceptions.Where(p2 => p2.IView == p).Count() == 0));
			t.Foreach(doc => doc.DockHandler.Close());

			return true;
		}

		/// <summary>
		/// Saves the given document.
		/// </summary>
		/// <param name="presenter">The presenter of the document that should be saved.</param>
		/// <returns>Indicates whether the saving process has been completed successfully.</returns>
		protected bool SaveDocument(Presenter<TShell> presenter)
		{
			if (presenter == null)
				throw new ArgumentNullException("presenter");

			if (!(presenter is ISaveableContentPresenter))
				throw new ArgumentException("The given presenter cannot be saved: Saving is not supported.");

			return SaveableContentManager.Save(presenter as ISaveableContentPresenter);
		}
	}
}
