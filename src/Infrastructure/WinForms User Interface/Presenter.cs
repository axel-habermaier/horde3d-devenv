using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;
using System.Collections.ObjectModel;
using Infrastructure.UserInterface.WinForms.Commands;
using System.Diagnostics;

namespace Infrastructure.UserInterface.WinForms
{
	/// <summary>
	/// Manages the state of a view and handles user requests that are forwarded to the presenter by the view.
	/// </summary>
	/// <typeparam name="TView">The view's type.</typeparam>
	public abstract class Presenter<TShell>
		where TShell : Shell<TShell>
	{
		/// <summary>
		/// Gets the presenter's name. The default name is the presenter's class name without
		/// the "Presenter" suffix. If the presenter has a parent, the parent's name is prefixed.
		/// This can be overridden in deriving classes.
		/// </summary>
		public virtual string Name
		{
			get
			{
				if (UniqueName)
				{
					if (String.IsNullOrEmpty(uniqueName))
						uniqueName = Guid.NewGuid().ToString();

					return uniqueName;
				}

				var parentName = Parent == null ? String.Empty : Parent.Name;

				var fullName = this.GetType().Name;
				var index = fullName.LastIndexOf("Presenter");
				if (index == -1)
					return parentName + fullName;
				else
					return parentName + fullName.Substring(0, index);
			}
		}

		string uniqueName = String.Empty;
		/// <summary>
		/// Indicates whether a unique name should be automatically generated for the presenter.
		/// </summary>
		protected virtual bool UniqueName
		{
			get { return false; }
		}

		private Presenter<TShell> parent;
		/// <summary>
		/// Gets the presenter's parent.
		/// </summary>
		private Presenter<TShell> Parent
		{
			get { return parent; }
			set
			{
				if (parent != null)
					throw new InvalidOperationException("Cannot change a presenter's parent.");

				parent = value;
			}
		}

		/// <summary>
		/// Gets the presenter's child presenter.
		/// </summary>
		private List<Presenter<TShell>> Children { get; set; }

		/// <summary>
		/// Indicates whether the presenter has already been initialized.
		/// </summary>
		public bool Initialized { get; internal set; }

		/// <summary>
		/// Indicates whether the presenter has already been disposed.
		/// </summary>
		public bool Disposed { get; internal set; }

		bool enabled = false;
		/// <summary>
		/// Indicates whether the presenter is enabled.
		/// </summary>
		public bool Enabled
		{
			get { return enabled; }
			set
			{
				if (enabled != value)
				{
					enabled = value;
					EnabledChanged();
					if (enabled)
						ShowView();
					else
						RemoveView();
				}
			}
		}

		/// <summary>
		/// Gets the shell the presenter belongs to.
		/// </summary>
		public TShell Shell { get; internal set; }

		/// <summary>
		/// Gets the presenter's view object as an instance of IView.
		/// </summary>
		internal abstract IView IView { get; }

		/// <summary>
		/// Creates a new Presenter instance.
		/// </summary>
		public Presenter()
		{
			Initialized = false;
			Disposed = false;
			Children = new List<Presenter<TShell>>();
		}

		/// <summary>
		/// Uses the shell's command dispatcher to handle the given command.
		/// </summary>
		/// <param name="command">The command to handle.</param>
		protected void HandleCommand(Command<TShell> command)
		{
			var presenter = Parent == null ? this : Parent;
			Shell.CommandDispatcher.HandleCommand(presenter, command);
		}

		/// <summary>
		/// Throws an exception if the presenter has either not been initialized or has already been disposed of.
		/// </summary>
		private void CheckState()
		{
			if (Disposed)
				throw new InvalidOperationException("Presenter has already been disposed of.");

			if (!Initialized)
				throw new InvalidOperationException("Presenter has not yet been initialized.");
		}

		/// <summary>
		/// Adds the given presenter to the presenter's child collection.
		/// </summary>
		/// <param name="presenter">The new child presenter.</param>
		/// <param name="show">Indicates whether the view should be immediately shown.</param>
		/// <typeparam name="TChildView">The child presenter's view type.</typeparam>
		/// <returns>Returns true if the child presenter has been added successfully.</returns>
		protected bool AddChildPresenter<TChildView>(Presenter<TChildView, TShell> presenter, bool show)
			where TChildView : class, IView, new()
		{
			presenter.Parent = this;
			if (Shell.RegisterPresenter(presenter, false))
			{
				Children.Add(presenter);

				if (show)
					Shell.Show(presenter);

				return true;
			}
			return false;
		}

		/// <summary>
		/// Adds the given presenter to the presenter's child collection and shows its view.
		/// </summary>
		/// <param name="presenter">The new child presenter.</param>
		/// <typeparam name="TChildView">The child presenter's view type.</typeparam>
		/// <returns>Returns true if the child presenter has been added successfully.</returns>
		protected bool AddChildPresenter<TChildView>(Presenter<TChildView, TShell> presenter)
			where TChildView : class, IView, new()
		{
			return AddChildPresenter(presenter, true);
		}

		/// <summary>
		/// Removes the given child presenter from the presenter's child collection.
		/// </summary>
		/// <param name="presenter">The child presenter that should be removed.</param>
		/// <returns>Returns true if the child presenter has been removed successfully.</returns>
		protected bool RemoveChildPresenter(Presenter<TShell> presenter)
		{
			if (Shell.UnregisterPresenter(presenter))
			{
				Children.Remove(presenter);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Initializes the presenter and creates a new view instance.
		/// </summary>
		/// <param name="shell">The shell this presenter belongs to.</param>
		/// <returns>Returns true if the presenter was initialized successfully.</returns>
		internal abstract bool Initialize(TShell shell);

		/// <summary>
		/// Initializes the presenter and sets its view to the given view instance.
		/// </summary>
		/// <param name="shell">The shell this presenter belongs to.</param>
		/// <param name="view">The presenter's view.</param>
		/// <returns>Returns true if the presenter was initialized successfully.</returns>
		internal abstract bool Initialize(TShell shell, IView view);

		/// <summary>
		/// Initializes the presenter and sets its view to the given view instance.
		/// </summary>
		/// <param name="shell">The shell this presenter belongs to.</param>
		/// <param name="view">The presenter's view.</param>
		/// <param name="preInitAction">An action that should be executed before calling the Initialize and
		/// InitializeEvents methods.</param>
		/// <returns>Returns true if the presenter was initialized successfully.</returns>
		internal abstract bool Initialize(TShell shell, IView view, Func<bool> preInitAction);

		/// <summary>
		/// Uninitializes the presenter and frees all resources that it used. Also removes
		/// the presenter's view.
		/// </summary>
		internal void Uninitialize()
		{
			if (!Initialized)
				throw new InvalidOperationException("Presenter has not yet been initialized.");

			if (!Disposed)
			{
				// We have to copy the list - otherwise we would modify it while iterating through it.
				var tempChildren = new List<Presenter<TShell>>(Children);
				tempChildren.Foreach(c => RemoveChildPresenter(c));

				Enabled = false;
				Release();
				if (!IView.IsDisposed)
					IView.Dispose();

				Disposed = true;
			}
		}

		/// <summary>
		/// Override this method in a deriving class if any custom cleanup
		/// has to be performed before disposing the presenter. 
		/// The view can safely be access in this method and will be disposed afterwards.
		/// </summary>
		protected virtual void Release() { }

		/// <summary>
		/// Override this method in a deriving class if any initialization
		/// needs to be performed when the presenter and the view are created.
		/// </summary>
		/// <returns>Returns true if the presenter was initialized successfully.</returns>
		protected virtual bool Initialize() { return true; }

		/// <summary>
		/// Override this method in a deriving class if any actions need to be
		/// performed when the presenter is enabled or disabled.
		/// </summary>
		protected virtual void EnabledChanged() { }

		/// <summary>
		/// Override this method in a deriving class if the presenter must
		/// listen to any events and/or view requests.
		/// </summary>
		/// <returns>Returns true if the presenter was initialized successfully.</returns>
		protected virtual bool InitializeEvents() { return true; }

		/// <summary>
		/// Override this method in a deriving class if the presenter must
		/// perform any actions after the view has been loaded.
		/// </summary>
		protected virtual void ViewLoaded() { }

		/// <summary>
		/// Shows the presenter's view on the shell.
		/// </summary>
		protected void ShowView()
		{
			Shell.Show(this);
		}

		/// <summary>
		/// Removes the presenter's view from the shell.
		/// </summary>
		protected void RemoveView()
		{
			Shell.Remove(this);
		}
	}

	/// <summary>
	/// Manages the state of a view and handles user requests that are forwarded to the presenter by the view.
	/// </summary>
	/// <typeparam name="TView">The view's type.</typeparam>
	/// <typeparam name="TShell">The shell's type.</typeparam>
	public class Presenter<TView, TShell>
		: Presenter<TShell>
		where TShell : Shell<TShell>
		where TView : class, IView, new()
	{
		/// <summary>
		/// Gets the presenter's strongly-typed view object.
		/// </summary>
		internal TView View { get; private set; }

		/// <summary>
		/// Gets the presenter's view object as an instance of IView.
		/// </summary>
		internal override IView IView
		{
			get { return View as IView; }
		}

		/// <summary>
		/// Runs the given method only if the view is not disposed of.
		/// </summary>
		/// <param name="method">An action that should be executed on the presenter's view.
		/// The view is provided as the action's parameter.</param>
		protected void UpdateView(Action<TView> action)
		{
			Shell.RunSyncWait(() =>
			{
				if (View != null && !View.IsDisposed)
					action(View);
			});
		}

		/// <summary>
		/// Initializes the presenter and creates a new view instance.
		/// </summary>
		/// <param name="shell">The shell this presenter belongs to.</param>
		/// <returns>Returns true if the presenter was initialized successfully.</returns>
		internal override bool Initialize(TShell shell)
		{
			return Initialize(shell, new TView());
		}

		/// <summary>
		/// Initializes the presenter and sets its view to the given view instance.
		/// </summary>
		/// <param name="shell">The shell this presenter belongs to.</param>
		/// <param name="view">The presenter's view.</param>
		/// <returns>Returns true if the presenter was initialized successfully.</returns>
		internal override bool Initialize(TShell shell, IView view)
		{
			return Initialize(shell, view, null);
		}

		/// <summary>
		/// Initializes the presenter and sets its view to the given view instance.
		/// </summary>
		/// <param name="shell">The shell this presenter belongs to.</param>
		/// <param name="view">The presenter's view.</param>
		/// <param name="commandDispatcher">The command dispatcher that the presenter should use.</param>
		/// <param name="preInitAction">An action that should be executed before calling the Initialize and
		/// InitializeEvents methods.</param>
		/// <returns>Returns true if the presenter was initialized successfully.</returns>
		internal override bool Initialize(TShell shell, IView view, Func<bool> preInitAction)
		{
			Debug.Assert(view is TView, "The given view is not of type " + typeof(TView).FullName);

			if (Disposed)
				throw new InvalidOperationException("Presenter has already been disposed of.");

			if (Initialized)
				throw new InvalidOperationException("Presenter has already been initialized.");

			bool result = true;

			Shell = shell;
			View = view as TView;
			View.Removed += (o, e) => { if (!Disposed) Shell.UnregisterPresenter(this); };
			View.Load += (o, e) => ViewLoaded();

			if (preInitAction != null)
				result = result && preInitAction();

			result = result && Initialize();
			result = result && InitializeEvents();

			Initialized = true;
			return result;
		}

		/// <summary>
		/// Adds the given presenter to the presenter's child collection.
		/// </summary>
		/// <param name="presenter">The new child presenter.</param>
		/// <param name="viewAction">The action that should be performed on/with the view.</param>
		/// <param name="show">Indicates whether the view should be immediately shown.</param>
		/// <typeparam name="TChildView">The child presenter's view type.</typeparam>
		/// <returns>Returns true if the child presenter has been added successfully.</returns>
		protected bool AddChildPresenter<TChildView>(Presenter<TChildView, TShell> presenter, Action<TView, TChildView> viewAction, bool show)
			where TChildView : class, IView, new()
		{
			var success = AddChildPresenter(presenter, show);
			if (success && viewAction != null)
				viewAction(View, presenter.View);

			return success;
		}

		/// <summary>
		/// Adds the given presenter to the presenter's child collection and shows its view.
		/// </summary>
		/// <param name="presenter">The new child presenter.</param>
		/// <param name="viewAction">The action that should be performed on/with the view.</param>
		/// <typeparam name="TChildView">The child presenter's view type.</typeparam>
		/// <returns>Returns true if the child presenter has been added successfully.</returns>
		protected bool AddChildPresenter<TChildView>(Presenter<TChildView, TShell> presenter, Action<TView, TChildView> viewAction)
			where TChildView : class, IView, new()
		{
			return AddChildPresenter(presenter, viewAction, true);
		}
	}
}
