﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;

namespace WpfClient.Commands.Horde3DApplication
{
	public class StopCommand : StateDependentCommand
	{
		protected override bool CanExecuteAfterStateChange(ApplicationState currentState)
		{
			return currentState == ApplicationState.Running || currentState == ApplicationState.Suspended;
		}

		protected override void OnExecute(object parameter)
		{
			throw new NotImplementedException();
		}
	}
}
