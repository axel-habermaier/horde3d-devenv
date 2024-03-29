using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;
using WpfClient.Infrastructure.UserInterface;

namespace WpfClient.Commands.Horde3DApplication
{
	class AskToSaveCommand : Command
	{
		protected override bool OnCanExecute(object parameter)
		{
			return DebuggerClient.Horde3DApplication != null;
		}

		protected override void OnExecute(object parameter)
		{
			if (DebuggerClient.Horde3DApplication != null && DebuggerClient.ApplicationSettings.IsDirty)
			{
				if (MessageBox.Ask("Do you want to save the current changes?", "Save Changes?"))
				{
					var save = new SaveCommand();
					save.Execute(parameter);
					Canceled = save.Canceled;
				}
			}
		}
	}
}
