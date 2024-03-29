using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/// <summary>
/// This class supports events are not raised immediately, but rather after a specified delay.
/// </summary>
/// <typeparam name="T">The type of the event arguments.</typeparam>
public class DelayedEventRaiser<TEventArgs> where TEventArgs : EventArgs
{
	/// <summary>
	/// The timer used to delay the event invocation.
	/// </summary>
	private Timer Timer;

	/// <summary>
	/// Initializes an instance.
	/// </summary>
	public DelayedEventRaiser(Func<TEventArgs> createEventArgs)
	{
		Timer = new Timer(o =>
		{
			if (DelayElapsed != null)
				DelayElapsed(this, createEventArgs());
		}, null, Timeout.Infinite, Timeout.Infinite);
	}

	/// <summary>
	/// Raised after the delay has elapsed.
	/// </summary>
	public event EventHandler<TEventArgs> DelayElapsed;

	/// <summary>
	/// Raises the GraphChanged event after waiting the given amount of milliseconds. Call this method
	/// again to reset the timer.
	/// </summary>
	/// <param name="delay">Amount of milliseconds to wait before raising the event.</param>
	public void RaiseEvent(int delay)
	{
		lock (Timer)
			Timer.Change(delay, Timeout.Infinite);
	}
}