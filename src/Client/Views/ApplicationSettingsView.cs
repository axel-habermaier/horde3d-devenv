using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;

using System.IO;
using Client.Models;

namespace Client.Views
{
	public partial class ApplicationSettingsView : SaveableDocumentView
	{
		public ApplicationSettingsView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.Properties.GetHicon());
		}

		internal Horde3DApplication Settings
		{
			set { bindingSource.DataSource = value; }
		}

		public override string Title
		{
			get
			{
				return "Application Settings";
			}
		}

		private void executableButton_Click(object sender, EventArgs e)
		{
			var dialog = FileSystemDialog.Create(DialogType.OpenFile, "The application's executable file", ".exe",
				"Executable Files|*.exe|Batch Files|*.bat");
			dialog.Show();

			if (dialog.Canceled)
				return;

			executableTextBox.Text = dialog.SelectedPath;

			workingDirectoryTextBox.Text = Path.GetDirectoryName(dialog.SelectedPath);
			dllTextBox.Text = Path.Combine(Path.GetDirectoryName(dialog.SelectedPath), "Horde3D.dll");
			utilsDllTextBox.Text = Path.Combine(Path.GetDirectoryName(dialog.SelectedPath), "Horde3DUtils.dll");
			contentDirectoryTextBox.Text = Path.Combine(Path.GetDirectoryName(dialog.SelectedPath), "Content");
			communicationAddressTextBox.Text = "net.pipe://localhost/" + Path.GetFileNameWithoutExtension(dialog.SelectedPath);
		}

		private void dllButton_Click(object sender, EventArgs e)
		{
			var dialog = FileSystemDialog.Create(DialogType.OpenFile, "The application's Horde3D Dll",
				".dll", "Dynamic Link Libraries|*.dll");
			dialog.Show();

			if (dialog.Canceled)
				return;

			dllTextBox.Text = dialog.SelectedPath;
		}

		private void workingDirectoryButton_Click(object sender, EventArgs e)
		{
			var dialog = FileSystemDialog.Create(DialogType.ChooseDirectory, "Choose the application's working directory.", null, null);
			dialog.Show();

			if (dialog.Canceled)
				return;

			workingDirectoryTextBox.Text = dialog.SelectedPath;
		}

		private void contentDirectoryButton_Click(object sender, EventArgs e)
		{
			var dialog = FileSystemDialog.Create(DialogType.ChooseDirectory, "Choose the application's content directory.", null, null);
			dialog.Show();

			if (dialog.Canceled)
				return;

			contentDirectoryTextBox.Text = dialog.SelectedPath;
		}

		private void utilsDllButton_Click(object sender, EventArgs e)
		{
			var dialog = FileSystemDialog.Create(DialogType.OpenFile, "The application's Horde3DUtils Dll",
				".dll", "Dynamic Link Libraries|*.dll");
			dialog.Show();

			if (dialog.Canceled)
				return;

			utilsDllTextBox.Text = dialog.SelectedPath;
		}
	}
}
