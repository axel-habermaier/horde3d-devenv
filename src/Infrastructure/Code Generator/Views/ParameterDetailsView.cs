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
	public partial class ParameterDetailsView : UserControlView
	{
		public ParameterDetailsView()
		{
			InitializeComponent();
		}

		public TypeDetailsView TypeView
		{
			set
			{
				if (value != null)
				{
					value.Dock = DockStyle.Fill;
					typePanel.Controls.Add(value);
				}
				else
					typePanel.Controls.Clear();
			}
		}

		public Parameter Parameter
		{
			set 
			{ 
				parameterNameLabel.Text = value.Name;
				positionLabel.Text = value.Position.ToString();
			}
		}
	}
}
