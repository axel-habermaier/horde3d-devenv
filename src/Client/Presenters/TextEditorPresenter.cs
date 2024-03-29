using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views;
using Infrastructure.UserInterface;

namespace Client.Presenters
{
	public enum SyntaxHighlighting
	{
		XML,
		CSharp,
		Cpp
	}

	class TextEditorPresenter : DebuggerPresenter<TextEditorView>
	{
		public event RequestHandler<string> TextChanged
		{
			add { UpdateView(view => view.TextChanged += value); }
			remove { UpdateView(view => view.TextChanged -= value); }
		}

		protected override bool UniqueName
		{
			get { return true; }
		}

		public string Text
		{
			get
			{
				var text = String.Empty;
				UpdateView(view => text = view.Text);
				return text;
			}
			set { UpdateView(view => view.Text = value); }
		}

		public void Undo()
		{
			UpdateView(view => view.Undo());
		}

		public void Redo()
		{
			UpdateView(view => view.Redo());
		}

		public SyntaxHighlighting TextHighlighting
		{
			set 
			{
				switch (value)
				{
					case SyntaxHighlighting.XML:
						UpdateView(view => view.TextHighlighting = "XML");
						break;
					case SyntaxHighlighting.Cpp:
						UpdateView(view => view.TextHighlighting = "C++.NET");
						break;
					case SyntaxHighlighting.CSharp:
						UpdateView(view => view.TextHighlighting = "C#");
						break;
				}
				 
			}
		}
	}
}
