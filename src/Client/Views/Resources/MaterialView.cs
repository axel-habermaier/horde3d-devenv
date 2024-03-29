using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using ICSharpCode.TextEditor.Document;
using Infrastructure.Core.Resources;
using ICSharpCode.TextEditor;

namespace Client.Views.Resources
{
	public partial class MaterialView : SaveableDocumentView
	{
		public MaterialView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.MaterialResource.GetHicon());
		}

		string title = "Material Resource";
		public override string Title
		{
			get
			{
				return title;
			}
		}

		MaterialResource material = null;
		public MaterialResource Material
		{
			get { return material; }
			set
			{
				material = value;
				title = FileSystem.TruncatePath(material.Name, MaxTitleLength);
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
	}
}
