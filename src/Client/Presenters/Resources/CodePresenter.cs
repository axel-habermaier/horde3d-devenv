using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views.Resources;
using Infrastructure.Core.Resources;

namespace Client.Presenters.Resources
{
	class CodePresenter : EditableResourcePresenter<CodeView, CodeResource>
	{
		public CodePresenter(CodeResource code)
			: base(code)
		{
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.Code = Resource);
			AddChildPresenter(textEditor, (view, childView) => view.TextEditorView = childView);
			textEditor.TextHighlighting = SyntaxHighlighting.Cpp;

			return base.Initialize();
		}
	}
}
