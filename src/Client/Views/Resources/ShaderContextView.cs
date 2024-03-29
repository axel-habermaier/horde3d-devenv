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
	public partial class ShaderContextView : UserControlView
	{
		public ShaderContextView()
		{
			InitializeComponent();

			blendModeComboBox.DataSource = Enum.GetValues(typeof(BlendMode));
			alphaTestComboBox.DataSource = Enum.GetValues(typeof(TestFunction));
			depthTestComboBox.DataSource = Enum.GetValues(typeof(TestFunction));
		}

		public ShaderContext ShaderContext
		{
			set
			{
				contextBindingSource.DataSource = value;
				renderConfigBindingSource.DataSource = value.RenderConfig;
				group.ValuesPrimary.Heading = "Context '" + value.Name + "'";
			}
		}

		UserControlView vertexShaderView;
		public UserControlView VertexShaderSectionView
		{
			set
			{
				if (vertexShaderView != null)
					splitContainer.Panel1.Controls.Remove(vertexShaderView);

				vertexShaderView = value;

				if (value == null)
					return;

				splitContainer.Panel1.Controls.Add(value);
				value.Dock = DockStyle.Fill;
			}
		}

		UserControlView fragmentShaderView;
		public UserControlView FragmentShaderSectionView
		{
			set
			{
				if (fragmentShaderView != null)
					splitContainer.Panel2.Controls.Remove(fragmentShaderView);

				fragmentShaderView = value;

				if (value == null)
					return;

				splitContainer.Panel2.Controls.Add(value);
				value.Dock = DockStyle.Fill;
			}
		}

		public bool ShowNoVertexShaderMessage
		{
			set
			{
				noVertexShaderGroup.Visible = value;
			}
		}

		public bool ShowNoFragmentShaderMessage
		{
			set
			{
				noFragmentShaderGroup.Visible = value;
			}
		}
	}
}
