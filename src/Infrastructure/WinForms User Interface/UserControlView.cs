using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using WeifenLuo.WinFormsUI.Docking;

namespace Infrastructure.UserInterface.WinForms
{
	/// <summary>
	/// Base class for all WinForms UserControl views.
	/// </summary>
	public partial class UserControlView : UserControl, IView
	{
		public UserControlView()
		{
			InitializeComponent();

			ControlRemoved += new ControlEventHandler(UserControlView_ControlRemoved);
		}

		void UserControlView_ControlRemoved(object sender, ControlEventArgs e)
		{
			var eventArgs = new RemovingViewEventArgs();
			if (Removing != null)
				Removing(this, eventArgs);

			if (eventArgs.Cancel)
				throw new InvalidOperationException("Cannot cancel the removal of a user control.");

			if (Removed != null) 
				Removed(this, EventArgs.Empty); 
		}

		/// <summary>
		/// Occurs when the view has been removed from the shell.
		/// </summary>
		public event EventHandler Removed;

		/// <summary>
		/// Raised when the view is about to be removed from the shell.
		/// </summary>
		public event RemovingViewHandler Removing;

		/// <summary>
		/// Sets the given control's text to the standard text font.
		/// </summary>
		/// <param name="control">The control whose font should be set.</param>
		protected static void SetStandardTextFont(System.Windows.Forms.Control control)
		{
			control.Font = StandardFont;
		}

		/// <summary>
		/// Gets the standard font that is used to render text.
		/// </summary>
		protected static Font StandardFont
		{
			get { return KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.LabelNormalControl, PaletteState.Normal); }
		}

		/// <summary>
		/// Gets the view's title.
		/// </summary>
		public virtual string Title
		{
			get { return String.Empty; }
		}

		/// <summary>
		/// Informs the view's presenter about a user request.
		/// </summary>
		/// <param name="request">The event that should be raised to inform the presenter.</param>
		public void Request(RequestHandler request)
		{
			if (request != null)
				request();
		}

		/// <summary>
		/// Informs the view's presenter about a user request.
		/// </summary>
		/// <typeparam name="T">The type of the data object.</typeparam>
		/// <param name="request">The event that should be raised to inform the presenter.</param>
		/// <param name="requestData">The data associated with the request.</param>
		public void Request<T>(RequestHandler<T> request, T requestData)
		{
			if (request != null)
				request(requestData);
		}

		/// <summary>
		/// Informs the view's presenter about a user request.
		/// </summary>
		/// <typeparam name="T1">The type of the first data object.</typeparam>
		/// <typeparam name="T2">The type of the second data object.</typeparam>
		/// <param name="request">The event that should be raised to inform the presenter.</param>
		/// <param name="requestData1">The first data object associated with the request.</param>
		/// <param name="requestData2">The second data object associated with the request.</param>
		public void Request<T1, T2>(RequestHandler<T1, T2> request, T1 requestData1, T2 requestData2)
		{
			if (request != null)
				request(requestData1, requestData2);
		}

		/// <summary>
		/// Informs the view's presenter about a user request.
		/// </summary>
		/// <typeparam name="T1">The type of the first data object.</typeparam>
		/// <typeparam name="T2">The type of the second data object.</typeparam>
		/// <typeparam name="T3">The type of the third data object.</typeparam>
		/// <param name="request">The event that should be raised to inform the presenter.</param>
		/// <param name="requestData1">The first data object associated with the request.</param>
		/// <param name="requestData2">The second data object associated with the request.</param>
		/// <param name="requestData3">The third data object associated with the request.</param>
		public void Request<T1, T2, T3>(RequestHandler<T1, T2, T3> request, T1 requestData1, T2 requestData2, T3 requestData3)
		{
			if (request != null)
				request(requestData1, requestData2, requestData3);
		}
	}
}
