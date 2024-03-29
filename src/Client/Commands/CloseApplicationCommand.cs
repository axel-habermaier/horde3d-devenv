using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms.Commands;

namespace Client.Commands
{
	class CloseApplicationCommand : Command<DebuggerShell>
	{
		public override void Execute()
		{
			if (Shell.CloseAllDocuments())
				DebuggerShell.Current.Application = null;
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
