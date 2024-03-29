using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms.Commands;

namespace Infrastructure.CodeGenerator.Commands
{
	class ResetCommand : Command<CodeGeneratorShell>
	{
		public override void Execute()
		{
			var ask = new AskToSaveCommand();
			HandleCommand(ask);

			if (!ask.Cancel)
				Shell.CurrentSettings = null;
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
