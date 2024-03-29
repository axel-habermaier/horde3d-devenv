using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views.Resources;
using Infrastructure.Core.Resources;

namespace Client.Presenters.Resources
{
	class SamplerPresenter : DebuggerPresenter<SamplerView>
	{
		public ShaderSampler Sampler { get; private set; }

		public SamplerPresenter(ShaderSampler sampler)
		{
			this.Sampler = sampler;
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.Sampler = Sampler);

			return base.Initialize();
		}

		protected override bool UniqueName
		{
			get { return true; }
		}
	}
}
