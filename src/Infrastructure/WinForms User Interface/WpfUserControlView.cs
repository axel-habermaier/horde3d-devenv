using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using WeifenLuo.WinFormsUI.Docking;
using System.Drawing;

namespace Infrastructure.UserInterface.WinForms
{
	public partial class WpfUserControlView : UserControl
	{
		/// <summary>
		/// Gets the view's title.
		/// </summary>
		public virtual string Title
		{
			get { return String.Empty; }
		}

		/// <summary>
		/// Gets the view's default dock state. This state is used if the view is added to the shell
		/// and there is no stored state found. Can be overridden in deriving classes.
		/// </summary>
		public virtual DockState DefaultDockState
		{
			get { return DockState.DockLeft; }
		}

		/// <summary>
		/// Gets the view's allowed docking areas. Can be overridden in deriving classes.
		/// </summary>
		public virtual DockAreas AllowedDockAreas
		{
			get { return DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockBottom | DockAreas.DockTop | DockAreas.Float; }
		}

		/// <summary>
		/// Gets the view's icon.
		/// </summary>
		public virtual Icon Icon
		{
			get { return null; }
		}
	}
}
