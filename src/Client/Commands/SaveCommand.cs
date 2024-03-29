using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms.Commands;
using Client.Models;

namespace Client.Commands
{
	class SaveCommand : Command<DebuggerShell>
	{
		public bool Cancel { get; set; }

		private bool saveAll = false;

		public SaveCommand(bool saveAll)
		{
			this.saveAll = saveAll;
		}

		public override void Execute()
		{
			Cancel = Shell.SaveDocuments(saveAll);
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
