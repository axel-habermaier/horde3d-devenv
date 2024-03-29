using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;

namespace WpfClient.Commands.Shell
{
	public class ExitCommand : Command
	{
		protected override void OnExecute(object parameter)
		{
			DebuggerClient.Shutdown();
		}

		protected override bool OnCanExecute(object parameter)
		{
			return true;
		}
	}
}
