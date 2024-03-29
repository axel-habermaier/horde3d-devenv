using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using System.Collections.ObjectModel;
using Infrastructure.Core.Resources;
using Infrastructure.UserInterface;

namespace Client.Views.Resources
{
	public partial class ResourcesExplorerView : DockView
	{
		public event RequestHandler<Resource> ShowResourceDetailsRequest;

		TreeNode shadersNode = null;
		TreeNode pipelinesNode = null;
		TreeNode codesNode = null;
		TreeNode materialsNode = null;
		TreeNode particleEffectsNode = null;
		TreeNode texturesNode = null;
		TreeNode otherResourcesNode = null;

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
		const int ClosedFolderIndex = 18;
		const int OpenFolderIndex = 19;

		Dictionary<TreeNode, bool> expandState;

		IEnumerable<Resource> resources;

		public ResourcesExplorerView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.ResourceGraph.GetHicon());
			SetStandardTextFont(treeView);

			shadersNode = new TreeNode("Shaders", ClosedFolderIndex, ClosedFolderIndex);
			pipelinesNode = new TreeNode("Pipelines", ClosedFolderIndex, ClosedFolderIndex);
			codesNode = new TreeNode("Codes", ClosedFolderIndex, ClosedFolderIndex);
			materialsNode = new TreeNode("Materials", ClosedFolderIndex, ClosedFolderIndex);
			particleEffectsNode = new TreeNode("Particle Effects", ClosedFolderIndex, ClosedFolderIndex);
			texturesNode = new TreeNode("Textures", ClosedFolderIndex, ClosedFolderIndex);
			otherResourcesNode = new TreeNode("Other Resources", ClosedFolderIndex, ClosedFolderIndex);
			
			treeView.Nodes.Add(shadersNode);
			treeView.Nodes.Add(pipelinesNode);
			treeView.Nodes.Add(codesNode);
			treeView.Nodes.Add(materialsNode);
			treeView.Nodes.Add(particleEffectsNode);
			treeView.Nodes.Add(texturesNode);
			treeView.Nodes.Add(otherResourcesNode);

			expandState = new Dictionary<TreeNode, bool>
			{
				{ shadersNode, false },
				{ pipelinesNode, false },
				{ codesNode, false },
				{ materialsNode, false },
				{ particleEffectsNode, false },
				{ texturesNode, false },
				{ otherResourcesNode, false }
			};

			treeView.AfterCollapse += (o, e) =>
			{
				if (e.Node == null || !expandState.ContainsKey(e.Node))
					return;

				e.Node.ImageIndex = e.Node.SelectedImageIndex = ClosedFolderIndex;
				expandState[e.Node] = false;
			};
			treeView.AfterExpand += (o, e) =>
			{
				if (e.Node == null || !expandState.ContainsKey(e.Node))
					return;

				e.Node.ImageIndex = e.Node.SelectedImageIndex = OpenFolderIndex;
				expandState[e.Node] = true;
			};

			treeView.Sort();
		}

		public override string Title
		{
			get
			{
				return "Resources Explorer";
			}
		}

		public override WeifenLuo.WinFormsUI.Docking.DockState DefaultDockState
		{
			get
			{
				return WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
			}
		}

		protected override string GetPersistString()
		{
			return "ResourcesExplorer";
		}

		public void UpdateResources(IEnumerable<Resource> resources)
		{
			this.resources = resources;

			UpdateView();
		}

		private void UpdateView()
		{
			treeView.SuspendLayout();
			treeView.Visible = false;

			shadersNode.Nodes.Clear();
			pipelinesNode.Nodes.Clear();
			codesNode.Nodes.Clear();
			materialsNode.Nodes.Clear();
			particleEffectsNode.Nodes.Clear();
			texturesNode.Nodes.Clear();
			otherResourcesNode.Nodes.Clear();

			shadersNode.SelectedImageIndex = shadersNode.ImageIndex = ClosedFolderIndex;
			pipelinesNode.SelectedImageIndex = pipelinesNode.ImageIndex = ClosedFolderIndex;
			codesNode.SelectedImageIndex = codesNode.ImageIndex = ClosedFolderIndex;
			materialsNode.SelectedImageIndex = materialsNode.ImageIndex = ClosedFolderIndex;
			particleEffectsNode.SelectedImageIndex = particleEffectsNode.ImageIndex = ClosedFolderIndex;
			texturesNode.SelectedImageIndex = texturesNode.ImageIndex = ClosedFolderIndex;
			otherResourcesNode.SelectedImageIndex = otherResourcesNode.ImageIndex = ClosedFolderIndex;

			resources.Foreach(resource =>
			{
				if (!String.IsNullOrEmpty(searchTextBox.Text.Trim()) && !resource.Name.Contains(searchTextBox.Text))
					return;

				var newNode = new TreeNode(resource.Name);
				newNode.Tag = resource;

				if (resource is ShaderResource)
				{
					newNode.ImageIndex = ShaderResourceIndex;
					newNode.SelectedImageIndex = ShaderResourceIndex;
					shadersNode.Nodes.Add(newNode);
				}
				else if (resource is PipelineResource)
				{
					newNode.ImageIndex = PipelineResourceIndex;
					newNode.SelectedImageIndex = PipelineResourceIndex;
					pipelinesNode.Nodes.Add(newNode);
				}
				else if (resource is CodeResource)
				{
					// Don't show code resources created when loading shader resources.
					if (resource.Name.Contains(":"))
						return;

					newNode.ImageIndex = CodeResourceIndex;
					newNode.SelectedImageIndex = CodeResourceIndex;
					codesNode.Nodes.Add(newNode);
				}
				else if (resource is MaterialResource)
				{
					// Don't show cloned materials.
					if (resource.Name.Contains("|"))
						return;

					newNode.ImageIndex = MaterialResourceIndex;
					newNode.SelectedImageIndex = MaterialResourceIndex;
					materialsNode.Nodes.Add(newNode);
				}
				else if (resource is ParticleEffectResource)
				{
					newNode.ImageIndex = ParticleEffectIndex;
					newNode.SelectedImageIndex = ParticleEffectIndex;
					particleEffectsNode.Nodes.Add(newNode);
				}
				else if (resource is TextureResource)
				{
					newNode.ImageIndex = TextureResourceIndex;
					newNode.SelectedImageIndex = TextureResourceIndex;
					texturesNode.Nodes.Add(newNode);
				}
				else if (resource is AnimationResource)
				{
					newNode.ImageIndex = AnimationResourceIndex;
					newNode.SelectedImageIndex = AnimationResourceIndex;
					otherResourcesNode.Nodes.Add(newNode);
				}
				else if (resource is GeometryResource)
				{
					newNode.ImageIndex = GeometryResourceIndex;
					newNode.SelectedImageIndex = GeometryResourceIndex;
					otherResourcesNode.Nodes.Add(newNode);
				}
				else if (resource is SceneGraphResource)
				{
					newNode.ImageIndex = SceneGraphResourceIndex;
					newNode.SelectedImageIndex = SceneGraphResourceIndex;
					otherResourcesNode.Nodes.Add(newNode);
				}
				else if (resource is AnimationResource)
				{
					newNode.ImageIndex = AnimationResourceIndex;
					newNode.SelectedImageIndex = AnimationResourceIndex;
					otherResourcesNode.Nodes.Add(newNode);
				}
			});

			foreach (var state in new Dictionary<TreeNode, bool>(expandState))
				if (state.Value)
					state.Key.Expand();
	
			treeView.Sort();
			treeView.ResumeLayout(true);
			treeView.Visible = true;
		}

		private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node == null || e.Node.Tag == null || !(e.Node.Tag is Resource))
				return;

			Request(ShowResourceDetailsRequest, e.Node.Tag as Resource);
		}

		private void clearSearchButton_Click(object sender, EventArgs e)
		{
			searchTextBox.Text = String.Empty;
			UpdateView();
		}

		private void searchTextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateView();
		}
	}
}
