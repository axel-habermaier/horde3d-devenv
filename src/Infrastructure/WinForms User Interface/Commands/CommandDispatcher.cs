using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.UserInterface.WinForms.Commands
{
	/// <summary>
	/// The CommandDispatcher is responsible for executing commands and for storing them for
	/// undo/redo operations.
	/// </summary>
	/// <typeparam name="TShell">The type of the shell the command dispatcher belongs to.</typeparam>
	public class CommandDispatcher<TShell>
		where TShell : Shell<TShell>
	{
		#region StackList
		/// <summary>
		/// A list that supports stack-like push/pop operations.
		/// </summary>
		/// <typeparam name="T">The type of the stack list's elements.</typeparam>
		private class StackList<T> : List<T>
		{
			/// <summary>
			/// Inserts the given item to the top of the stack.
			/// </summary>
			/// <param name="item">The item that should be added.</param>
			public void Push(T item)
			{
				Add(item);
			}

			/// <summary>
			/// Removes and returns the item at the top of the stack.
			/// </summary>
			/// <returns>Returns the item at the top of the stack.</returns>
			public T Pop()
			{
				if (Count == 0)
					throw new InvalidOperationException("The stack is empty.");

				var item = this[Count - 1];
				Remove(item);
				return item;
			}
		}
		#endregion

		/// <summary>
		/// Stack of commands that can be undone.
		/// </summary>
		private StackList<Command<TShell>> UndoCommands { get; set; }

		/// <summary>
		/// Stack of commands that can be redone.
		/// </summary>
		private StackList<Command<TShell>> RedoCommands { get; set; }

		/// <summary>
		/// Raised when the CanUndo property has changed.
		/// </summary>
		public event EventHandler CanUndoChanged;

		/// <summary>
		/// Raised when the CanRedo property has changed.
		/// </summary>
		public event EventHandler CanRedoChanged;

		/// <summary>
		/// Raised when a command has been redone.
		/// </summary>
		public event EventHandler Redone;

		/// <summary>
		/// Raised when a command has been undone.
		/// </summary>
		public event EventHandler Undone;

		/// <summary>
		/// Indicates whether an undo/redo operation is in progress. If so, the undo/redo stack are not
		/// changed even when an undo-able command is handled.
		/// </summary>
		private bool acceptChanges = true;

		bool canRedo = false;
		/// <summary>
		/// Indicates whether there currently is a command that can be redone.
		/// </summary>
		public bool CanRedo
		{
			get { return canRedo; }
			set
			{
				if (canRedo != value)
				{
					canRedo = value;
					if (CanRedoChanged != null)
						CanRedoChanged(this, EventArgs.Empty);
				}
			}
		}

		bool canUndo = false;
		/// <summary>
		/// Indicates whether there currently is a command that can be undone.
		/// </summary>
		public bool CanUndo
		{
			get { return canUndo; }
			set
			{
				if (canUndo != value)
				{
					canUndo = value;
					if (CanUndoChanged != null)
						CanUndoChanged(this, EventArgs.Empty);
				}
			}
		}

		/// <summary>
		/// Constructs a new CommandDispatcher instance.
		/// </summary>
		internal CommandDispatcher()
		{
			UndoCommands = new StackList<Command<TShell>>();
			RedoCommands = new StackList<Command<TShell>>();
		}

		/// <summary>
		/// Updates the CanUndo and CanRedo properties.
		/// </summary>
		private void UpdateStatus()
		{
			CanUndo = UndoCommands.Count != 0;
			CanRedo = RedoCommands.Count != 0;
		}

		/// <summary>
		/// Handles the given command.
		/// </summary>
		/// <param name="presenter">The presenter that issued the command.</param>
		/// <param name="command">The command that should be handled.</param>
		internal void HandleCommand(Presenter<TShell> presenter, Command<TShell> command)
		{
			if (!command.CanUndo && command.CanRedo)
				throw new ArgumentException("Invalid undo/redo configuration: The command '" + command.GetType().FullName + "' cannot be undone, but can be redone.");

			command.Presenter = presenter;
			command.Execute();

			// We have to clear the redo commands now.
			if (acceptChanges)
				RedoCommands.Clear();

			if (acceptChanges && command.CanUndo)
				UndoCommands.Push(command);

			UpdateStatus();
		}

		/// <summary>
		/// Removes all commands stored in the redo/undo stacks issued by the given presenter.
		/// </summary>
		/// <param name="presenter">All commands issued by this presenter will be removed from the undo/redo stacks.</param>
		internal void RemovePresenterCommands(Presenter<TShell> presenter)
		{
			if (presenter == null)
				throw new ArgumentNullException("presenter");

			UndoCommands.RemoveAll(c => c.Presenter == presenter);
			RedoCommands.RemoveAll(c => c.Presenter == presenter);
			UpdateStatus();
		}

		/// <summary>
		/// Undoes the command on top of the undo stack.
		/// </summary>
		public void Undo()
		{
			if (!CanUndo)
				throw new InvalidOperationException("Currently, there is no command to undo.");

			acceptChanges = false;
			var command = UndoCommands.Pop();
			command.Undo();
			acceptChanges = true;
			command.Presenter.Shell.Focus(command.Presenter);

			if (Undone != null)
				Undone(this, EventArgs.Empty);

			if (command.CanRedo)
			{
				RedoCommands.Push(command);
				CanRedo = true;
			}

			UpdateStatus();
		}

		/// <summary>
		/// Redoes the command on top of the redo stack.
		/// </summary>
		public void Redo()
		{
			if (!CanRedo)
				throw new InvalidOperationException("Currently, there is no command to redo.");

			acceptChanges = false;
			var command = RedoCommands.Pop();
			command.Redo();
			acceptChanges = true;
			command.Presenter.Shell.Focus(command.Presenter);

			if (Redone != null)
				Redone(this, EventArgs.Empty);

			// If we can redo the command, we can also undo it.
			UndoCommands.Push(command);

			UpdateStatus();
		}
	}
}