using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;

namespace WpfClient.Commands.Horde3DApplication
{
	public class ShowSettingsCommand : StateDependentCommand
	{
		protected override bool CanExecuteAfterStateChange(ApplicationState currentState)
		{
			return currentState != ApplicationState.Unloaded;
		}

		protected override void OnExecute(object parameter)
		{
			DebuggerClient.Shell.DocumentModels.Add(DebuggerClient.ApplicationSettings);
		}
	}
}
