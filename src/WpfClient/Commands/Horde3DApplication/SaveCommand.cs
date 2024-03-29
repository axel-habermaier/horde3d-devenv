using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;

namespace WpfClient.Commands.Horde3DApplication
{
	public class SaveCommand : StateDependentCommand
	{
		protected override void OnExecute(object parameter)
		{
			try
			{
				DebuggerClient.Horde3DApplication.SaveHorde3DApplication(null);
				DebuggerClient.ApplicationSettings.IsDirty = false;
			}
			catch (ArgumentNullException)
			{
				var saveAs = new SaveAsCommand();
				saveAs.Execute(parameter);
				Canceled = saveAs.Canceled;
			}
		}

		protected override bool CanExecuteAfterStateChange(ApplicationState currentState)
		{
			return currentState == ApplicationState.Stopped;
		}
	}
}
