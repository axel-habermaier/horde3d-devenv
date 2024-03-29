using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.Misc;
using System.Collections.ObjectModel;

namespace Client.Models
{
	class ProfilingDataManager
	{
		/// <summary>
		/// Time to wait after the last change before raising the ResourceGraphChanged event.
		/// </summary>
		const int DelayTimeInMilliseconds = 300;

		/// <summary>
		/// List of all function calls.
		/// </summary>
		private List<FunctionCall> functionCalls = new List<FunctionCall>();

		/// <summary>
		/// Used to delay the invocation of the ProfilingDataChanged event.
		/// </summary>
		private DelayedEventRaiser<ProfilingDataChangedEventArgs> delayedEvent;

		/// <summary>
		/// Gets the profiling data.
		/// </summary>
		public ReadOnlyCollection<FunctionCall> ProfilingData
		{
			get
			{ 
				lock (functionCalls)
					return functionCalls.AsReadOnly(); 
			}
		}

		/// <summary>
		/// Raised when the profiling data has changed.
		/// </summary>
		public event EventHandler<ProfilingDataChangedEventArgs> ProfilingDataChanged
		{
			add { delayedEvent.DelayElapsed += value; }
			remove { delayedEvent.DelayElapsed -= value; }
		}

		public ProfilingDataManager()
		{
			DebuggerShell.Current.CallbackHandler.FunctionCallAdded += AddFunctionCall;
			delayedEvent = new DelayedEventRaiser<ProfilingDataChangedEventArgs>(() => new ProfilingDataChangedEventArgs(ProfilingData));
		}

		/// <summary>
		/// Adds the given function call.
		/// </summary>
		private void AddFunctionCall(object sender, FunctionCallAddedEventArgs e)
		{
			lock (functionCalls)
				functionCalls.Add(e.FunctionCall);
			delayedEvent.RaiseEvent(DelayTimeInMilliseconds);
		}

		/// <summary>
		/// Clears all function calls.
		/// </summary>
		public void Clear()
		{
			lock (functionCalls)
				functionCalls.Clear();
			delayedEvent.RaiseEvent(DelayTimeInMilliseconds);
		}
	}

	#region Delegates and EventArgs
	/// <summary>
	/// A class containing further details when the ProfilingDataChanged event is handled.
	/// </summary>
	public class ProfilingDataChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Gets the function calls list.
		/// </summary>
		public ReadOnlyCollection<FunctionCall> FunctionCalls { get; private set; }

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="functionCalls">The function calls list.</param>
		public ProfilingDataChangedEventArgs(ReadOnlyCollection<FunctionCall> functionCalls)
		{
			FunctionCalls = functionCalls;
		}
	}
	#endregion
}
