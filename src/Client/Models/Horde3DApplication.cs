using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ServiceModel;
using Infrastructure.Core.Communication;
using Infrastructure.Core.Server;
using System.Threading;
using Infrastructure.Core.SceneNodes;
using System.Runtime.InteropServices;
using Infrastructure.Core.Resources;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Client.Models
{
	public class Horde3DApplication : INotifyPropertyUpdated, INotifyPropertyChanged
	{
		#region Properties
		private string executablePath;
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
					var previousValue = executablePath;
					executablePath = value;
					OnPropertyChanged("ExecutablePath");
					OnPropertyUpdated("ExecutablePath", previousValue, executablePath,
						new PropertyAccessor<string>(propertyValue => ExecutablePath = propertyValue, () => ExecutablePath));
				}
			}
		}

		private string originalHorde3DDllPath;
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
					var previousValue = originalHorde3DDllPath;
					originalHorde3DDllPath = value;
					OnPropertyChanged("OriginalHorde3DDllPath");
					OnPropertyUpdated("OriginalHorde3DDllPath", previousValue, originalHorde3DDllPath,
						new PropertyAccessor<string>(propertyValue => OriginalHorde3DDllPath = propertyValue, () => OriginalHorde3DDllPath));
				}
			}
		}

		private string originalHorde3DUtilsDllPath;
		/// <summary>
		/// Gets or sets the path to the original Horde3DUtils.dll used by the application.
		/// </summary>
		public string OriginalHorde3DUtilsDllPath
		{
			get { return originalHorde3DUtilsDllPath; }
			set
			{
				if (originalHorde3DUtilsDllPath != value)
				{
					var previousValue = originalHorde3DUtilsDllPath;
					originalHorde3DUtilsDllPath = value;
					OnPropertyChanged("OriginalHorde3DUtilsDllPath");
					OnPropertyUpdated("OriginalHorde3DUtilsDllPath", previousValue, originalHorde3DUtilsDllPath,
						new PropertyAccessor<string>(propertyValue => OriginalHorde3DUtilsDllPath = propertyValue, () => OriginalHorde3DUtilsDllPath));
				}
			}
		}

		private string arguments;
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
					var previousValue = arguments;
					arguments = value;
					OnPropertyChanged("Arguments");
					OnPropertyUpdated("Arguments", previousValue, arguments,
						new PropertyAccessor<string>(propertyValue => Arguments = propertyValue, () => Arguments));
				}
			}
		}

		private string workingDirectory;
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
					var previousValue = workingDirectory;
					workingDirectory = value;
					OnPropertyChanged("WorkingDirectory");
					OnPropertyUpdated("WorkingDirectory", previousValue, workingDirectory,
						new PropertyAccessor<string>(propertyValue => WorkingDirectory = propertyValue, () => WorkingDirectory));
				}
			}
		}

		private string contentDirectory;
		/// <summary>
		/// Gets or sets the application's content directory.
		/// </summary>
		public string ContentDirectory
		{
			get { return contentDirectory; }
			set
			{
				if (contentDirectory != value)
				{
					var previousValue = contentDirectory;
					contentDirectory = value;
					OnPropertyChanged("ContentDirectory");
					OnPropertyUpdated("ContentDirectory", previousValue, contentDirectory,
						new PropertyAccessor<string>(propertyValue => ContentDirectory = propertyValue, () => ContentDirectory));
				}
			}
		}

		private string communicationAddress;
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
					var previousValue = communicationAddress;
					communicationAddress = value;
					OnPropertyChanged("CommunicationAddress");
					OnPropertyUpdated("CommunicationAddress", previousValue, communicationAddress,
						new PropertyAccessor<string>(propertyValue => CommunicationAddress = propertyValue, () => CommunicationAddress));
				}
			}
		}

		private bool launchDebugger;
		/// <summary>
		/// Gets or sets a value indicating whether the debugger should be launched when the server starts.
		/// </summary>
		public bool LaunchDebugger
		{
			get { return launchDebugger; }
			set
			{
				if (launchDebugger != value)
				{
					var previousValue = launchDebugger;
					launchDebugger = value;
					OnPropertyChanged("LaunchDebugger");
					OnPropertyUpdated("LaunchDebugger", previousValue, launchDebugger,
						new PropertyAccessor<bool>(propertyValue => LaunchDebugger = propertyValue, () => LaunchDebugger));
				}
			}
		}

		/// <summary>
		/// Gets the application's dll directory.
		/// </summary>
		private string DllDirectory
		{
			get { return Path.GetDirectoryName(OriginalHorde3DDllPath); }
		}

		private string filePath = null;
		/// <summary>
		/// Gets or sets path to the application's file on the disk.
		/// </summary>
		[XmlIgnore]
		public string FilePath
		{
			get { return filePath; }
			set
			{
				filePath = value;

				if (NameChanged != null)
					NameChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets the "name" of the application, i.e. the filename without the extension.
		/// </summary>
		public string Name
		{
			get { return Path.GetFileNameWithoutExtension(FilePath ?? "unnamed"); }
		}
		#endregion

		#region Events
		/// <summary>
		/// Raised when the process has exited.
		/// </summary>
		public event EventHandler ProcessExited;

		/// <summary>
		/// Raised when the application's name changed.
		/// </summary>
		public event EventHandler NameChanged;
		#endregion

		public Horde3DApplication()
		{
			ExecutablePath = String.Empty;
			OriginalHorde3DDllPath = String.Empty;
			Arguments = String.Empty;
			ContentDirectory = String.Empty;
			OriginalHorde3DUtilsDllPath = String.Empty;
			WorkingDirectory = String.Empty;
			CommunicationAddress = "net.pipe://localhost/";
			LaunchDebugger = false;
		}

		#region Private Properties
		/// <summary>
		/// Gets a temporary path to the original Horde3D.dll.
		/// </summary>
		private string TemporaryHorde3DDllPath
		{
			get { return Path.Combine(Path.GetDirectoryName(OriginalHorde3DDllPath), Infrastructure.Core.Properties.Settings.Default.OriginalHorde3DDllName); }
		}

		/// <summary>
		/// Indicates whether the application is currently running.
		/// </summary>
		private bool IsRunning
		{
			get { return applicationProcess != null && !applicationProcess.HasExited; }
		}

		/// <summary>
		/// Gets or sets the debugger service proxy instance for the current application process.
		/// </summary>
		private DebuggerServiceProxy DebuggerServiceProxy { get; set; }
		#endregion

		#region Fields
		/// <summary>
		/// The application's Windows process.
		/// </summary>
		private Process applicationProcess;
		#endregion

		#region System Operations
		/// <summary>
		/// Launches the Horde3D application.
		/// </summary>
		/// <param name="callbackHandler">A class that handles the application's callbacks.</param>
		public void Launch(IDebuggerServiceCallback callbackHandler)
		{
			VerifyThread();
			if (DebuggerShell.Current.State == ApplicationState.Running || DebuggerShell.Current.State == ApplicationState.Suspended)
				throw new InvalidOperationException("Cannot start an already running or suspended application.");

			if (!File.Exists(ExecutablePath))
				throw new ArgumentException("The application's executable path is invalid. The given path was '" + ExecutablePath + "'.");

			if (!File.Exists(OriginalHorde3DDllPath))
				throw new ArgumentException("The application's path to the original Horde3D.dll is invalid. The given path was '" + OriginalHorde3DDllPath + "'.");

			if (!File.Exists(OriginalHorde3DUtilsDllPath))
				throw new ArgumentException("The application's path to the original Horde3DUtils.dll is invalid. The given path was '" + OriginalHorde3DUtilsDllPath + "'.");

			if (!Directory.Exists(WorkingDirectory))
				throw new ArgumentException("The application's working directory is invalid. The given path was '" + WorkingDirectory + "'.");

			if (!Directory.Exists(ContentDirectory))
				throw new ArgumentException("The application's content directory is invalid. The given path was '" + ContentDirectory + "'.");

			if (!CommunicationAddress.StartsWith("net.pipe://localhost/"))
				throw new ArgumentException("The application's communication address is invalid. Currently only named pipes are supported. The communication address must begin with 'net.pipe://localhost/'.");

			DebuggerShell.Current.MessagesDispatcher.AddDebugSessionMessage("Debug session started.");
			DebuggerShell.Current.State = ApplicationState.Running;
			RenameOriginalDll();
			CopyDebuggerDlls();
			GenerateSettings();
			StartProcess();
			applicationProcess.Exited += OnApplicationProcessExited;
			DebuggerShell.Current.MessagesDispatcher.AddDebugSessionMessage("Launched application.");

			var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
			binding.MaxReceivedMessageSize = Int32.MaxValue;
			binding.MaxBufferSize = Int32.MaxValue;
			binding.ReaderQuotas.MaxArrayLength = Int32.MaxValue;
			binding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;
			binding.ReaderQuotas.MaxBytesPerRead = Int32.MaxValue;

			DebuggerServiceProxy = new DebuggerServiceProxy(callbackHandler, binding, new EndpointAddress(CommunicationAddress));
			DebuggerServiceProxy.OpenConnection();
		}

		private void OnApplicationProcessExited(object sender, EventArgs e)
		{
			// The process exited. Set the system's state correctly and clean up. 
			// This method is called from a different thread, so we have to switch to the GUI thread first.
			DebuggerShell.Current.RunSync(() =>
			{
				applicationProcess.Exited -= OnApplicationProcessExited;
				DebuggerShell.Current.MessagesDispatcher.AddDebugSessionMessage("Process has exited.");
				ShutDown();
			});
		}

		/// <summary>
		/// Shuts down the Horde3D application.
		/// </summary>
		public void ShutDown()
		{
			VerifyThread();
			DebuggerShell.Current.MessagesDispatcher.AddDebugSessionMessage("Exiting application.");
			DebuggerShell.Current.State = ApplicationState.Stopped;

			if (IsRunning)
				applicationProcess.EnableRaisingEvents = false;

			if (DebuggerServiceProxy != null)
			{
				DebuggerServiceProxy.Close();
				DebuggerServiceProxy = null;
			}

			DebuggerServiceProxy = null;

			ShutDownProcess();
			DebuggerShell.Current.MessagesDispatcher.AddDebugSessionMessage("Debug session closed.");
		}

		/// <summary>
		/// Suspends the execution of the Horde3D execution.
		/// </summary>
		public void Suspend()
		{
			VerifyThread();
			if (DebuggerServiceProxy == null || DebuggerShell.Current.State == ApplicationState.Stopped)
				throw new InvalidOperationException("Cannot send a suspend request to an application that is currently not running.");

			DebuggerServiceProxy.Invoke(service => service.Suspend());
		}

		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		/// <summary>
		/// Resumes the execution of the Horde3D execution.
		/// </summary>
		public void Resume()
		{
			VerifyThread();
			if (DebuggerServiceProxy == null || DebuggerShell.Current.State == ApplicationState.Stopped)
				throw new InvalidOperationException("Cannot send a resume request to an application that is currently not running.");

			DebuggerServiceProxy.Invoke(service =>
			{
				service.Resume();
				if (applicationProcess != null && applicationProcess.MainWindowHandle != IntPtr.Zero)
					SetForegroundWindow(applicationProcess.MainWindowHandle);
			});
		}

		/// <summary>
		/// Profiles the Horde3D application.
		/// </summary>
		public void Profile()
		{
			VerifyThread();
			if (DebuggerServiceProxy == null || DebuggerShell.Current.State == ApplicationState.Stopped)
				throw new InvalidOperationException("Cannot send a profiling request to an application that is currently not running.");

			DebuggerServiceProxy.Invoke(service => service.Profile());
		}

		/// <summary>
		/// Updates the given resource in the running Horde3D application.
		/// </summary>
		/// <param name="resource">The resource that should be updated.</param>
		public void UpdateResource(EditableResource resource)
		{
			VerifyThread();
			if (DebuggerServiceProxy == null || DebuggerShell.Current.State == ApplicationState.Stopped)
				throw new InvalidOperationException("Cannot update a resource of an application that is currently not running.");

			DebuggerServiceProxy.Invoke(service => service.UpdateResource(resource));
		}

		/// <summary>
		/// Gets the current data of the specified render target.
		/// </summary>
		/// <param name="pipelineResHandle">The render target's pipeline's resource handle.</param>
		/// <param name="renderTargetName">The render target's name.</param>
		/// <param name="colorBufferIndex">The color buffer index.</param>
		public void GetRenderTargetData(int pipelineResHandle, string renderTargetName, int colorBufferIndex, Action<byte[]> dataReceivedAction)
		{
			VerifyThread();
			if (DebuggerServiceProxy == null || DebuggerShell.Current.State == ApplicationState.Stopped)
				throw new InvalidOperationException("Cannot get the data of a render target of an application that is currently not running.");

			DebuggerServiceProxy.Invoke(service =>
			{
				var data = service.GetRenderTargetData(pipelineResHandle, renderTargetName, colorBufferIndex);
				if (dataReceivedAction != null)
					dataReceivedAction(data);
			});
		}

		/// <summary>
		/// Requests the debug data from the server.
		/// </summary>
		public void RequestDebugData()
		{
			VerifyThread();
			if (DebuggerServiceProxy == null || DebuggerShell.Current.State == ApplicationState.Stopped)
				throw new InvalidOperationException("Cannot request debug data from an application that is currently not suspended.");

			DebuggerServiceProxy.Invoke(service => service.RequestDebugData());
		}

		/// <summary>
		/// Requests the frame profiling data from the server.
		/// </summary>
		public void RequestFrameProfilingData()
		{
			VerifyThread();
			if (DebuggerServiceProxy == null || DebuggerShell.Current.State == ApplicationState.Stopped)
				throw new InvalidOperationException("Cannot request frame profiling data from an application that is currently not running.");

			DebuggerServiceProxy.Invoke(service => service.RequestFrameProfilingData());
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Does all the clean up after the process has exited.
		/// </summary>
		private void CleanUpProcessDirectory()
		{
			RemoveDebuggerDlls();
			RemoveSettings();
			RestoreOriginalDll();
		}

		/// <summary>
		/// Renames the original Horde3D.dll to Infrastructure.Core.Properties.Settings.Default.OriginalHorde3DDllName.
		/// </summary>
		private void RenameOriginalDll()
		{
			if (IsRunning)
				throw new InvalidOperationException("Cannot rename the original Horde3D.dll while the application is running.");

			if (!File.Exists(TemporaryHorde3DDllPath))
				File.Move(OriginalHorde3DDllPath, TemporaryHorde3DDllPath);
		}

		/// <summary>
		/// Copies the required debugger dlls to the path of the original Horde3D.dll.
		/// </summary>
		private void CopyDebuggerDlls()
		{
			if (IsRunning)
				throw new InvalidOperationException("Cannot copy the debugger dlls into the application directory while the application is running.");

			using (var writer = new BinaryWriter(new FileStream(OriginalHorde3DDllPath, FileMode.Create, FileAccess.Write)))
				writer.Write(Properties.Resources.Horde3DDll);
			using (var writer = new BinaryWriter(new FileStream(Path.Combine(DllDirectory, Properties.Settings.Default.CoreDll), FileMode.Create, FileAccess.Write)))
				writer.Write(Properties.Resources.CoreDll);
			using (var writer = new BinaryWriter(new FileStream(Path.Combine(DllDirectory, Properties.Settings.Default.ExtensionsDll), FileMode.Create, FileAccess.Write)))
				writer.Write(Properties.Resources.ExtensionsDll);
			using (var writer = new BinaryWriter(new FileStream(Path.Combine(DllDirectory, Properties.Settings.Default.Horde3DNetDll), FileMode.Create, FileAccess.Write)))
				writer.Write(Properties.Resources.Horde3DNetDll);
			using (var writer = new BinaryWriter(new FileStream(Path.Combine(DllDirectory, Properties.Settings.Default.NativeInteropDll), FileMode.Create, FileAccess.Write)))
				writer.Write(Properties.Resources.NativeInteropDll);
			using (var writer = new BinaryWriter(new FileStream(Path.Combine(DllDirectory, Properties.Settings.Default.DetouredDll), FileMode.Create, FileAccess.Write)))
				writer.Write(Properties.Resources.DetouredDll);
		}

		/// <summary>
		/// Generates the application's settings file and copies it into the application's directory.
		/// </summary>
		private void GenerateSettings()
		{
			if (IsRunning)
				throw new InvalidOperationException("Cannot copy the settings into the application directory while the application is running.");

			var settings = new ServerConfiguration();
			settings.CommunicationAddress = CommunicationAddress;
			settings.LaunchDebugger = LaunchDebugger;
			settings.ContentDirectory = ContentDirectory;
			settings.OriginalHorde3DDllPath = OriginalHorde3DDllPath;
			settings.OriginalHorde3DUtilsDllPath = OriginalHorde3DUtilsDllPath;

			XmlSerializer<ServerConfiguration>.Serialize(settings, Path.Combine(this.WorkingDirectory, Infrastructure.Core.Properties.Settings.Default.ServerSettingsFileName));
		}

		/// <summary>
		/// Starts the Horde3D application's Windows process.
		/// </summary>
		private void StartProcess()
		{
			if (IsRunning)
				throw new InvalidOperationException("Cannot start the application twice.");

			var info = new ProcessStartInfo();
			info.FileName = ExecutablePath;
			info.WorkingDirectory = WorkingDirectory;
			info.Arguments = Arguments;

			applicationProcess = new Process();
			applicationProcess.StartInfo = info;
			applicationProcess.EnableRaisingEvents = true;
			applicationProcess.Exited += OnProcessExited;
			applicationProcess.Start();
		}

		private void OnProcessExited(object sender, EventArgs e)
		{
			if (ProcessExited != null)
				ProcessExited(sender, e);
		}

		/// <summary>
		/// Shuts down the Horde3D application's Windows process.
		/// </summary>
		private void ShutDownProcess()
		{
			if (IsRunning && applicationProcess != null)
			{
				applicationProcess.CloseMainWindow();
				applicationProcess.Exited -= OnProcessExited;

				var process = applicationProcess;
				ThreadPool.QueueUserWorkItem(o =>
				{
					if (!process.WaitForExit(15000))
					{
						process.Kill();
						Thread.Sleep(3000);
					}

					CleanUpProcessDirectory();
				});
			}
			else
				CleanUpProcessDirectory();

			applicationProcess = null;
		}

		/// <summary>
		/// Removes the debugger dlls from the application's directory.
		/// </summary>
		private void RemoveDebuggerDlls()
		{
			if (IsRunning)
				throw new InvalidOperationException("Cannot remove the debugger dlls from the application directory while the application is running.");

			try
			{
				File.Delete(Path.Combine(DllDirectory, Properties.Settings.Default.ExtensionsDll));
				File.Delete(Path.Combine(DllDirectory, Properties.Settings.Default.CoreDll));
				File.Delete(Path.Combine(DllDirectory, Properties.Settings.Default.Horde3DNetDll));
				File.Delete(Path.Combine(DllDirectory, Properties.Settings.Default.NativeInteropDll));
				File.Delete(Path.Combine(DllDirectory, Properties.Settings.Default.DetouredDll));

				if (File.Exists(TemporaryHorde3DDllPath))
					File.Delete(OriginalHorde3DDllPath);
			}
			catch (Exception e)
			{
				DebuggerShell.Current.MessagesDispatcher.AddDebugSessionError("There was an error trying to delete the debugger dlls from the process' directory: " + e.Message);
			}
		}

		/// <summary>
		/// Removes the debugger settings file from the application's directory.
		/// </summary>
		private void RemoveSettings()
		{
			if (IsRunning)
				throw new InvalidOperationException("Cannot remove the debugger settings file from the application directory while the application is running.");

			try
			{
				var path = Path.Combine(this.WorkingDirectory, Infrastructure.Core.Properties.Settings.Default.ServerSettingsFileName);
				if (File.Exists(path))
					File.Delete(path);
			}
			catch (Exception e)
			{
				DebuggerShell.Current.MessagesDispatcher.AddDebugSessionError("There was an error trying to delete the debugger settings file from the process' directory: " + e.Message);
			}
		}

		/// <summary>
		/// Restores the application's original Horde3D.dll.
		/// </summary>
		private void RestoreOriginalDll()
		{
			if (IsRunning)
				throw new InvalidOperationException("Cannot restore the original Horde3D.dll while the application is running.");

			try
			{
				if (File.Exists(TemporaryHorde3DDllPath))
					File.Move(TemporaryHorde3DDllPath, OriginalHorde3DDllPath);
			}
			catch (Exception e)
			{
				DebuggerShell.Current.MessagesDispatcher.AddDebugSessionError("There was an error trying to restore the process' original Horde3D-DLL: " + e.Message);
			}
		}
		#endregion

		#region INotifyPropertyUpdated Implementation
		/// <summary>
		/// Raised when the value of a property was updated.
		/// <summary/>		
		public event PropertyUpdatedEventHandler PropertyUpdated;

		/// <summary>
		/// Raises the PropertyUpdated event.
		/// </summary>
		/// <param name="propertyName">The name of the property that was changed.</param>
		/// <param name="previousValue">The value of the property before the update.</param>
		/// <param name="currentValue">The value of the property after the update.</param>
		/// <param name="propertyAccessor">The property accessor.</param>
		protected void OnPropertyUpdated(string propertyName, object previousValue, object currentValue, IPropertyAccessor propertyAccessor)
		{
			if (PropertyUpdated != null)
				PropertyUpdated(this, new PropertyUpdatedEventArgs(propertyName, previousValue, currentValue, propertyAccessor));
		}
		#endregion

		#region INotifyPropertyChanged Implementation
		/// <summary>
		/// Raised when the value of a property was changed.
		/// <summary/>		
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises the PropertyChanged event.
		/// </summary>
		/// <param name="propertyName">The name of the property that was changed.</param>
		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		[Conditional("DEBUG")]
		private void VerifyThread()
		{
			Debug.Assert(Thread.CurrentThread.Name == "H3DDevEnv", "Method not invoked on the main thread.");
		}
	}

	#region Application Changed Delegate and EventArgs
	/// <summary>
	/// Delegated used by the ApplicationChanged event.
	/// </summary>
	/// <param name="sender">The event's source.</param>
	/// <param name="e">Further information associated with the event.</param>
	public delegate void ApplicationChangedHandler(object sender, ApplicationChangedEventArgs e);

	/// <summary>
	/// A class containing further details when the ApplicationChanged event is handled.
	/// </summary>
	public class ApplicationChangedEventArgs : EventArgs
	{
		/// <summary>
		/// The previous ApplicationState.
		/// </summary>
		public Horde3DApplication PreviousApplication { get; private set; }

		/// <summary>
		/// The current ApplicationState.
		/// </summary>
		public Horde3DApplication CurrentApplication { get; private set; }

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="previousState">The previous Horde3DApplication.</param>
		/// <param name="currentState">The current Horde3DApplication.</param>
		public ApplicationChangedEventArgs(Horde3DApplication previousApplication, Horde3DApplication currentApplication)
		{
			PreviousApplication = previousApplication;
			CurrentApplication = currentApplication;
		}
	}
	#endregion
}
