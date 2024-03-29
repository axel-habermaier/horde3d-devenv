using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace Infrastructure.UserInterface
{
	/// <summary>
	/// This interface must be implemented by all views. It provides methods to forward user requests
	/// to the view's presenter as well as methods to manage the view's state.
	/// </summary>
	public interface IView
	{
		/// <summary>
		/// Disposes the view.
		/// </summary>
		void Dispose();

		/// <summary>
		/// Indicates whether the view has already been disposed.
		/// </summary>
		bool IsDisposed { get; }

		/// <summary>
		/// Gets the view's title.
		/// </summary>
		string Title { get; }

		/// <summary>
		/// Raised when the view has been removed from the shell.
		/// </summary>
		event EventHandler Removed;

		/// <summary>
		/// Raised when the view is about to be removed from the shell.
		/// </summary>
		event RemovingViewHandler Removing;

		/// <summary>
		/// Raised after the view has been loaded.
		/// </summary>
		event EventHandler Load;
	}

	/// <summary>
	/// Delegate used by the views to inform the presenter about user requests.
	/// </summary>
	public delegate void RequestHandler();

	/// <summary>
	/// Delegate used by the views to inform the presenter about user requests.
	/// </summary>
	/// <param name="requestData">The data object associated with the user request.</param>
	public delegate void RequestHandler<T>(T requestData);

	/// <summary>
	/// Delegate used by the views to inform the presenter about user requests.
	/// </summary>
	/// <param name="requestData1">The first data object associated with the user request.</param>
	/// <param name="requestData2">The second data object associated with the user request.</param>
	public delegate void RequestHandler<T1, T2>(T1 requestData1, T2 requestData2);

	/// <summary>
	/// Delegate used by the views to inform the presenter about user requests.
	/// </summary>
	/// <param name="requestData1">The first data object associated with the user request.</param>
	/// <param name="requestData2">The second data object associated with the user request.</param>
	/// <param name="requestData3">The third data object associated with the user request.</param>
	public delegate void RequestHandler<T1, T2, T3>(T1 requestData1, T2 requestData2, T3 requestData3);

	/// <summary>
	/// Delegate used by the Removing event.
	/// </summary>
	/// <param name="sender">The view that generated the event.</param>
	/// <param name="e">Additional information about the event.</param>
	public delegate void RemovingViewHandler(object sender, RemovingViewEventArgs e);

	public class RemovingViewEventArgs : EventArgs
	{
		/// <summary>
		/// Indicates whether the removal of the view should be aborted.
		/// </summary>
		public bool Cancel { get; set; }
	}
}
