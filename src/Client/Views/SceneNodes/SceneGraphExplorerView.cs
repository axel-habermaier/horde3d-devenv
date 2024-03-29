using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.Core.SceneNodes;
using System.Collections.ObjectModel;
using Infrastructure.UserInterface;

namespace Client.Views.SceneNodes
{
	public partial class SceneGraphExplorerView : DockView
	{
		public event RequestHandler<SceneNode> ShowSceneNodeDetailsRequest;

		const int AnimationResourceIndex = 0;
		const int CameraNodeIndex = 1;
		const int CodeResourceIndex = 2;
		const int GeometryResourceIndex = 3;
		const int GroupNodeIndex = 4;
		const int JointNodeIndex = 5;
		const int LightNodeIndex = 6;
		const int MaterialResourceIndex = 7;
		const int MeshNodeIndex = 8;
		const int ModelNodeIndex = 9;
		const int ParticleEffectIndex = 10;
		const int PipelineResourceIndex = 11;
		const int ResourceGraphIndex = 12;
		const int SceneGraphIndex = 13;
		const int SceneGraphResourceIndex = 14;
		const int ShaderResourceIndex = 15;
		const int TextureResourceIndex = 16;
		const int ProfilingIndex = 17;

		public SceneGraphExplorerView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.SceneGraphResource.GetHicon());
			SetStandardTextFont(treeView);

			treeView.Sort();
			treeView.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(treeView_NodeMouseDoubleClick);
		}

		void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node != null && e.Node.Tag is SceneNode)
				Request(ShowSceneNodeDetailsRequest, e.Node.Tag as SceneNode);
		}

		public override string Title
		{
			get
			{
				return "Scene Graph Explorer";
			}
		}

		public override WeifenLuo.WinFormsUI.Docking.DockState DefaultDockState
		{
			get
			{
				return WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide;
			}
		}

		protected override string GetPersistString()
		{
			return "SceneGraphExplorer";
		}

		public void UpdateSceneNodes(IEnumerable<SceneNode> sceneNodes)
		{
			treeView.SuspendLayout();
			treeView.Visible = false;
			treeView.Nodes.Clear();

			AddNodes(sceneNodes, null, null);

			treeView.Sort();

			foreach (TreeNode node in treeView.Nodes)
				node.Expand();

			treeView.ResumeLayout(true);
			treeView.Visible = true;

			emptySceneGraphLabel.Visible = sceneNodes == null || sceneNodes.Count() == 0;
		}

		private void AddNodes(IEnumerable<SceneNode> sceneNodes, SceneNode parentNode, TreeNode parentTreeNode)
		{
			// This adds the scene nodes in a way that is guaranteed to work, but not very efficient.
			var childNodes = sceneNodes.Where(n => n.Parent == parentNode).ToList();

			childNodes.Foreach(sceneNode =>
			{
				var newNode = new TreeNode(sceneNode.ToString());
				newNode.Tag = sceneNode;

				if (sceneNode is CameraNode)
				{
					newNode.ImageIndex = CameraNodeIndex;
					newNode.SelectedImageIndex = CameraNodeIndex;
				}
				else if (sceneNode is EmitterNode)
				{
					newNode.ImageIndex = ParticleEffectIndex;
					newNode.SelectedImageIndex = ParticleEffectIndex;
				}
				else if (sceneNode is GroupNode)
				{
					newNode.ImageIndex = GroupNodeIndex;
					newNode.SelectedImageIndex = GroupNodeIndex;
				}
				else if (sceneNode is JointNode)
				{
					newNode.ImageIndex = JointNodeIndex;
					newNode.SelectedImageIndex = JointNodeIndex;
				}
				else if (sceneNode is LightNode)
				{
					newNode.ImageIndex = LightNodeIndex;
					newNode.SelectedImageIndex = LightNodeIndex;
				}
				else if (sceneNode is MeshNode)
				{
					newNode.ImageIndex = MeshNodeIndex;
					newNode.SelectedImageIndex = MeshNodeIndex;
				}
				else if (sceneNode is ModelNode)
				{
					newNode.ImageIndex = ModelNodeIndex;
					newNode.SelectedImageIndex = ModelNodeIndex;
				}

				if (parentTreeNode == null)
					treeView.Nodes.Add(newNode);
				else
					parentTreeNode.Nodes.Add(newNode);

				AddNodes(sceneNodes, sceneNode, newNode);
			});
		}
	}
}
