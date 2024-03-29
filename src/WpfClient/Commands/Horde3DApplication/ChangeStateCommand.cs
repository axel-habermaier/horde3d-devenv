using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;

namespace WpfClient.Commands.Horde3DApplication
{
	class ChangeStateCommand : Command
	{
		protected override void OnExecute(object parameter)
		{
			var state = ApplicationState.Unloaded;
			try { state = (ApplicationState)parameter; }
			catch (InvalidCastException) { throw new ArgumentException("Invalid parameter. Expected an ApplicationState value."); }

			DebuggerClient.State = state;
		}

		protected override bool OnCanExecute(object parameter)
		{
			return true;
		}
	}
}
