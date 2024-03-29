using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using Infrastructure.UserInterface.WinForms;
using ICSharpCode.TextEditor;
using Infrastructure.Core.Resources;

namespace Client.Views.Resources
{
	public partial class CodeView : SaveableDocumentView
	{
		public CodeView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.CodeResource.GetHicon());

		}

		string title = "Code Resource";
		public override string Title
		{
			get
			{
				return title;
			}
		}

		public TextEditorView TextEditorView
		{
			set
			{
				if (value == null)
					return;

				Controls.Add(value);
			}
		}

		CodeResource code = null;
		public CodeResource Code 
		{
			get { return code; }
			set
			{
				code = value;
				title = FileSystem.TruncatePath(code.Name, MaxTitleLength);
			}
		}
	}
}
