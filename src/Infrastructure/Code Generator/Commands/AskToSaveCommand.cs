using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms.Commands;

namespace Infrastructure.CodeGenerator.Commands
{
	class AskToSaveCommand : Command<CodeGeneratorShell>
	{
		public bool Cancel { get; private set; }

		public override void Execute()
		{
			Cancel = false;

			if (Shell.CurrentSettings != null)
			{
				var Result = MessageBox.Show("Do you want to save the current code generation settings?", "Save Settings", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				if (Result == DialogResult.Yes)
				{
					var save = new SaveSettingsCommand();
					HandleCommand(save);
					Cancel = save.Cancel;
				}
				else if (Result == DialogResult.Cancel)
					Cancel = true;
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
