using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms.Commands;

namespace Infrastructure.CodeGenerator.Commands
{
	class SaveSettingsCommand : Command<CodeGeneratorShell>
	{
		public bool Cancel { get; set; }

		public override void Execute()
		{
			Cancel = false;
			try
			{
				if (Shell.CurrentSettings != null)
					Shell.CurrentSettings.SaveCodeGenerationSettings(null);
			}
			catch (ArgumentNullException)
			{
				var saveAs = new SaveSettingsAsCommand();
				HandleCommand(saveAs);
				Cancel = saveAs.Cancel;
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
