using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;
using WpfClient.Infrastructure.UserInterface;

namespace WpfClient.Commands.Horde3DApplication
{
	public class UnloadCommand : StateDependentCommand
	{
		protected override void OnExecute(object parameter)
		{
			var ask = new AskToSaveCommand();
			ask.Execute(parameter);

			if (!ask.Canceled)
			{
				DebuggerClient.Horde3DApplication = null;
				DebuggerClient.State = ApplicationState.Unloaded;
				DebuggerClient.Shell.ApplicationName = String.Empty;
			}
			else
				Canceled = true;
		}

		protected override bool CanExecuteAfterStateChange(ApplicationState currentState)
		{
			return currentState == ApplicationState.Unloaded || currentState == ApplicationState.Stopped;
		}
	}
}
