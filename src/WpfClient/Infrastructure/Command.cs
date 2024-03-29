using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics;

namespace WpfClient.Infrastructure
{
	public abstract class Command : ICommand
	{
		#region CanExecute Implementation
		protected bool canExecute = false;
		/// <summary>
		/// Checks whether the command can currently be executed.
		/// </summary>
		/// <param name="parameter">State information.</param>
		/// <returns>Returns true if the command can currently be executed.</returns>
		public bool CanExecute(object parameter)
		{
			return OnCanExecute(parameter);
		}

		/// <summary>
		/// This method is called to determine whether the command can currently be executed. 
		/// It should be overridden by deriving classes. The default implementation returns false.
		/// </summary>
		/// <param name="parameter">State information.</param>
		/// <returns>Returns true if the command can currently be executed.</returns>
		protected virtual bool OnCanExecute(object parameter)
		{
			return canExecute;
		}

		/// <summary>
		/// Raised when the CanExecute status changed.
		/// </summary>
		public event EventHandler CanExecuteChanged;

		/// <summary>
		/// Raises the CanExecuteChanged event.
		/// </summary>
		protected void OnCanExecuteChanged()
		{
			if (CanExecuteChanged != null)
				CanExecuteChanged(this, EventArgs.Empty);
		}
		#endregion

		/// <summary>
		/// Indicates whether the command execution was canceled.
		/// </summary>
		public bool Canceled { get; protected set; }

		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="parameter">State information.</param>
		public void Execute(object parameter)
		{
			Debug.Assert(CanExecute(parameter) == true, "Trying to execute a command that currently cannot be executed.");
			Canceled = false;
			OnExecute(parameter);
		}

		/// <summary>
		/// This method is called when the command is executed and must be implemented by
		/// deriving classes.
		/// </summary>
		/// <param name="parameter">State information.</param>
		protected abstract void OnExecute(object parameter);

		/// <summary>
		/// Gets the current DebuggerClient instance.
		/// </summary>
		protected DebuggerClient DebuggerClient
		{
			get { return Application.Current as DebuggerClient; }
		}
	}
}
