using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms.Commands;
using Client.Presenters;

namespace Client.Commands
{
	class ChangeTextEditorTextCommand : Command<DebuggerShell>
	{
		TextEditorPresenter textEditor = null;

		public ChangeTextEditorTextCommand(TextEditorPresenter textEditor)
		{
			this.textEditor = textEditor;
		}

		public override void Execute()
		{
			// Nothing to do here!
		}

		public override void Undo()
		{
			textEditor.Undo();
		}

		public override void Redo()
		{
			textEditor.Redo();
		}
	}
}
