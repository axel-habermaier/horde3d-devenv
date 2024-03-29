using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views.SceneNodes;
using Infrastructure.Core.SceneNodes;
using Client.Commands;
using Infrastructure.Core;

namespace Client.Presenters.SceneNodes
{
	class NodePresenter : DebuggerPresenter<NodeView>
	{
		SceneNode sceneNode;

		public NodePresenter(SceneNode sceneNode)
		{
			this.sceneNode = sceneNode;
		}

		public override string Name
		{
			get
			{
				return sceneNode.ToString();
			}
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.SceneNode = sceneNode);

			return base.Initialize();
		}

		protected override bool InitializeEvents()
		{
			UpdateView(view => view.ShowParentDetailsRequest += () =>
			{
				if (sceneNode.Parent != null)
					HandleCommand(new ShowSceneNodeDetailsCommand(sceneNode.Parent));
			});
			Shell.SceneGraph.GraphChanged += OnSceneGraphChanged;

			return base.InitializeEvents();
		}

		protected override void Release()
		{
			Shell.SceneGraph.GraphChanged -= OnSceneGraphChanged;

			base.Release();
		}

		private void OnSceneGraphChanged(object sender, GraphChangedEventArgs<SceneNode> e)
		{
			var newNodes = from n in e.Nodes
						   where n.Name == sceneNode.Name && n.NodeHandle == sceneNode.NodeHandle && n.GetType() == sceneNode.GetType()
						   select n;

			if (newNodes.Count() != 1)
				return;

			sceneNode = newNodes.Single();
			UpdateView(view => view.SceneNode = sceneNode);
		}
	}
}
