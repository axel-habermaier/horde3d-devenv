using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.UserInterface;
using System.Threading;

namespace Client.Views
{
	public partial class AboutView : FormView
	{
		public AboutView()
		{
			InitializeComponent();
			Icon = Icon.FromHandle(Properties.Resources.Logo.GetHicon());
		}

		public override string Title
		{
			get { return "About Horde3D Development Environment"; }
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
