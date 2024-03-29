using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.Core.Resources;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace Client.Views.Resources
{
	public partial class PipelineView : SaveableDocumentView
	{
		public PipelineView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.PipelineResource.GetHicon());
		}

		string title = "Pipeline Resource";
		public override string Title
		{
			get
			{
				return title;
			}
		}

		PipelineResource pipeline = null;
		public PipelineResource Pipeline 
		{
			get { return pipeline; }
			set
			{
				pipeline = value;
				title = FileSystem.TruncatePath(pipeline.Name, MaxTitleLength);
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
