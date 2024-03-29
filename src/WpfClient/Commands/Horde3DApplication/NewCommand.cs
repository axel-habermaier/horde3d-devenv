using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;

namespace WpfClient.Commands.Horde3DApplication
{
	public class NewCommand : StateDependentCommand
	{
		protected override void OnExecute(object parameter)
		{
			if (DebuggerClient.Horde3DApplication != null)
			{
				var ask = new AskToSaveCommand();
				ask.Execute(parameter);
				Canceled = ask.Canceled;

				if (Canceled)
					return;
			}

			var oldApp = DebuggerClient.Horde3DApplication;
			DebuggerClient.Horde3DApplication = new Infrastructure.Horde3DApplication();
			DebuggerClient.State = ApplicationState.Stopped;

			var save = new SaveCommand();
			save.Execute("NewCommand");

			if (save.Canceled)
				DebuggerClient.Horde3DApplication = oldApp;

			if (DebuggerClient.Horde3DApplication == null)
				DebuggerClient.State = ApplicationState.Unloaded;
			else
				DebuggerClient.State = ApplicationState.Stopped;

			Canceled = save.Canceled;
		}

		protected override bool CanExecuteAfterStateChange(ApplicationState currentState)
		{
			return currentState == ApplicationState.Stopped || currentState == ApplicationState.Unloaded;
		}
	}
}
