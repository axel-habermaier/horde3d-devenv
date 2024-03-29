using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;
using WpfClient.Infrastructure.UserInterface;

namespace WpfClient.Commands.Horde3DApplication
{
	public class SaveAsCommand : StateDependentCommand
	{
		protected override void OnExecute(object parameter)
		{
			var title = "Save Horde3D Application Settings As";
			if (parameter.ToString() == "NewCommand")
				title = "Select the location of the new Horde3D Application Settings";

			var selector = new FileSelector(title, ".h3dproj", "Horde3D Application Settings|*.h3dproj", false);
			selector.Show();

			if (selector.Canceled)
				Canceled = true;
			else
			{
				DebuggerClient.Horde3DApplication.SaveHorde3DApplication(selector.FilePath);
				DebuggerClient.Shell.ApplicationName = DebuggerClient.Horde3DApplication.Name;
				DebuggerClient.ApplicationSettings.IsDirty = false;
			}
		}

		protected override bool CanExecuteAfterStateChange(ApplicationState currentState)
		{
			return currentState == ApplicationState.Unloaded || currentState == ApplicationState.Stopped;
		}
	}
}
