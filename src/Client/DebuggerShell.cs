using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Infrastructure.UserInterface.WinForms;
using Client.Presenters;
using WinForms = System.Windows.Forms;
using System.Threading;
using Client.Models;
using System.Diagnostics;
using Client.Views;
using Infrastructure.UserInterface;
using Infrastructure.Core.SceneNodes;
using System.Linq;
using Infrastructure.Core.Resources;
using System.Globalization;
using Client.Presenters.Resources;
using Client.Views.Resources;
using Client.Views.SceneNodes;
using Client.Presenters.SceneNodes;

namespace Client
{
	class DebuggerShell : Shell<DebuggerShell, ShellPresenter>
	{
		#region Properties
		private Horde3DApplication application = null;
		/// <summary>
		/// Gets the current Horde3D application.
		/// </summary>
		public Horde3DApplication Application
		{
			get { return application; }
			set
			{
				if (application != value)
				{
					var changedEventArgs = new ApplicationChangedEventArgs(application, value);
					application = value;

					if (application == null)
						State = ApplicationState.Unloaded;
					else
						State = ApplicationState.Stopped;

					if (ApplicationChanged != null)
						ApplicationChanged(this, changedEventArgs);

					ResourceGraph.Clear();
					SceneGraph.Clear();
					ProfilingDataManager.Clear();
				}
			}
		}

		private ApplicationState state = ApplicationState.Unloaded;
		/// <summary>
		/// Gets or sets the state of the current application.
		/// </summary>
		public ApplicationState State
		{
			get { return state; }
			set
			{
				if (state != value)
				{
					var changedEventArgs = new ApplicationStateChangedEventArgs(state, value);
					state = value;

					if (ApplicationStateChanged != null)
						ApplicationStateChanged(null, changedEventArgs);
				}
			}
		}

		/// <summary>
		/// Gets the message dispatcher.
		/// </summary>
		public MessagesDispatcher MessagesDispatcher { get; private set; }

		/// <summary>
		/// Gets the callback handler that receives the application's callbacks.
		/// </summary>
		public CallbackHandler CallbackHandler { get; private set; }

		/// <summary>
		/// Gets the scene nodes handler.
		/// </summary>
		public SceneGraph SceneGraph { get; private set; }

		/// <summary>
		/// Gets the resources handler.
		/// </summary>
		public ResourceGraph ResourceGraph { get; private set; }

		/// <summary>
		/// Gets the profiling data manager.
		/// </summary>
		public ProfilingDataManager ProfilingDataManager { get; private set; }
		#endregion

		#region Events
		/// <summary>
		/// Raised when the current application changed.
		/// </summary>
		public event ApplicationChangedHandler ApplicationChanged;

		/// <summary>
		/// Raised when the State property has changed.
		/// </summary>
		public event ApplicationStateChangedHandler ApplicationStateChanged;
		#endregion

		#region Startup
		/// <summary>
		/// Initializes a new shell instance.
		/// </summary>
		public DebuggerShell()
			: base()
		{
			CallbackHandler = new CallbackHandler();
			MessagesDispatcher = new MessagesDispatcher();
			SceneGraph = new SceneGraph();
			ResourceGraph = new ResourceGraph();
			ProfilingDataManager = new ProfilingDataManager();

#if DEBUG
			Thread.CurrentThread.Name = "H3DDevEnv";
#endif
		}

		/// <summary>
		/// Tries to load the layout of the application when it was closed. If it fails, the default layout is used.
		/// </summary>
		public void LoadLayout()
		{
			try 
			{
				LoadLayout(DeserializeDockContent);
			}
			catch (Exception e)
			{
				MessagesDispatcher.AddSystemInfoMessage("Error loading UI layout: " + e.Message);
				RegisterPresenter(new ResourcesExplorerPresenter());
				RegisterPresenter(new ConsoleOutputPresenter());
				RegisterPresenter(new ErrorListPresenter());
				RegisterPresenter(new ResourcesExplorerPresenter());
				RegisterPresenter(new SceneGraphExplorerPresenter());
			}
			finally
			{
				RegisterPresenter(new StartPresenter());
			}
		}

		/// <summary>
		/// Loads the Horde3D application settings that were opened when the application was closed.
		/// </summary>
		public void LoadLastHorde3DApplication()
		{
			try
			{
				var path = Properties.Settings.Default.LastApplication;
				if (!String.IsNullOrEmpty(path))
				{
					var app = XmlSerializer<Horde3DApplication>.Deserialize(path);
					app.FilePath = path;
					Application = app;
				}
			}
			catch (Exception e)
			{
				MessagesDispatcher.AddSystemInfoMessage("Could not load the previously loaded application: " + e.Message);
			}
		}

		/// <summary>
		/// Initializes the event handling.
		/// </summary>
		public void InitializeEventHandling()
		{
			CallbackHandler.Resumed += (o, e) => RunSync(() => State = ApplicationState.Running);
			CallbackHandler.Suspended += (o, e) => RunSync(() =>
			{
				State = ApplicationState.Suspended;
				ResourceGraph.Clear();
				SceneGraph.Clear();
				Application.RequestDebugData();
			});
			CallbackHandler.ResourceAdded += (o, e) => ResourceGraph.Add(e.Resource);
			CallbackHandler.SceneNodeAdded += (o, e) => SceneGraph.Add(e.SceneNode);
			CallbackHandler.Profiled += (o, e) => RunSync(() =>
			{
				ProfilingDataManager.Clear();
				RegisterPresenter(new ProfilingPresenter());
				Application.RequestFrameProfilingData();
			});
			ContentSaved += (o, e) =>
			{
				if (Application != null && (State == ApplicationState.Running || state == ApplicationState.Suspended) && e.Content is EditableResource)
					Application.UpdateResource(e.Content as EditableResource);
			};
		}

		/// <summary>
		/// Saves the application settings if the application settings view is currently opened.
		/// </summary>
		public bool SaveApplicationSettings()
		{
			var presenter = RegisteredPresenters.Where(p => p.Name == "ApplicationSettings").SingleOrDefault();

			if (presenter != null)
				return SaveDocument(presenter);
			return false;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			WinForms.Application.EnableVisualStyles();
			WinForms.Application.SetCompatibleTextRenderingDefault(false);
			#if !DEBUG
			WinForms.Application.ThreadException += HandleException;
			#endif

			var shell = new DebuggerShell();
			shell.InitializeEventHandling();
			shell.LoadLayout();
			shell.LoadLastHorde3DApplication();

			WinForms.Application.Run();
			#if !DEBUG			
			WinForms.Application.ThreadException -= HandleException;
			#endif
		}

		/// <summary>
		/// Global exception handler. Displays an exception details window.
		/// </summary>
		private static void HandleException(object sender, ThreadExceptionEventArgs e)
		{
			var reporter = new ExceptionReporter.ExceptionReporter();
			reporter.ReadConfig();
			reporter.Config.ShowFlatButtons = false;
			reporter.Config.ShowButtonIcons = false;
			reporter.Config.UserExplanationFontSize = 11.0f;
			reporter.Show(e.Exception);
		}

		/// <summary>
		/// When the application is closed, the current view layout is stored in a file. During startup,
		/// this method creates the view and presenter from the persisted string.
		/// </summary>
		/// <param name="persistedString">The string that was saved to identify the view that has to be 
		/// reconstructed.</param>
		/// <returns></returns>
		private IDockContent DeserializeDockContent(string persistedString)
		{
			if (persistedString == "ErrorList")
			{
				var view = new ErrorListView();
				RestorePresenter(new ErrorListPresenter(), view);
				return view;
			}
			else if (persistedString == "ConsoleOutput")
			{
				var view = new ConsoleOutputView();
				RestorePresenter(new ConsoleOutputPresenter(), view);
				return view;
			}
			else if (persistedString == "ResourcesExplorer")
			{
				var view = new ResourcesExplorerView();
				RestorePresenter(new ResourcesExplorerPresenter(), view);
				return view;
			}
			else if (persistedString == "SceneGraphExplorer")
			{
				var view = new SceneGraphExplorerView();
				RestorePresenter(new SceneGraphExplorerPresenter(), view);
				return view;
			}
			else if (persistedString == "ProfilingView")
			{
				var view = new ProfilingView();
				RestorePresenter(new ProfilingPresenter(), view);
				return view;
			}

			return null;
		}

		/// <summary>
		/// Closes all documents. If there are modified documents, the user is asked whether he wants to save the changes.
		/// </summary>
		/// <returns>Indicates whether the the saving process has been completed successfully.</returns>
		public bool CloseAllDocuments()
		{
			Presenter<DebuggerShell> startPresenter = null;
			if (Presenters.TryGetValue("Start", out startPresenter))
				return CloseAllDocuments(new List<Presenter<DebuggerShell>> { startPresenter });
			
			return CloseAllDocuments(null);
		}
		#endregion
	}
}
