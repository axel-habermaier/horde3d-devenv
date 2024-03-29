using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms.Commands;

namespace Infrastructure.CodeGenerator.Commands
{
	class ExitCommand : Command<CodeGeneratorShell>
	{
		public bool Cancel { get; private set; }

		public override void Execute()
		{
			Cancel = false;

			var ask = new AskToSaveCommand();
			HandleCommand(ask);

			if (!ask.Cancel)
			{
				Properties.Settings.Default.LastSettings = Shell.CurrentSettings == null ? String.Empty : Shell.CurrentSettings.SettingsFilePath;
				Properties.Settings.Default.Save();

				Application.Exit();
			}
			else
				Cancel = true;
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
