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
	public partial class SamplerView : UserControlView
	{
		public SamplerView()
		{
			InitializeComponent();

			addressModeComboBox.DataSource = Enum.GetValues(typeof(AddressMode));
			filteringModeComboBox.DataSource = Enum.GetValues(typeof(FilteringMode));
		}

		ShaderSampler sampler;
		public ShaderSampler Sampler
		{
			set
			{
				sampler = value;
				group.ValuesPrimary.Heading = "Sampler '" + sampler.Name + "'";
				samplerBindingSource.DataSource = sampler;
				stageConfigBindingSource.DataSource = sampler.StageConfig;
			}
		}
	}
}
