using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Infrastructure.UserInterface.WinForms.Commands;

namespace Infrastructure.UserInterface.WinForms
{
	/// <summary>
	/// Manages the state of a saveable content view and handles user requests that are forwarded to the presenter by the view.
	/// </summary>
	/// <typeparam name="TView">The saveable content view's type.</typeparam>
	/// <typeparam name="TShell">The shell's type.</typeparam>
	public abstract class SaveableContentPresenter<TView, TShell>
		: Presenter<TView, TShell>, ISaveableContentPresenter
		where TShell : Shell<TShell>
		where TView : SaveableDocumentView, new()
	{
		/// <summary>
		/// Writes the content to the given stream.
		/// </summary>
		/// <param name="stream">The stream the content should be written to.</param>
		void ISaveableContentPresenter.SaveContent(Stream stream)
		{
			Save(stream);
		}

		/// <summary>
		/// Loads the content from the given stream.
		/// </summary>
		/// <param name="stream">The stream the content should be loaded from.</param>
		void ISaveableContentPresenter.LoadContent(Stream stream)
		{
			Load(stream);
		}

		/// <summary>
		/// Gets the view of the saveable content.
		/// </summary>
		SaveableDocumentView ISaveableContentPresenter.View 
		{
			get { return View as SaveableDocumentView; }
		}

		/// <summary>
		/// Gets the name of the file that stores the saveable content.
		/// </summary>
		string ISaveableContentPresenter.ContentFileName 
		{
			get { return FileName; }
		}

		/// <summary>
		/// Gets the path to the file that stores the saveable content.
		/// </summary>
		string ISaveableContentPresenter.ContentFilePath
		{
			get { return FilePath; }
		}

		/// <summary>
		/// Gets the saveable content.
		/// </summary>
		object ISaveableContentPresenter.SaveableContent 
		{
			get { return SaveableContent; }
		}

		/// <summary>
		/// Gets the save state.
		/// </summary>
		SaveState ISaveableContentPresenter.SaveState 
		{
			get { return SaveState; }
		}

		/// <summary>
		/// Raised when the SaveState property has changed.
		/// </summary>
		event EventHandler ISaveableContentPresenter.SaveStateChanged
		{
			add { SaveStateChanged += value; }
			remove { SaveStateChanged -= value; }
		}

		/// <summary>
		/// Gets the name of the file that stores the saveable content. Must be overridden by deriving classes.
		/// </summary>
		protected abstract string FileName { get; }

		/// <summary>
		/// Gets the path to the file that stores the saveable content. By default the file name is relative to
		/// the application's working directory.
		/// </summary>
		protected virtual string FilePath { get { return String.Empty; } }

		/// <summary>
		/// Gets the saveable content.
		/// </summary>
		protected abstract object SaveableContent { get; }

		/// <summary>
		/// Writes the content to the given stream and sets the SaveState property to Saved.
		/// Must be overridden by deriving classes.
		/// </summary>
		/// <param name="stream">The stream the content should be written to.</param>
		protected abstract void Save(Stream stream);

		/// <summary>
		/// Loads the content from the given stream and sets the SaveState property to Saved.
		/// Must be overridden by deriving classes.
		/// </summary>
		/// <param name="stream">The stream the content should be loaded from.</param>
		protected abstract void Load(Stream stream);

		private SaveState saveState = SaveState.Saved;
		/// <summary>
		/// Gets the save state.
		/// </summary>
		public SaveState SaveState 
		{
			get { return saveState; }
			protected set
			{
				if (saveState != value)
				{
					saveState = value;
					if (SaveStateChanged != null)
						SaveStateChanged(this, EventArgs.Empty);

					UpdateView(view => view.SaveState = saveState);
				}
			}
		}

		/// <summary>
		/// Raised when the SaveState property has changed.
		/// </summary>
		event EventHandler SaveStateChanged;

		/// <summary>
		/// Initializes the presenter and sets its view to the given view instance.
		/// </summary>
		/// <param name="shell">The shell this presenter belongs to.</param>
		/// <param name="view">The presenter's view.</param>
		/// <param name="preInitAction">An action that should be executed before calling the Initialize and
		/// InitializeEvents methods.</param>
		/// <returns>Returns true if the presenter was initialized successfully.</returns>
		internal override bool Initialize(TShell shell, IView view, Func<bool> preInitAction)
		{
			return base.Initialize(shell, view, () => 
			{
				bool result = Shell.SaveableContentManager.RegisterPresenter(this);
				if (result && preInitAction != null)
					result = result && preInitAction();
				return result;
			});
		}

		/// <summary>
		/// Releases the presenter.
		/// </summary>
		protected override void Release()
		{
			Shell.SaveableContentManager.UnregisterPresenter(this);
			base.Release();
		}
	}
}
