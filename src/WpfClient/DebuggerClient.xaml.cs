using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.IO.IsolatedStorage;
using System.IO;
using WpfClient.Infrastructure;
using System.Diagnostics;
using WpfClient.UserInterface;
using WpfClient.UserInterface.Messages;
using WpfClient.Commands.Horde3DApplication;
using WpfClient.UserInterface.Horde3DApplication;

namespace WpfClient
{
	public partial class DebuggerClient : Application
	{
		#region View Models
		/// <summary>
		/// Gets the shell view model.
		/// </summary>
		public Shell Shell { get; private set; }

		/// <summary>
		/// Gets the error list view model.
		/// </summary>
		public ErrorList ErrorList { get; private set; }

		/// <summary>
		/// Gets the console output view model.
		/// </summary>
		public Output Output { get; private set; }

		/// <summary>
		/// Gets the application explorer view model.
		/// </summary>
		public ApplicationExplorer ApplicationExplorer { get; private set; }

		/// <summary>
		/// Gets the application settings view model.
		/// </summary>
		public ApplicationSettings ApplicationSettings { get; private set; }
		#endregion

		#region Horde3D Application
		/// <summary>
		/// Raised when the State property has changed.
		/// </summary>
		public static event StateChangedHandler StateChanged;

		private ApplicationState state = ApplicationState.Unloaded;
		/// <summary>
		/// The state of the currently loaded Horde3D application, if one is currently loaded.
		/// </summary>
		public ApplicationState State
		{
			get { return state; }
			set
			{
				if (state != value)
				{
					var changedEventArgs = new StateChangedEventArgs(state, value);
					state = value;

					if (StateChanged != null)
						StateChanged(null, changedEventArgs);
				}
			}
		}

		/// <summary>
		/// Gets the current Horde3D application instance.
		/// </summary>
		public Horde3DApplication Horde3DApplication { get; set; }
		#endregion

		#region Startup and Cleanup
		/// <summary>
		/// Gets the shell's view.
		/// </summary>
		private ShellView ShellView { get; set; }

		public DebuggerClient()
		{
			this.Startup += OnStartUp;
			Shell = new Shell();
			ErrorList = new ErrorList();
			Output = new Output();
			ApplicationExplorer = new ApplicationExplorer();
			ApplicationSettings = new ApplicationSettings();
		}

		private void OnStartUp(object sender, StartupEventArgs e)
		{
			ShellView = new ShellView();
			ShellView.DataContext = Shell;
			ShellView.Show();
			RestoreLayout();
		}

		public new void Shutdown()
		{
			SaveLayout();
			base.Shutdown();
		}

		private void SaveLayout()
		{
			var file = IsolatedStorageFile.GetUserStoreForAssembly();
			using (var stream = new IsolatedStorageFileStream("UiLayout", FileMode.Create, file))
				ShellView.SaveLayout(stream);
		}

		private void RestoreLayout()
		{
			try
			{
				var file = IsolatedStorageFile.GetUserStoreForAssembly();
				using (var stream = new IsolatedStorageFileStream("UiLayout", FileMode.OpenOrCreate, file))
					ShellView.RestoreLayout(stream);
			}
			catch (Exception) {}
		}
		#endregion
	}
}
