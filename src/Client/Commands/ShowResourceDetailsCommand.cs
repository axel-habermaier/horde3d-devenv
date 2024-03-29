using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms.Commands;
using Infrastructure.Core.Resources;
using Client.Presenters;
using Client.Presenters.Resources;
using System.Windows.Forms;

namespace Client.Commands
{
	class ShowResourceDetailsCommand : Command<DebuggerShell>
	{
		Resource resource = null;

		public ShowResourceDetailsCommand(Resource resource)
		{
			if (resource == null)
				throw new ArgumentNullException("resource");

			this.resource = resource;
		}

		public override void Execute()
		{
			if (resource is ShaderResource)
				Shell.RegisterPresenter(new ShaderPresenter(resource as ShaderResource));
			else if (resource is PipelineResource)
				Shell.RegisterPresenter(new PipelinePresenter(resource as PipelineResource));
			else if (resource is MaterialResource)
				Shell.RegisterPresenter(new MaterialPresenter(resource as MaterialResource));
			else if (resource is ParticleEffectResource)
				Shell.RegisterPresenter(new ParticleEffectPresenter(resource as ParticleEffectResource));
			else if (resource is CodeResource)
				Shell.RegisterPresenter(new CodePresenter(resource as CodeResource));
			else if (resource is TextureResource)
				Shell.RegisterPresenter(new TexturePresenter(resource as TextureResource));
			else // HACK
				MessageBox.Show("This resource type is currently not supported.", "Not supported", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public override bool CanRedo
		{
			get { return false; }
		}

		public override bool CanUndo
		{
			get { return false; }
		}
	}
}
