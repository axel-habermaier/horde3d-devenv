using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;
using WpfClient.Infrastructure.UserInterface;

namespace WpfClient.Commands.Horde3DApplication
{
	public class LoadCommand : StateDependentCommand
	{
		protected override void OnExecute(object parameter)
		{
			var ask = new AskToSaveCommand();
			ask.Execute(parameter);

			if (ask.Canceled)
			{
				Canceled = true;
				return;
			}

			var selector = new FileSelector("Load Horde3D Application Settings", ".h3dproj", "Horde3D Application Settings|*.h3dproj", true);
			selector.Show();

			if (selector.Canceled)
				Canceled = true;
			else
			{
				DebuggerClient.Horde3DApplication = Infrastructure.Horde3DApplication.LoadHorde3DApplication(selector.FilePath);
				DebuggerClient.State = ApplicationState.Stopped;
				DebuggerClient.Shell.ApplicationName = DebuggerClient.Horde3DApplication.Name;
			}
		}

		protected override bool CanExecuteAfterStateChange(ApplicationState currentState)
		{
			return currentState == ApplicationState.Unloaded || currentState == ApplicationState.Stopped;
		}
	}
}
