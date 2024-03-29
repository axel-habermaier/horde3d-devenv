using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.CodeGenerator.Logic;

namespace Infrastructure.CodeGenerator.Views
{
	public partial class SettingsDetailsView : DocumentView
	{
		public SettingsDetailsView()
			: base()
		{
			InitializeComponent();
			Icon = Icon.FromHandle(Properties.Resources.Properties.GetHicon());
		}

		public override string Title
		{
			get { return "Code Generation Settings"; }
		}

		public CodeGenerationSettings Settings
		{
			set
			{
				bindingSource.DataSource = value;
			}
		}

		private void cppButton_Click(object sender, EventArgs e)
		{
			if (cppFileDialog.ShowDialog() == DialogResult.OK)
				cppTextBox.Text = cppFileDialog.FileName;
		}

		private void csharpButton_Click(object sender, EventArgs e)
		{
			if (csharpFileDialog.ShowDialog() == DialogResult.OK)
				csharpTextBox.Text = csharpFileDialog.FileName;
		}
	}
}
