using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms.Commands;

namespace Infrastructure.CodeGenerator.Commands
{
	class ParseCommand : Command<CodeGeneratorShell>
	{
		private string filePath;

		public ParseCommand(string horde3DFilePath)
		{
			this.filePath = horde3DFilePath;
		}

		public override void Execute()
		{
			if (Shell.CurrentSettings != null)
				Shell.CurrentSettings.ParseHorde3DFunctions(filePath);
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
