using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views.Resources;
using Infrastructure.Core.Resources;

namespace Client.Presenters.Resources
{
	class ParticleEffectPresenter : EditableResourcePresenter<ParticleEffectView, ParticleEffectResource>
	{
		public ParticleEffectPresenter(ParticleEffectResource particleEffect)
			: base(particleEffect)
		{
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.ParticleEffect = Resource);
			AddChildPresenter(textEditor, (view, childView) => view.TextEditorView = childView);
			textEditor.TextHighlighting = SyntaxHighlighting.XML;

			return base.Initialize();
		}
	}
}
