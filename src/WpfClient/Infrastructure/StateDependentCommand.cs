using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Commands.Horde3DApplication;

namespace WpfClient.Infrastructure
{
	public abstract class StateDependentCommand : Command
	{
		public StateDependentCommand()
		{
			// FIXME: This might cause memory leaks. StateDependentCommand never unregisters from the StateChanged
			// event and the StateDepenentCommand's lifetime is probably shorter than DebuggerClient's lifetime.
			// TODO: Implement WeakEvent pattern or find a meaningful way to unregister from the event.
			DebuggerClient.StateChanged += OnStateChanged;

			canExecute = CanExecuteAfterStateChange(DebuggerClient.State);
		}

		/// <summary>
		/// This method is called to determine if the command can still be executed after a state change. This must
		/// be implemented by deriving classes.
		/// </summary>
		/// <param name="currentState">The current application state.</param>
		/// <returns>Returns true if the command may be executed, otherwise false.</returns>
		protected abstract bool CanExecuteAfterStateChange(ApplicationState currentState);

		private void OnStateChanged(object sender, StateChangedEventArgs e)
		{
			var oldCanExecute = canExecute;
			canExecute = CanExecuteAfterStateChange(e.CurrentState);

			if (oldCanExecute != canExecute) 
				OnCanExecuteChanged();
		}

		protected override bool OnCanExecute(object parameter)
		{
			canExecute = CanExecuteAfterStateChange(DebuggerClient.State);
			return canExecute;
		}
	}
}
