using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms.Commands;

using System.IO;
using System.Windows.Forms;
using Infrastructure.Core.Communication;
using Client.Models;

namespace Client.Commands
{
	class StartApplicationCommand : Command<DebuggerShell>
	{
		public override void Execute()
		{
			try
			{
				if (DebuggerShell.Current.State == ApplicationState.Stopped)
				{
					// Save app settings, if the app settings view is open
					Shell.SaveApplicationSettings();
					Shell.ResourceGraph.Clear();
					Shell.SceneGraph.Clear();

					DebuggerShell.Current.Application.Launch(DebuggerShell.Current.CallbackHandler);
				}
				else if (DebuggerShell.Current.State == ApplicationState.Suspended)
					DebuggerShell.Current.Application.Resume();
			}
			catch (IOException e)
			{
				MessageBox.Show("There was an error during a file operation. Please check if there is an another process already accessing this file (maybe the application is already running?)." + Environment.NewLine + Environment.NewLine + "Details: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				HandleCommand(new StopApplicationCommand());
			}
			catch (ArgumentException e)
			{
				MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				HandleCommand(new StopApplicationCommand());
			}
		}

		public override bool CanRedo
		{
			get { return false; }
		}

		public override bool CanUndo
		{
			get { return false; }
		}
	}
}
