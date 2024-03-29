using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.UserInterface;
using Infrastructure.Core.Resources;
using System.IO;
using System.ComponentModel;
using Client.Commands;

namespace Client.Presenters
{
	class DebuggerPresenter<TView> : Presenter<TView, DebuggerShell>
		where TView : class, IView, new()
	{
		public DebuggerPresenter()
			: base()
		{

		}
	}

	abstract class SaveableContentDebuggerPresenter<TView> : SaveableContentPresenter<TView, DebuggerShell>
		where TView : SaveableDocumentView, new()
	{
		public SaveableContentDebuggerPresenter()
			: base()
		{

		}
	}

	class EditableResourcePresenter<TView, TResource> : SaveableContentDebuggerPresenter<TView>
		where TView : SaveableDocumentView, new()
		where TResource : EditableResource
	{
		/// <summary>
		/// Gets or sets the resource managed by this presenter.
		/// </summary>
		protected TResource Resource { get; set; }

		bool recordChanges = false;

		protected TextEditorPresenter textEditor = new TextEditorPresenter();

		public EditableResourcePresenter(TResource resource)
			: base()
		{
			Resource = resource;
		}

		public override string Name
		{
			get { return typeof(TResource).Name + Resource.Name; }
		}

		protected override string FileName
		{
			get { return Resource.Name; }
		}

		protected override string FilePath
		{
			get { return Shell.Application.ContentDirectory; }
		}

		protected override void Save(Stream stream)
		{
			using (var writer = new StreamWriter(stream))
				writer.Write(Resource.FileContent);

			SaveState = SaveState.Saved;
		}

		protected override void Load(Stream stream)
		{
			using (var reader = new StreamReader(stream))
				Resource.FileContent = reader.ReadToEnd();

			SaveState = SaveState.Saved;
		}

		protected override bool InitializeEvents()
		{
			Resource.PropertyUpdated += ResourcePropertyUpdated;
			textEditor.TextChanged += TextChanged;

			return base.InitializeEvents();
		}

		protected override bool Initialize()
		{
			textEditor.Text = Resource.FileContent;
			recordChanges = true;

			return base.Initialize();
		}

		protected override void Release()
		{
			Resource.PropertyUpdated -= ResourcePropertyUpdated;
			textEditor.TextChanged -= TextChanged;

			base.Release();
		}

		private void TextChanged(string newText)
		{
			SaveState = SaveState.Unsaved;
			Resource.FileContent = textEditor.Text;
			HandleCommand(new ChangeTextEditorTextCommand(textEditor));
		}

		protected void ResourcePropertyUpdated(object sender, PropertyUpdatedEventArgs e)
		{
			if (recordChanges && e.PropertyName != "FileContent")
			{
				Resource.GenerateXml();
				textEditor.Text = Resource.FileContent;
				return;
			}
		}

		protected override object SaveableContent
		{
			get { return Resource; }
		}
	}
}
