using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms.Commands;
using System.Windows.Forms;

namespace Infrastructure.CodeGenerator.Commands
{
	class GenerateCodeCommand : Command<CodeGeneratorShell>
	{
		public override void Execute()
		{
			if (Shell.CurrentSettings != null)
			{
				Shell.CurrentSettings.GenerateCode();
				MessageBox.Show("Code generation completed successfully.", "Code Generation", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
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
