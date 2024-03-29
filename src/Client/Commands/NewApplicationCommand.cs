using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms.Commands;

using Client.Presenters;
using Client.Models;
using Client.Views;

namespace Client.Commands
{
	class NewApplicationCommand : Command<DebuggerShell>
	{
		public override void Execute()
		{
			if (!Shell.CloseAllDocuments())
				return;

			var dialog = FileSystemDialog.Create(DialogType.SaveFile, "Create New Application Settings", ".h3dproj", "Horde3D Development Environment Application Files|*.h3dproj");
			dialog.Show();

			if (dialog.Canceled)
				return;

			var application = new Horde3DApplication();
			application.FilePath = dialog.SelectedPath;
			XmlSerializer<Horde3DApplication>.Serialize(application, application.FilePath);
			Shell.Application = application;

			Shell.RegisterPresenter(new ApplicationSettingsPresenter());
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
