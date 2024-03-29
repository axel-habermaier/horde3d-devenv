using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views.Resources;
using Infrastructure.Core.Resources;

namespace Client.Presenters.Resources
{
	class ShaderSectionPresenter : DebuggerPresenter<ShaderSectionView>
	{
		public ShaderSection Section { get; private set; }

		private ShaderType shaderType = ShaderType.Unknown;

		public ShaderSectionPresenter(ShaderSection section)
		{
			this.Section = section;
			name = Guid.NewGuid().ToString();
		}

		public ShaderSectionPresenter(ShaderSection section, ShaderType shaderType)
		{
			this.Section = section;
			name = Guid.NewGuid().ToString();
			this.shaderType = shaderType;
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.ShaderSection = Section);
			UpdateView(view => view.ShaderType = shaderType);

			return base.Initialize();
		}

		string name;
		public override string Name
		{
			get
			{
				return name;
			}
		}
	}
}
