using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using WeifenLuo.WinFormsUI.Docking;

namespace Infrastructure.UserInterface.WinForms
{
	public partial class WpfDockView<TWpfUserControl> : DockView
		where TWpfUserControl : WpfUserControlView, new()
	{
		TWpfUserControl wpfControl = new TWpfUserControl();

		public WpfDockView()
		{
			InitializeComponent();

			wpfHost.Child = wpfControl;
			Icon = wpfControl.Icon;

			// Convert WinForms font settings to Wpf font settings.
			wpfControl.FontFamily = new System.Windows.Media.FontFamily(StandardFont.FontFamily.Name);
			wpfControl.FontSize = StandardFont.Size / 0.75;
		}

		/// <summary>
		/// Sets the Wpf user control's data context.
		/// </summary>
		public object DataContext
		{
			set { wpfControl.DataContext = value; }
		}

		/// <summary>
		/// Gets the view's title.
		/// </summary>
		public override string Title
		{
			get { return wpfControl.Title; }
		}

		/// <summary>
		/// Gets the view's default dock state. This state is used if the view is added to the shell
		/// and there is no stored state found. Can be overridden in deriving classes.
		/// </summary>
		public override DockState DefaultDockState
		{
			get { return wpfControl.DefaultDockState; }
		}

		/// <summary>
		/// Gets the view's allowed docking areas. Can be overridden in deriving classes.
		/// </summary>
		public override DockAreas AllowedDockAreas
		{
			get { return wpfControl.AllowedDockAreas; }
		}
	}
}
