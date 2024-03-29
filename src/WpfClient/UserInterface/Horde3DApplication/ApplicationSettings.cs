using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;
using WpfClient.Infrastructure.UserInterface;

namespace WpfClient.UserInterface.Horde3DApplication
{
	public class ApplicationSettings : AvalonDock.DocumentContent
	{
		#region Settings Properties
		private string executablePath = String.Empty;
		/// <summary>
		/// Gets or sets the path to the application's main executable file.
		/// </summary>
		public string ExecutablePath
		{
			get { return executablePath; }
			set 
			{
				if (executablePath != value)
				{
					executablePath = value;
					//OnPropertyChanged("ExecutablePath");
				}
			}
		}

		private string originalHorde3DDllPath = String.Empty;
		/// <summary>
		/// Gets or sets the path to the original Horde3D.dll used by the application.
		/// </summary>
		public string OriginalHorde3DDllPath
		{
			get { return originalHorde3DDllPath; }
			set
			{
				if (originalHorde3DDllPath != value)
				{
					originalHorde3DDllPath = value;
					//OnPropertyChanged("OriginalHorde3DDllPath");
				}
			}
		}

		private string arguments = String.Empty;
		/// <summary>
		/// Gets or sets the arguments passed to the application when it is started.
		/// </summary>
		public string Arguments
		{
			get { return arguments; }
			set
			{
				if (arguments != value)
				{
					arguments = value;
					//OnPropertyChanged("Arguments");
				}
			}
		}

		private string workingDirectory = String.Empty;
		/// <summary>
		/// Gets or sets the working directory passed to the application when it is started.
		/// </summary>
		public string WorkingDirectory
		{
			get { return workingDirectory; }
			set
			{
				if (workingDirectory != value)
				{
					workingDirectory = value;
					//OnPropertyChanged("WorkingDirectory");
				}
			}
		}

		private string communicationAddress = String.Empty;
		/// <summary>
		/// Gets or sets the address used to communicate with the server.
		/// </summary>
		public string CommunicationAddress
		{
			get { return communicationAddress; }
			set
			{
				if (communicationAddress != value)
				{
					communicationAddress = value;
					//OnPropertyChanged("CommunicationAddress");
				}
			}
		}

		private bool launchDebugger = false;
		/// <summary>
		/// Indicates whether the debugger should be launched when the server starts.
		/// </summary>
		public bool LaunchDebugger
		{
			get { return launchDebugger; }
			set
			{
				if (launchDebugger != value)
				{
					launchDebugger = value;
					//OnPropertyChanged("LaunchDebugger");
				}
			}
		}

		private bool isDirty = false;
		/// <summary>
		/// Indicates whether the settings were changed and the changes are not yet saved.
		/// </summary>
		public bool IsDirty
		{
			get { return isDirty; }
			set
			{
				if (isDirty != value)
				{
					isDirty = value;
					//OnPropertyChanged("IsDirty");
				}
			}
		}
		#endregion

		public ApplicationSettings()
		{
			PropertyChanged += (o, e) => IsDirty = true;
		}
	}
}
