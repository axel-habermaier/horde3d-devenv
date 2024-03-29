using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views;
using Infrastructure.Core.Resources;
using Client.Views.Resources;

namespace Client.Presenters.Resources
{
	class PipelinePresenter : EditableResourcePresenter<PipelineView, PipelineResource>
	{
		public PipelinePresenter(PipelineResource pipeline)
			: base(pipeline)
		{
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.Pipeline = Resource);
			AddChildPresenter(textEditor, (view, childView) => view.TextEditorView = childView);
			textEditor.TextHighlighting = SyntaxHighlighting.XML;

			return base.Initialize();
		}
	}
}
