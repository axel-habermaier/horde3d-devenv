using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WpfClient.Infrastructure.UserInterface
{
	class FileSelector
	{
		/// <summary>
		/// Gets the file path that was selected by the user.
		/// </summary>
		public string FilePath { get; private set; }

		/// <summary>
		/// Indicates whether the user made a selection or canceled the process.
		/// </summary>
		public bool Canceled { get; private set; }

		FileDialog fileDialog = new OpenFileDialog();

		/// <summary>
		/// Initializes a new FileSelector instance.
		/// </summary>
		/// <param name="title">The dialog's title.</param>
		/// <param name="defaultExtension">The default file extension used by the dialog.</param>
		/// <param name="filter">The type filters used by the dialog (format: C# Files|*.cs|C++ Files|*.cpp)</param>
		/// <param name="open">Indicates whether the file should be opened (true) or saved (false).</param>
		public FileSelector(string title, string defaultExtension, string filter, bool open)
		{
			if (open)
				fileDialog = new OpenFileDialog();
			else
				fileDialog = new SaveFileDialog();

			fileDialog.AddExtension = true;
			fileDialog.Title = title;
			fileDialog.CheckPathExists = true;
			fileDialog.DefaultExt = defaultExtension;
			fileDialog.DereferenceLinks = true;
			fileDialog.Filter = filter;
			fileDialog.InitialDirectory = String.IsNullOrEmpty(Properties.Settings.Default.LastDirectory)
				? Environment.CurrentDirectory : Properties.Settings.Default.LastDirectory;
		}

		/// <summary>
		/// Shows the file selection dialog and blocks the calling thread until the user has either selected
		/// a file or canceled the dialog.
		/// </summary>
		public void Show()
		{
			Canceled = true;
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				Canceled = false;
				FilePath = fileDialog.FileName;

				// Save the currently selected directory and reuse it the next time a file selection dialog box is shown.
				Properties.Settings.Default.LastDirectory = Path.GetDirectoryName(fileDialog.FileName);
				Properties.Settings.Default.Save();
			}

			fileDialog.Dispose();
		}
	}
}
