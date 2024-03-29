using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms.Commands;
using Client.Models;
using Client.Presenters;

namespace Client.Commands
{
	class ProfileFrameCommand : Command<DebuggerShell>
	{
		public override void Execute()
		{
			if (Shell.State == ApplicationState.Suspended || Shell.State == ApplicationState.Running)
				Shell.Application.Profile();
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
