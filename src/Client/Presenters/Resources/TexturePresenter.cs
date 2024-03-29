using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views.Resources;
using Infrastructure.Core.Resources;
using System.IO;

namespace Client.Presenters.Resources
{
	class TexturePresenter : DebuggerPresenter<TextureView>
	{
		TextureResource texture = null;

		public TexturePresenter(TextureResource texture)
			: base()
		{
			this.texture = texture;
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.Texture = texture);
			UpdateView(view => view.TexturePreviewUri = Path.Combine(Shell.Application.ContentDirectory, texture.Name));

			return base.Initialize();
		}

		public override string Name
		{
			get
			{
				return "Texture" + texture.Name;
			}
		}
	}
}
