using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views.Resources;
using Infrastructure.Core;
using Infrastructure.Core.Resources;
using System.IO;
using System.Windows.Forms;
using Client.Models;

namespace Client.Presenters.Resources
{
	class RenderTargetsPresenter : DebuggerPresenter<RenderTargetsView>
	{
		PipelineResource currentPipeline;
		RenderTarget currentRenderTarget;
		int currentColorBufferIndex;

		Timer timer;
		int timerInterval = 1000;

		protected override bool UniqueName
		{
			get
			{
				return true;
			}
		}

		protected override bool Initialize()
		{
			UpdatePipelines(null, new GraphChangedEventArgs<Resource>(null));
			UpdateView(view => view.TimerInterval = timerInterval);
			timer = new Timer();
			timer.Enabled = false;
			timer.Tick += (o, e) => Shell.RunSync(() => UpdateRenderTargetData());

			return base.Initialize();
		}

		protected override bool InitializeEvents()
		{
			Shell.ResourceGraph.GraphChanged += UpdatePipelines;
			UpdateView(view => view.RenderTargetSelected += (p, rt, index) =>
			{
				currentPipeline = p;
				currentRenderTarget = rt;
				currentColorBufferIndex = index;

				UpdateRenderTargetData();
			});
			UpdateView(view => view.UpdateIntervalChanged += interval =>
			{
				timerInterval = interval;
				UpdateTimer();
			});
			Shell.ApplicationStateChanged += (o, e) => 
			{
				if (Shell.State == ApplicationState.Unloaded || Shell.State == ApplicationState.Stopped)
					Shell.UnregisterPresenter(this);
			};

			return base.InitializeEvents();
		}

		protected override void Release()
		{
			Shell.ResourceGraph.GraphChanged -= UpdatePipelines;
			timer.Stop();
			timer.Dispose();
			timer = null;

			base.Release();
		}

		private void UpdateTimer()
		{
			if (timer == null)
				return;

			timer.Interval = timerInterval;
			timer.Enabled = currentPipeline != null && currentRenderTarget != null && (Shell.State == ApplicationState.Running || Shell.State == ApplicationState.Suspended);
		}

		private void UpdatePipelines(object sender, GraphChangedEventArgs<Resource> e)
		{
			var pipelines = Shell.ResourceGraph.Nodes.OfType<PipelineResource>();
			pipelines.Foreach(p =>
			{
				try
				{
					using (var reader = new StreamReader(new FileStream(Path.Combine(Shell.Application.ContentDirectory, p.Name), FileMode.Open, FileAccess.Read)))
						p.FileContent = reader.ReadToEnd();
					p.LoadFromXml();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Unable to load pipeline '" + p.Name + "'. The following error occurred: " + ex.Message);
				}
			});
			UpdateView(view => view.Pipelines = pipelines.Where(p => p.RenderTargets != null && p.RenderTargets.Count > 0));
		}

		private void UpdateRenderTargetData()
		{
			timer.Stop();
			if (Shell.State == ApplicationState.Running || Shell.State == ApplicationState.Suspended)
			{
				Shell.Application.GetRenderTargetData(currentPipeline.ResHandle, currentRenderTarget.Name, currentColorBufferIndex, data =>
					{
						UpdateView(view => view.RenderTargetData = data);
						Shell.RunSync(() => UpdateTimer());
					});
			}
		}
	}
}
