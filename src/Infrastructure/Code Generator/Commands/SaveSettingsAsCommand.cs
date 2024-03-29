using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms.Commands;

namespace Infrastructure.CodeGenerator.Commands
{
	class SaveSettingsAsCommand : Command<CodeGeneratorShell>
	{
		public bool Cancel { get; set; }

		public override void Execute()
		{
			if (Shell.CurrentSettings != null)
			{
				Cancel = false;

				var saveSettingsDialog = new SaveFileDialog();
				saveSettingsDialog.AddExtension = true;
				saveSettingsDialog.CheckPathExists = true;
				saveSettingsDialog.DefaultExt = ".codegen";
				saveSettingsDialog.DereferenceLinks = true;
				saveSettingsDialog.Filter = "Code Generator Settings File|*.codegen";

				if (saveSettingsDialog.ShowDialog() == DialogResult.OK)
				{
					Shell.CurrentSettings.SaveCodeGenerationSettings(saveSettingsDialog.FileName);
					Shell.CurrentSettings = Shell.CurrentSettings;
				}
				else
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
