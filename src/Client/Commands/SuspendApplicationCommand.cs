using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms.Commands;
using Client.Models;
using Client.Presenters;


namespace Client.Commands
{
	class SuspendApplicationCommand : Command<DebuggerShell>
	{
		public override void Execute()
		{
			if (DebuggerShell.Current.State == ApplicationState.Running)
				DebuggerShell.Current.Application.Suspend();
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
