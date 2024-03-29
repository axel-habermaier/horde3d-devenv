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

namespace Infrastructure.CodeGenerator.Views
{
	public partial class AboutView : FormView
	{
		public AboutView()
		{
			InitializeComponent();
			Icon = Icon.FromHandle(Properties.Resources.Code.GetHicon());
		}

		public override string Title
		{
			get { return "About Code Generator"; }
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
