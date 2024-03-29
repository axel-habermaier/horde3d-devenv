using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views.SceneNodes;
using Infrastructure.Core;
using Infrastructure.Core.SceneNodes;
using Client.Commands;

namespace Client.Presenters.SceneNodes
{
	class SceneGraphExplorerPresenter : DebuggerPresenter<SceneGraphExplorerView>
	{
		EventHandler<GraphChangedEventArgs<SceneNode>> sceneGraphChangedDelegate = null;

		public SceneGraphExplorerPresenter()
		{
			sceneGraphChangedDelegate = new EventHandler<GraphChangedEventArgs<SceneNode>>(OnSceneNodeAdded);
		}

		protected override bool Initialize()
		{
			UpdateSceneNodes(Shell.SceneGraph.Nodes);

			return base.Initialize();
		}

		private void UpdateSceneNodes(IEnumerable<SceneNode> sceneNodes)
		{
			DebuggerShell.Current.RunSync(() => UpdateView(view => view.UpdateSceneNodes(sceneNodes)));
		}

		protected override bool InitializeEvents()
		{
			DebuggerShell.Current.SceneGraph.GraphChanged += sceneGraphChangedDelegate;
			UpdateView(view => view.ShowSceneNodeDetailsRequest += s => HandleCommand(new ShowSceneNodeDetailsCommand(s)));

			return base.InitializeEvents();
		}

		protected override void Release()
		{
			DebuggerShell.Current.SceneGraph.GraphChanged -= sceneGraphChangedDelegate;

			base.Release();
		}

		private void OnSceneNodeAdded(object sender, GraphChangedEventArgs<SceneNode> e)
		{
			UpdateSceneNodes(e.Nodes);
		}
	}
}
