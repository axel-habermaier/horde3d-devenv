using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Infrastructure.UserInterface.WinForms
{
	/// <summary>
	/// Manages the state of a saveable content view.
	/// </summary>
	internal interface ISaveableContentPresenter
	{
		/// <summary>
		/// Writes the content to the given stream.
		/// </summary>
		/// <param name="stream">The stream the content should be written to.</param>
		void SaveContent(Stream stream);

		/// <summary>
		/// Loads the content from the given stream.
		/// </summary>
		/// <param name="stream">The stream the content should be loaded from.</param>
		void LoadContent(Stream stream);

		/// <summary>
		/// Gets the view of the saveable content.
		/// </summary>
		SaveableDocumentView View { get; }

		/// <summary>
		/// Gets the name of the file that stores the saveable content.
		/// </summary>
		string ContentFileName { get; }

		/// <summary>
		/// Gets the path to the file that stores the saveable content.
		/// </summary>
		string ContentFilePath { get; }

		/// <summary>
		/// Gets the saveable content.
		/// </summary>
		object SaveableContent { get; }

		/// <summary>
		/// Gets the save state.
		/// </summary>
		SaveState SaveState { get; }

		/// <summary>
		/// Raised when the SaveState property has changed.
		/// </summary>
		event EventHandler SaveStateChanged;
	}
}
