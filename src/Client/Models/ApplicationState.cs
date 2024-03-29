using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Models
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

	#region Application State Changed Delegate and EventArgs
	/// <summary>
	/// Delegated used by the ApplicationStateChanged event.
	/// </summary>
	/// <param name="sender">The event's source.</param>
	/// <param name="e">Further information associated with the event.</param>
	public delegate void ApplicationStateChangedHandler(object sender, ApplicationStateChangedEventArgs e);

	/// <summary>
	/// A class containing further details when the ApplicationStateChanged event is handled.
	/// </summary>
	public class ApplicationStateChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Gets the previous ApplicationState.
		/// </summary>
		public ApplicationState PreviousState { get; private set; }

		/// <summary>
		/// Gets the current ApplicationState.
		/// </summary>
		public ApplicationState CurrentState { get; private set; }

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="previousState">The previous ApplicationState.</param>
		/// <param name="currentState">The current ApplicationState.</param>
		public ApplicationStateChangedEventArgs(ApplicationState previousState, ApplicationState currentState)
		{
			PreviousState = previousState;
			CurrentState = currentState;
		}
	}
	#endregion
}
