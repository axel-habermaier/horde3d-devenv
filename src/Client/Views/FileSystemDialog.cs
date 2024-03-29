using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Client.Views
{
	public enum DialogType
	{
		/// <summary>
		/// A dialog to open a file.
		/// </summary>
		OpenFile,
		/// <summary>
		/// A dialog to save a file.
		/// </summary>
		SaveFile,
		/// <summary>
		/// A dialog to choose a directory.
		/// </summary>
		ChooseDirectory
	}

	public class FileSystemDialog
	{
		/// <summary>
		/// Indicates whether the user canceled the dialog.
		/// </summary>
		public bool Canceled { get; protected set; }

		/// <summary>
		/// Gets the path the user selected if the dialog wasn't canceled.
		/// </summary>
		public string SelectedPath { get; protected set; }

		/// <summary>
		/// The dialog.
		/// </summary>
		private CommonDialog Dialog { get; set; }

		/// <summary>
		/// Gets or sets the directory that the user used the last time.
		/// </summary>
		public string LastUsedDirectory { get; set; }

		/// <summary>
		/// Initializes a new FileSystemDialog instance.
		/// </summary>
		/// <param name="title">The dialog's title.</param>
		/// <param name="defaultExtension">The default file extension.</param>
		/// <param name="filter">The filter string (for example "C# Files|*.cs|C++ Source Files|*.cpp").</param>
		/// <param name="open">Indicates whether the file will be opened or saved.</param>
		protected FileSystemDialog(string title, string defaultExtension, string filter, bool open)
		{
			FileDialog dialog = null;
			if (open)
				dialog = new OpenFileDialog();
			else
				dialog = new SaveFileDialog();

			dialog.AddExtension = true;
			dialog.Title = title;
			dialog.CheckPathExists = true;

			if (open)
				dialog.CheckFileExists = true;

			dialog.DefaultExt = defaultExtension;
			dialog.DereferenceLinks = true;
			dialog.Filter = filter;
			dialog.InitialDirectory = GetLastUsedDirectory();
			Dialog = dialog;
		}

		protected FileSystemDialog() {}

		/// <summary>
		/// Creates and initializes a new file system dialog instance.
		/// </summary>
		/// <param name="dialogType">The type of the dialog.</param>
		/// <param name="title">The dialog's title.</param>
		/// <param name="defaultExtension">The default file extension. Ignored when choosing a directory.</param>
		/// <param name="filter">The filter string (for example "C# Files|*.cs|C++ Source Files|*.cpp").
		/// Ignored when choosing a directory.</param>
		/// <returns>Returns the created dialog instance.</returns>
		public static FileSystemDialog Create(DialogType dialogType, string title, string defaultExtension, string filter)
		{
			switch (dialogType)
			{
				case DialogType.OpenFile:
					return new FileSystemDialog(title, defaultExtension, filter, true);
				case DialogType.SaveFile:
					return new FileSystemDialog(title, defaultExtension, filter, false);
				case DialogType.ChooseDirectory:
					return new ChooseDirectoryDialog(title);
			}

			throw new ArgumentException("Unsupported dialog type");
		}

		/// <summary>
		/// Shows the dialog.
		/// </summary>
		public void Show()
		{
			if (Dialog.ShowDialog() == DialogResult.OK)
			{
				Canceled = false;
				GetSelectedPath();

				try
				{
					var path = Path.GetDirectoryName(SelectedPath);
					if (!String.IsNullOrEmpty(path))
					{
						Properties.Settings.Default.LastDirectory = path;
						Properties.Settings.Default.Save();
					}
				}
				catch (Exception)
				{
					// Ignore errors.
				}
			}
			else
				Canceled = true;

			Dialog.Dispose();
		}

		/// <summary>
		/// Sets the SelectedPath property to the path selected in the dialog.
		/// </summary>
		protected virtual void GetSelectedPath()
		{
			Debug.Assert(Dialog as FileDialog != null, "Expected Dialog to be of type FileDialog.");
			SelectedPath = (Dialog as FileDialog).FileName;
		}

		/// <summary>
		/// Gets the directory the user used the last time a file system dialog was opened.
		/// </summary>
		protected string GetLastUsedDirectory()
		{
			if (!String.IsNullOrEmpty(LastUsedDirectory) && Directory.Exists(LastUsedDirectory))
				return LastUsedDirectory;

			var path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var lastPath = Properties.Settings.Default.LastDirectory;
			if (!String.IsNullOrEmpty(lastPath) && Directory.Exists(lastPath))
				path = lastPath;

			return path;
		}

		private class ChooseDirectoryDialog : FileSystemDialog
		{
			/// <summary>
			/// Initializes a new ChooseDirectoryDialog instance.
			/// </summary>
			/// <param name="title">The dialog's description.</param>
			public ChooseDirectoryDialog(string description)
			{
				var dialog = new FolderBrowserDialog();
				dialog.Description = description;
				dialog.SelectedPath = GetLastUsedDirectory();
				Dialog = dialog;
			}

			/// <summary>
			/// Sets the SelectedPath property to the path selected in the dialog.
			/// </summary>
			protected override void GetSelectedPath()
			{
				Debug.Assert(Dialog as FolderBrowserDialog != null, "Expected Dialog to be of type FolderBrowserDialog.");
				SelectedPath = (Dialog as FolderBrowserDialog).SelectedPath;
			}
		}
	}
}
