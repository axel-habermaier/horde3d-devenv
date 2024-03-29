using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfClient.Infrastructure
{
	/// <summary>
	/// The states an application can be in.
	/// </summary>
	public enum ApplicationState
	{
		/// <summary>
		/// The application is currently running.
		/// </summary>
		Running,
		/// <summary>
		/// The application is currently stopped, i.e. there is currently no application process.
		/// </summary>
		Stopped,
		/// <summary>
		/// The application process is running, but the application is suspended.
		/// </summary>
		Suspended,
		/// <summary>
		/// There is currently no application loaded.
		/// </summary>
		Unloaded
	}

	#region State Changed Delegate and EventArgs
	/// <summary>
	/// Delegated used by the StateChanged event.
	/// </summary>
	/// <param name="sender">The event's source.</param>
	/// <param name="e">Further information associated with the event.</param>
	public delegate void StateChangedHandler(object sender, StateChangedEventArgs e);

	/// <summary>
	/// A class containing further details when the StateChanged event is handled.
	/// </summary>
	public class StateChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Gets the previous ApplicationState.
		/// </summary>
		public ApplicationState PreviousState { get; private set; }

		/// <summary>
		/// Gets the previous ApplicationState.
		/// </summary>
		public ApplicationState CurrentState { get; private set; }

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="previousState">The previous ApplicationState.</param>
		public StateChangedEventArgs(ApplicationState previousState, ApplicationState currentState)
		{
			PreviousState = previousState;
			CurrentState = currentState;
		}
	}
	#endregion
}
