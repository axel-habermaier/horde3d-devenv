using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Infrastructure.UserInterface.WinForms.Commands;
using System.Windows.Forms;
using System.IO;
using Client.Models;

namespace Client.Commands
{
	class StopApplicationCommand : Command<DebuggerShell>
	{
		public override void Execute()
		{
			try
			{
				if (DebuggerShell.Current.State == ApplicationState.Running || DebuggerShell.Current.State == ApplicationState.Suspended)
					DebuggerShell.Current.Application.ShutDown();
			}
			catch (IOException e)
			{
				MessageBox.Show("There was an error removing the files required by the debugger from the application directory: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (UnauthorizedAccessException e)
			{
				DebuggerShell.Current.MessagesDispatcher.AddDebugSessionWarning("There was an error removing the files required by the debugger from the application directory. An attempt might have been made to remove the files before the application was fully closed. No further attempts will be made to remove the files. Details: " + e.Message);
			}
			catch (Exception e)
			{
				MessageBox.Show("The application could not be stopped: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
