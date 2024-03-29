using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace Infrastructure.UserInterface.WinForms
{
	public class DocumentView : DockView
	{
		public override DockAreas AllowedDockAreas
		{
			get { return DockAreas.Document; }
		}

		public override DockState DefaultDockState
		{
			get { return DockState.Document; }
		}

		protected int MaxTitleLength
		{
			get { return 30; }
		}
	}
}
