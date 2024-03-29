using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Infrastructure.CodeGenerator.Logic;
using Infrastructure.UserInterface.WinForms.Commands;

namespace Infrastructure.CodeGenerator.Commands
{
	class LoadSettingsCommand : Command<CodeGeneratorShell>
	{
		public override void Execute()
		{
			var ask = new AskToSaveCommand();
			HandleCommand(ask);

			if (!ask.Cancel)
			{
				var loadSettingsDialog = new OpenFileDialog();
				loadSettingsDialog.AddExtension = true;
				loadSettingsDialog.CheckPathExists = true;
				loadSettingsDialog.DefaultExt = ".codegen";
				loadSettingsDialog.DereferenceLinks = true;
				loadSettingsDialog.Filter = "Code Generator Settings File|*.codegen";

				if (loadSettingsDialog.ShowDialog() == DialogResult.OK)
				{
					var settings = CodeGenerationSettings.LoadCodeGenerationSettings(loadSettingsDialog.FileName);
					Shell.CurrentSettings = settings;
				}
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
