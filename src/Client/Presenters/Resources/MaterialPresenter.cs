using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views.Resources;
using Infrastructure.Core.Resources;

namespace Client.Presenters.Resources
{
	class MaterialPresenter : EditableResourcePresenter<MaterialView, MaterialResource>
	{
		public MaterialPresenter(MaterialResource material)
			: base(material)
		{
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.Material = Resource);
			AddChildPresenter(textEditor, (view, childView) => view.TextEditorView = childView);
			textEditor.TextHighlighting = SyntaxHighlighting.XML;

			return base.Initialize();
		}
	}
}
