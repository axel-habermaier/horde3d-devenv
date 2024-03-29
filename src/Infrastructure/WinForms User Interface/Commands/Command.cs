using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.UserInterface.WinForms.Commands
{
	/// <summary>
	/// The base class for a command (Command Pattern).
	/// </summary>
	/// <typeparam name="TShell">The type of the shell this command belongs to.</typeparam>
	public abstract class Command<TShell>
		where TShell : Shell<TShell>
	{
		/// <summary>
		/// Indicates whether the command supports undoing. True by default.
		/// </summary>
		public virtual bool CanUndo 
		{
			get { return true; }
		}

		/// <summary>
		/// Indicates whether the command supports redoing. True by default.
		/// </summary>
		public virtual bool CanRedo 
		{
			get { return true; }
		}

		/// <summary>
		/// Gets or sets the presenter that issued the command.
		/// </summary>
		internal Presenter<TShell> Presenter { get; set; }

		/// <summary>
		/// Uses the command dispatcher to handle the given command.
		/// </summary>
		/// <param name="command">The command to handle.</param>
		protected void HandleCommand(Command<TShell> command)
		{
			Shell.CommandDispatcher.HandleCommand(Presenter, command);
		}

		/// <summary>
		/// The shell this command belongs to.
		/// </summary>
		public TShell Shell 
		{
			get { return Presenter.Shell; }
		}

		/// <summary>
		/// Executes the command.
		/// </summary>
		public abstract void Execute();

		/// <summary>
		/// Reverts the effects of the command.
		/// </summary>
		public virtual void Undo() 
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Undoes an undo operation of the command. The standard implementation just calls
		/// Execute again. Can be overridden in deriving classes if other actions need
		/// to be taken in case of a redo. 
		/// </summary>
		public virtual void Redo()
		{
			Execute();
		}
	}
}
