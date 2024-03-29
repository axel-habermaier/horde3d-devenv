using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.CodeGenerator.Logic;
using System.Windows.Forms;
using Infrastructure.CodeGenerator.Presenters;
using Infrastructure.UserInterface.WinForms.Commands;

namespace Infrastructure.CodeGenerator.Commands
{
	class NewSettingsCommand : Command<CodeGeneratorShell>
	{
		public override void Execute()
		{
			var ask = new AskToSaveCommand();
			HandleCommand(ask);

			if (!ask.Cancel)
			{
				Shell.CurrentSettings = new CodeGenerationSettings();

				HandleCommand(new SaveSettingsAsCommand());
				Shell.RegisterPresenter(new SettingsDetailsPresenter());
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
