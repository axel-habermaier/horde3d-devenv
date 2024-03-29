using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms.Commands;
using System.Windows.Forms;

using Infrastructure.UserInterface.WinForms;
using Client.Presenters;
using Client.Models;

namespace Client.Commands
{
	class ExitCommand : Command<DebuggerShell>
	{
		public override void Execute()
		{
			if (!Shell.CloseAllDocuments())
				return;

			if (DebuggerShell.Current.State == ApplicationState.Running || DebuggerShell.Current.State == ApplicationState.Suspended)
				DebuggerShell.Current.Application.ShutDown();

			try { Shell.PersistLayout(); }
			catch (Exception e) { DebuggerShell.Current.MessagesDispatcher.AddSystemDebugMessage("Saving UI layout failed: " + e.Message); }

			Application.Exit();
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
