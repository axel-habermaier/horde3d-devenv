using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace Infrastructure.UserInterface.WinForms
{
	/// <summary>
	/// Manages saveable content: If the content has changed, the view is instructed to show visual feedback (i.e. by showing
	/// a star (*) in the title) and if the view is closed and has been modified, the user is asked whether the changeds should be saved.
	/// </summary>
	internal class SaveableContentManager
	{
		/// <summary>
		/// A list of all presenters that present saveable content.
		/// </summary>
		List<SaveableContent> presenters = new List<SaveableContent>();

		/// <summary>
		/// Gets a readonly collection of all presenters that present saveable content.
		/// </summary>
		internal ReadOnlyCollection<ISaveableContentPresenter> Presenters
		{
			get { return presenters.Select(p => p.Presenter).ToList().AsReadOnly(); }
		}

		/// <summary>
		/// Raised when content has been saved.
		/// </summary>
		public event ContentSavedHandler ContentSaved;

		/// <summary>
		/// Raises the ContentSaved event.
		/// </summary>
		/// <param name="content">The content that has been saved.</param>
		private void OnContentSaved(object content)
		{
			if (ContentSaved != null)
				ContentSaved(this, new ContentSavedEventArgs(content));
		}

		/// <summary>
		/// Registers the given presenter.
		/// </summary>
		/// <param name="presenter">The presenter that should be registered.</param>
		/// <returns>Indicates whether the registration was successful.</returns>
		public bool RegisterPresenter(ISaveableContentPresenter presenter)
		{
			if (presenters.Where(p => p.Presenter == presenter).Count() != 0)
				throw new InvalidOperationException("The given presenter has already been registered on the SaveableContentManager.");

			try
			{
				using (var stream = new FileStream(Path.Combine(presenter.ContentFilePath, presenter.ContentFileName), FileMode.Open, FileAccess.Read))
					presenter.LoadContent(stream);
			}
			catch (IOException e)
			{
				MessageBox.Show("Unable to open file '" + Path.Combine(presenter.ContentFilePath, presenter.ContentFileName) + "'. The error was: " + e.Message,
					"Error Opening File", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			presenters.Add(new SaveableContent(this, presenter));
			return true;
		}

		/// <summary>
		/// Unregisters the given presenter.
		/// </summary>
		/// <param name="presenter">The presenter that should be unregistered.</param>
		public void UnregisterPresenter(ISaveableContentPresenter presenter)
		{
			var saveableContent = presenters.Where(p => p.Presenter == presenter).ToList();
			saveableContent.Foreach(s => s.Unregister());
			saveableContent.Foreach(s => presenters.Remove(s));
		}

		/// <summary>
		/// Depending on the presenter parameter, all open and modified documents or the currently focused document are saved.
		/// </summary>
		/// <param name="presenter">The presenter that should be saved. If null, all currently open presenters are saved.</param>
		/// <returns>Indicates whether the saving process has been completed successfully.</returns>
		internal bool Save(ISaveableContentPresenter presenter)
		{
			if (presenter == null)
				throw new ArgumentNullException("presenter");

			var saveablePresenter = presenters.Where(p => p.Presenter == presenter).SingleOrDefault();
			if (saveablePresenter == null)
				throw new ArgumentException("The given presenter is currently not registered.");

			return saveablePresenter.Save();
		}

		/// <summary>
		/// Saves all currently registered and modified documents.
		/// </summary>
		/// <returns>Indicates whether the saving process has been completed successfully.</returns>
		internal bool SaveAll()
		{
			bool success = true;
			presenters.Foreach(p => success = success && p.Save());
			return success;
		}

		/// <summary>
		/// If there are modified documents, the user is asked whether he wants to save the changes.
		/// </summary>
		/// <returns>Indicates whether the the saving process has been completed successfully.</returns>
		internal bool AskAndSaveAllDocuments()
		{
			if (presenters.Where(p => p.Presenter.SaveState == SaveState.Unsaved).Count() != 0)
			{
				var dialog = new SavePendingChangesDialog();
				dialog.ModifiedDocuments = presenters.Where(p => p.Presenter.SaveState == SaveState.Unsaved).Select(p => p.Presenter.View.Title).ToList();
				var result = dialog.ShowDialog();

				switch (result)
				{
					case DialogResult.Cancel:
						return false;
					case DialogResult.No:
						break;
					case DialogResult.Yes:
						if (!Save(null))
							return false;
						break;
				}
			}

			return true;
		}

		#region Private Helper Class
		private class SaveableContent
		{
			/// <summary>
			/// Gets the presenter.
			/// </summary>
			public ISaveableContentPresenter Presenter { get; private set; }

			/// <summary>
			/// The saveable content manager instance.
			/// </summary>
			SaveableContentManager manager;

			/// <summary>
			/// Initializes a new instance.
			/// </summary>
			/// <param name="manager">The saveable content manager instance.</param>
			/// <param name="presenter">The presenter.</param>
			public SaveableContent(SaveableContentManager manager, ISaveableContentPresenter presenter)
			{
				this.manager = manager;
				Presenter = presenter;

				Presenter.View.Removing += View_Removing;
			}

			/// <summary>
			/// Unregisters the saveable content.
			/// </summary>
			public void Unregister()
			{
				Presenter.View.Removing -= View_Removing;
			}

			/// <summary>
			/// Called when the view is closed. Asks the user if he wants to save any changes he might have made.
			/// </summary>
			void View_Removing(object sender, RemovingViewEventArgs e)
			{
				if (Presenter.SaveState == SaveState.Unsaved)
				{
					var result = MessageBox.Show("Do you want to save the changes you have made to '" + Presenter.View.Title + "'?",
						"Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

					switch (result)
					{
						case DialogResult.Cancel:
							e.Cancel = true;
							return;
						case DialogResult.No:
							return;
						case DialogResult.Yes:
							if (!Save())
								e.Cancel = true;
							return;
					}
				}
			}

			/// <summary>
			/// Saves the document.
			/// </summary>
			/// <returns>Indicates whether the saving process has been completed successfully.</returns>
			public bool Save()
			{
				try
				{
					using (var stream = new FileStream(Path.Combine(Presenter.ContentFilePath, Presenter.ContentFileName), FileMode.Create, FileAccess.Write))
						Presenter.SaveContent(stream);

					manager.OnContentSaved(Presenter.SaveableContent);

					return true;
				}
				catch (IOException ex)
				{
					MessageBox.Show("Unable to save file '" + Path.Combine(Presenter.ContentFilePath, Presenter.ContentFileName) + "'. The error was: " + ex.Message,
						"Error Saving File", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}
		}
		#endregion
	}

	/// <summary>
	/// Delegate used by the ContentSaved event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">Further details about the event.</param>
	public delegate void ContentSavedHandler(object sender, ContentSavedEventArgs e);

	/// <summary>
	/// Contains further details about the ContentSaved event.
	/// </summary>
	public class ContentSavedEventArgs : EventArgs
	{
		/// <summary>
		/// Gets the content that has been saved.
		/// </summary>
		public object Content { get; private set; }

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		/// <param name="content">The content that has been saved.</param>
		public ContentSavedEventArgs(object content)
		{
			Content = content;
		}
	}
}
