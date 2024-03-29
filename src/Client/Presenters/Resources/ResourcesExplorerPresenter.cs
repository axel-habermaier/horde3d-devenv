using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views.Resources;
using Infrastructure.Core;
using Infrastructure.Core.Resources;
using Client.Commands;

namespace Client.Presenters.Resources
{
	class ResourcesExplorerPresenter : DebuggerPresenter<ResourcesExplorerView>
	{
		EventHandler<GraphChangedEventArgs<Resource>> resourceGraphChangedDelegate = null;

		public ResourcesExplorerPresenter()
		{
			resourceGraphChangedDelegate = new EventHandler<GraphChangedEventArgs<Resource>>(OnResourceGraphChanged);
		}

		protected override bool Initialize()
		{
			UpdateResources(Shell.ResourceGraph.Nodes);

			return base.Initialize();
		}

		private void UpdateResources(IEnumerable<Resource> resources)
		{
			DebuggerShell.Current.RunSync(() => UpdateView(view => view.UpdateResources(resources)));
		}

		protected override bool InitializeEvents()
		{
			DebuggerShell.Current.ResourceGraph.GraphChanged += resourceGraphChangedDelegate;
			UpdateView(view => view.ShowResourceDetailsRequest += resource => HandleCommand(new ShowResourceDetailsCommand(resource)));

			return base.InitializeEvents();
		}

		protected override void Release()
		{
			DebuggerShell.Current.ResourceGraph.GraphChanged -= resourceGraphChangedDelegate;

			base.Release();
		}

		private void OnResourceGraphChanged(object sender, GraphChangedEventArgs<Resource> e)
		{
			UpdateResources(e.Nodes);
		}
	}
}
