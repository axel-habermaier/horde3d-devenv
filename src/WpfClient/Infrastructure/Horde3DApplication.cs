using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using Infrastructure.Core.Communication;
using Infrastructure.Core.Server;
using System.Xml.Serialization;
using System.Threading;
using System.ServiceModel;

namespace WpfClient.Infrastructure
{
	public class Horde3DApplication
	{
		#region Properties
		/// <summary>
		/// Gets or sets the path to the application's main executable file.
		/// </summary>
		public string ExecutablePath { get; set; }

		/// <summary>
		/// Gets or sets the path to the original Horde3D.dll used by the application.
		/// </summary>
		public string OriginalHorde3DDllPath { get; set; }

		/// <summary>
		/// Gets or sets the arguments passed to the application when it is started.
		/// </summary>
		public string Arguments { get; set; }

		/// <summary>
		/// Gets or sets the working directory passed to the application when it is started.
		/// </summary>
		public string WorkingDirectory { get; set; }

		/// <summary>
		/// Gets or sets the address used to communicate with the server.
		/// </summary>
		public string CommunicationAddress { get; set; }

		/// <summary>
		/// Indicates whether the debugger should be launched when the server starts.
		/// </summary>
		public bool LaunchDebugger { get; set; }

		/// <summary>
		/// Gets the application's dll directory.
		/// </summary>
		private string DllDirectory
		{
			get { return Path.GetDirectoryName(OriginalHorde3DDllPath); }
		}

		/// <summary>
		/// Gets the path to the application's file on the disk.
		/// </summary>
		[XmlIgnore]
		public string FilePath { get; private set; }

		/// <summary>
		/// Gets the "name" of the application, i.e. the filename without the extension.
		/// </summary>
		[XmlIgnore]
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
		#endregion

		public Horde3DApplication()
		{
			ExecutablePath = String.Empty;
			OriginalHorde3DDllPath = String.Empty;
			Arguments = String.Empty;
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
			get { return Path.Combine(Path.GetDirectoryName(OriginalHorde3DDllPath), Properties.Settings.Default.OriginalHorde3DDllName); }
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
		//private DebuggerServiceProxy DebuggerServiceProxy { get; set; }
		#endregion

		#region Fields
		/// <summary>
		/// The application's Windows process.
		/// </summary>
		private Process applicationProcess;
		#endregion

		#region System Operations
		/// <summary>
		/// Starts the Horde3D application.
		/// </summary>
		/// <param name="callbackHandler">A class that handles the application's callbacks.</param>
		public void StartHorde3DApplication(IDebuggerServiceCallback callbackHandler)
		{
			if (IsRunning)
				throw new InvalidOperationException("Cannot start an already running or suspended application.");

			if (!File.Exists(ExecutablePath))
				throw new ArgumentException("The application's executable path is invalid. The given path was '" + ExecutablePath + "'.");

			if (!File.Exists(OriginalHorde3DDllPath))
				throw new ArgumentException("The application's path to the original Horde3D.dll is invalid. The given path was '" + OriginalHorde3DDllPath + "'.");

			if (!Directory.Exists(WorkingDirectory))
				throw new ArgumentException("The application's working directory is invalid. The given path was '" + WorkingDirectory + "'.");

			if (!CommunicationAddress.StartsWith("net.pipe://localhost/"))
				throw new ArgumentException("The application's communication address is invalid. Currently only named pipes are supported. The communication address must begin with 'net.pipe://localhost/'.");


			RenameOriginalDll();
			CopyDebuggerDlls();
			GenerateSettings();
			StartProcess();
			//DebuggerServiceProxy = new DebuggerServiceProxy(callbackHandler, new NetNamedPipeBinding(NetNamedPipeSecurityMode.None), new EndpointAddress(CommunicationAddress));
			//DebuggerServiceProxy.OpenConnection();
		}

		/// <summary>
		/// Shuts down the Horde3D application.
		/// </summary>
		public void ShutDownHorde3DApplication()
		{
			if (IsRunning)
				applicationProcess.EnableRaisingEvents = false;

			//if (DebuggerServiceProxy != null)
			//{
			//    DebuggerServiceProxy.Close();
			//    DebuggerServiceProxy = null;
			//}

			//DebuggerServiceProxy = null;

			ShutDownProcess();
		}

		/// <summary>
		/// Suspends the execution of the Horde3D execution.
		/// </summary>
		public void SuspendHorde3DApplication()
		{
			if (IsRunning)
				throw new InvalidOperationException("Cannot suspend the application when it is not running.");
			//DebuggerServiceProxy.Suspend();
		}

		/// <summary>
		/// Resumes the execution of the Horde3D execution.
		/// </summary>
		public void ResumeHorde3DApplication()
		{
			//DebuggerServiceProxy.Resume();
		}

		/// <summary>
		/// Saves the Horde3D application in the given file.
		/// </summary>
		/// <param name="filePath">Path to the file the settings should be written to. May be null if this method
		/// was called before with a valid file path.</param>
		public void SaveHorde3DApplication(string filePath)
		{
			if (IsRunning)
				throw new InvalidOperationException("Cannot save settings while the application is currently being debugged.");

			if (String.IsNullOrEmpty(filePath))
				filePath = FilePath;

			if (String.IsNullOrEmpty(filePath))
				throw new ArgumentNullException("filePath", "If the application has never been saved before, you have to specify a file path.");

			XmlSerializer<Horde3DApplication>.Serialize(this, filePath);
			FilePath = filePath;
		}

		/// <summary>
		/// Loads an application instance from the given file.
		/// </summary>
		/// <param name="filePath">Path to a file that contains a serialized application instance.</param>
		/// <returns>Returns the deserialized Horde3DApplication instance.</returns>
		public static Horde3DApplication LoadHorde3DApplication(string filePath)
		{
			var app = XmlSerializer<Horde3DApplication>.Deserialize(filePath);
			app.FilePath = filePath;
			return app;
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

			XmlSerializer<ServerConfiguration>.Serialize(settings, Path.Combine(this.WorkingDirectory, Properties.Settings.Default.ServerSettingsFileName));
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

			File.Delete(Path.Combine(DllDirectory, Properties.Settings.Default.ExtensionsDll));
			File.Delete(Path.Combine(DllDirectory, Properties.Settings.Default.CoreDll));
			File.Delete(Path.Combine(DllDirectory, Properties.Settings.Default.Horde3DNetDll));
			File.Delete(Path.Combine(DllDirectory, Properties.Settings.Default.NativeInteropDll));
			File.Delete(Path.Combine(DllDirectory, Properties.Settings.Default.DetouredDll));

			if (File.Exists(TemporaryHorde3DDllPath))
				File.Delete(OriginalHorde3DDllPath);
		}

		/// <summary>
		/// Removes the debugger settings file from the application's directory.
		/// </summary>
		private void RemoveSettings()
		{
			if (IsRunning)
				throw new InvalidOperationException("Cannot remove the debugger settings file from the application directory while the application is running.");

			var path = Path.Combine(this.WorkingDirectory, Properties.Settings.Default.ServerSettingsFileName);
			if (File.Exists(path))
				File.Delete(path);
		}

		/// <summary>
		/// Restores the application's original Horde3D.dll.
		/// </summary>
		private void RestoreOriginalDll()
		{
			if (IsRunning)
				throw new InvalidOperationException("Cannot restore the original Horde3D.dll while the application is running.");

			if (File.Exists(TemporaryHorde3DDllPath))
				File.Move(TemporaryHorde3DDllPath, OriginalHorde3DDllPath);
		}
		#endregion
	}
}
