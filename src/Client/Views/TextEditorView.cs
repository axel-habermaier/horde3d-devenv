using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using ICSharpCode.TextEditor;
using Infrastructure.UserInterface;
using ICSharpCode.TextEditor.Document;

namespace Client.Views
{
	public partial class TextEditorView : UserControlView
	{
		public new event RequestHandler<string> TextChanged;
		bool requestTextChanged = true;

		DocumentEventHandler textChangedDelegate;

		public TextEditorView()
		{
			InitializeComponent();

			textChangedDelegate = (o, e) => OnTextChanged();

			textEditor.Document.DocumentChanged += textChangedDelegate;
		}

		private void OnTextChanged()
		{
			if (requestTextChanged)
				Request(TextChanged, textEditor.Document.TextContent);
		}

		private void ChangeText(Action action)
		{
			textEditor.Document.DocumentChanged -= textChangedDelegate;
			action();
			textEditor.Document.DocumentChanged += textChangedDelegate;
			OnTextChanged();
		}

		public void Undo()
		{
			ChangeText(() => textEditor.Undo());
		}

		public void Redo()
		{
			ChangeText(() => textEditor.Redo());
		}

		public new string Text
		{
			get { return textEditor.Document.TextContent; }
			set
			{
				if (textEditor.Document.TextContent != value)
				{
					if (textEditor.Document.TextContent.Length == 0)
					{
						requestTextChanged = false;
						textEditor.Document.TextContent = value;
						requestTextChanged = true;
					}
					else
					{
						ChangeText(() =>
						{
							textEditor.Document.UndoStack.StartUndoGroup();
							textEditor.Document.Remove(0, textEditor.Document.TextContent.Length);
							textEditor.Document.Insert(0, value);
							textEditor.Document.UndoStack.EndUndoGroup();
						});
					}
					textEditor.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
				}
			}
		}

		public string TextHighlighting
		{
			set { textEditor.SetHighlighting(value); }
		}
	}
}
