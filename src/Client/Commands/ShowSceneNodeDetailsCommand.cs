using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms.Commands;
using Infrastructure.Core.SceneNodes;
using Client.Presenters;
using Client.Presenters.SceneNodes;

namespace Client.Commands
{
	class ShowSceneNodeDetailsCommand : Command<DebuggerShell>
	{
		SceneNode sceneNode = null;

		public ShowSceneNodeDetailsCommand(SceneNode sceneNode)
		{
			if (sceneNode == null)
				throw new ArgumentNullException("sceneNode");

			this.sceneNode = sceneNode;
		}

		public override void Execute()
		{
			Shell.RegisterPresenter(new NodePresenter(sceneNode));
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
