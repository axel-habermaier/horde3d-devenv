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
using System.Collections.ObjectModel;
using Infrastructure.UserInterface;
using System.IO;
using System.Drawing.Imaging;

namespace Client.Views.Resources
{
	public partial class RenderTargetsView : DockView
	{
		public event RequestHandler<PipelineResource, RenderTarget, int> RenderTargetSelected;
		public event RequestHandler<int> UpdateIntervalChanged;

		public RenderTargetsView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.RenderTarget.GetHicon());
		}

		public override string Title
		{
			get
			{
				return "Render Targets Explorer";
			}
		}

		public override WeifenLuo.WinFormsUI.Docking.DockState DefaultDockState
		{
			get
			{
				return WeifenLuo.WinFormsUI.Docking.DockState.Float;
			}
		}

		public IEnumerable<PipelineResource> Pipelines
		{
			set
			{
				if (value == null || value.Count() == 0 || value.Where(p => p.RenderTargets.Any(rt => rt.NumColorBuffers != 0)).Count() == 0)
					return;

				renderTargetsButton.DropDownItems.Clear();

				foreach (var pipeline in value)
				{
					var pipelineItem = new ToolStripMenuItem(pipeline.Name);

					foreach (var renderTarget in pipeline.RenderTargets)
					{
						if (renderTarget.NumColorBuffers == 0)
							continue;

						var renderTargetItem = new ToolStripMenuItem(renderTarget.Name);
						pipelineItem.DropDownItems.Add(renderTargetItem);

						for (int i = 0; i < renderTarget.NumColorBuffers; ++i)
						{
							var colorBufferItem = new ToolStripMenuItem("Color Buffer " + i);
							HandleClickEvent(colorBufferItem, pipeline, renderTarget, i);
							renderTargetItem.DropDownItems.Add(colorBufferItem);
						}
					}

					if (pipelineItem.DropDownItems.Count > 0)
						renderTargetsButton.DropDownItems.Add(pipelineItem);
				}
			}
		}

		private void HandleClickEvent(ToolStripMenuItem item, PipelineResource pipeline, RenderTarget renderTarget, int colorBufferIndex)
		{
			item.Click += (o, e) =>
			{
				Request(RenderTargetSelected, pipeline, renderTarget, colorBufferIndex);
				var header = pipeline.Name + "//" + renderTarget.Name + ":" + colorBufferIndex;
				renderTargetsButton.Text = header;
				Text = header;
				ToolTipText = header;
				TabText = header;
			};
		}

		public byte[] RenderTargetData
		{
			set
			{
				if (value == null)
					return;

				// Important: This stream must not be closed!
				var stream = new MemoryStream(value);				
				var image = new Bitmap(stream);
				image.RotateFlip(RotateFlipType.RotateNoneFlipY);

				renderTargetData.Picture = image;
			}
		}

		private void updateIntervalComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (updateIntervalComboBox.SelectedIndex != -1)
				Request(UpdateIntervalChanged, Int32.Parse(updateIntervalComboBox.Items[updateIntervalComboBox.SelectedIndex].ToString()));
		}

		public int TimerInterval
		{
			set
			{
				for (int i = 0; i < updateIntervalComboBox.Items.Count; ++i)
				{
					if (updateIntervalComboBox.Items[i].ToString() == value.ToString())
					{
						updateIntervalComboBox.SelectedIndex = i;
						break;
					}
				}
			}
		}
	}
}
