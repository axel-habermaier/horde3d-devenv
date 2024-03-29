using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms.Commands;
using Client.Models;
using Client.Views;
using System.IO;


namespace Client.Commands
{
	class LoadApplicationCommand : Command<DebuggerShell>
	{
		private string loadAppPath = String.Empty;

		public LoadApplicationCommand()
		{

		}

		public override bool CanRedo
		{
			get { return false; }
		}

		public override bool CanUndo
		{
			get { return false; }
		}

		public LoadApplicationCommand(string loadAppPath)
		{
			this.loadAppPath = loadAppPath;
		}

		public override void Execute()
		{
			if (!Shell.CloseAllDocuments())
				return;

			var path = String.Empty;
			if (String.IsNullOrEmpty(loadAppPath))
			{
				var dialog = FileSystemDialog.Create(DialogType.OpenFile,
						"Load Application Settings", "h3dproj", "Horde3D Application Settings File|*.h3dproj");

				if (DebuggerShell.Current.Application != null)
					dialog.LastUsedDirectory = DebuggerShell.Current.Application.FilePath;

				dialog.Show();

				if (dialog.Canceled)
					return;

				path = dialog.SelectedPath;
			}
			else
				path = loadAppPath;

			try
			{
				if (!File.Exists(path))
					throw new ArgumentException("Could not open the selected file: '" + path + "'.");

				var app = XmlSerializer<Horde3DApplication>.Deserialize(path);
				app.FilePath = path;
				DebuggerShell.Current.Application = app;

				Properties.Settings.Default.LastApplication = path;
				Properties.Settings.Default.Save();
			}
			catch (ArgumentException e)
			{
				MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (InvalidOperationException)
			{
				MessageBox.Show("The selected file is not a valid Horde3D Development Environment Application Settings file.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
