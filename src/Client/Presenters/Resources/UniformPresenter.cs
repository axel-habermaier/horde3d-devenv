using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views.Resources;
using Infrastructure.Core.Resources;

namespace Client.Presenters.Resources
{
	class UniformPresenter : DebuggerPresenter<UniformView>
	{
		public ShaderUniform Uniform { get; private set; }

		public UniformPresenter(ShaderUniform uniform)
		{
			this.Uniform = uniform;
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.Uniform = Uniform);

			return base.Initialize();
		}

		protected override bool UniqueName
		{
			get { return true; }
		}
	}
}
