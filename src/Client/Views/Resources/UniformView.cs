using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.Core.Resources;

namespace Client.Views.Resources
{
	public partial class UniformView : UserControlView
	{
		public UniformView()
		{
			InitializeComponent();
		}

		ShaderUniform uniform;

		public ShaderUniform Uniform
		{
			set
			{
				uniform = value;
				group.ValuesPrimary.Heading = "Uniform '" + uniform.Name + "'";
				bindingSource.DataSource = value;
			}
		}
	}
}
