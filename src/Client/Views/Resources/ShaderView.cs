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
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using Infrastructure.UserInterface;
using ComponentFactory.Krypton.Toolkit;
using System.Runtime.InteropServices;

namespace Client.Views.Resources
{
	public partial class ShaderView : SaveableDocumentView
	{
		public event RequestHandler<ShaderContext> ShowShaderContextDetailsRequest;
		public event RequestHandler<ShaderSection> ShowShaderSectionDetailsRequest;
		public event RequestHandler<ShaderSampler> ShowSamplerDetailsRequest;
		public event RequestHandler<ShaderUniform> ShowUniformDetailsRequest;
		public event RequestHandler SwitchToDesignerRequest;
		public event RequestHandler SwitchToSourceRequest;

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
		const int SamplerIndex = 20;
		const int ContextIndex = 21;
		const int ShaderSectionIndex = 22;
		const int UniformIndex = 23;

		TreeNode shadersNode;
		TreeNode contextsNode;
		TreeNode samplersNode;
		TreeNode uniformsNode;

		public ShaderView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.ShaderResource.GetHicon());
			SetStandardTextFont(treeView);
			SetStandardTextFont(tabControl);
			SetStandardTextFont(designerDisabledLabel);
			designerDisabledHeaderLabel.Font = new Font(designerDisabledLabel.Font, FontStyle.Bold);

			shadersNode = new TreeNode("Shaders", ClosedFolderIndex, ClosedFolderIndex);
			contextsNode = new TreeNode("Contexts", ClosedFolderIndex, ClosedFolderIndex);
			samplersNode = new TreeNode("Samplers", ClosedFolderIndex, ClosedFolderIndex);
			uniformsNode = new TreeNode("Uniforms", ClosedFolderIndex, ClosedFolderIndex);

			treeView.Nodes.Add(shadersNode);
			treeView.Nodes.Add(contextsNode);
			treeView.Nodes.Add(samplersNode);
			treeView.Nodes.Add(uniformsNode);

			treeView.AfterCollapse += (o, e) => e.Node.ImageIndex = e.Node.SelectedImageIndex = ClosedFolderIndex;
			treeView.AfterExpand += (o, e) => e.Node.ImageIndex = e.Node.SelectedImageIndex = OpenFolderIndex;
			//treeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView_NodeMouseClick);
		}

		//[DllImport("user32.dll")]
		//[return: MarshalAs(UnmanagedType.Bool)]
		//static extern bool GetCursorPos(out Point lpPoint);

		//void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		//{
		//    if (e.Button == MouseButtons.Right)
		//    {
		//        Point p = new Point();
		//        GetCursorPos(out p);
		//        treeViewContextMenu.Show(p, KryptonContextMenuPositionH.Left, KryptonContextMenuPositionV.Below);
		//    }
		//}

		string title = "Shader Resource";
		public override string Title
		{
			get
			{
				return title;
			}
		}

		public UserControlView DetailsView
		{
			set
			{
				if (value == null)
					return;

				splitContainer.Panel2.Controls.Add(value);
				value.Dock = DockStyle.Fill;
			}
		}

		ShaderResource shader = null;
		public ShaderResource Shader
		{
			get { return shader; }
			set
			{
				shader = value;
				title = FileSystem.TruncatePath(shader.Name, MaxTitleLength);
				//textEditor.Document.TextContent = shader.FileContent;
				bindingSource.DataSource = shader;
				//textEditor.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));

				UpdateDesigner();
			}
		}

		public bool DesignerEnabled
		{
			set
			{
				splitContainer.Visible = value;
				designerDisabledLabel.Visible = !value;
				designerDisabledHeaderLabel.Visible = !value;
			}
		}

		public string DesignerDisabledMessage
		{
			set
			{
				designerDisabledLabel.Text = value;
			}
		}

		public TextEditorView TextEditorView
		{
			set
			{
				if (value == null)
					return;

				xmlPage.Controls.Add(value);
			}
		}

		public void UpdateDesigner()
		{
			shadersNode.Nodes.Clear();
			contextsNode.Nodes.Clear();
			uniformsNode.Nodes.Clear();
			samplersNode.Nodes.Clear();

			shader.ShaderSections.Foreach(shaderSection =>
			{
				var node = new TreeNode(shaderSection.Name, ShaderSectionIndex, ShaderSectionIndex);
				node.Tag = shaderSection;
				shadersNode.Nodes.Add(node);
			});

			shader.FxSection.Contexts.Foreach(context =>
			{
				var node = new TreeNode(context.Name, ContextIndex, ContextIndex);
				node.Tag = context;
				contextsNode.Nodes.Add(node);
			});

			shader.FxSection.Samplers.Foreach(sampler =>
			{
				var node = new TreeNode(sampler.Name, SamplerIndex, SamplerIndex);
				node.Tag = sampler;
				samplersNode.Nodes.Add(node);
			});

			shader.FxSection.Uniforms.Foreach(uniform =>
			{
				var node = new TreeNode(uniform.Name, UniformIndex, UniformIndex);
				node.Tag = uniform;
				uniformsNode.Nodes.Add(node);
			});

			treeView.Sort();
			treeView.ExpandAll();
		}

		private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node == null)
				return;

			if (e.Node.Tag is ShaderContext)
				Request(ShowShaderContextDetailsRequest, e.Node.Tag as ShaderContext);
			else if (e.Node.Tag is ShaderSection)
				Request(ShowShaderSectionDetailsRequest, e.Node.Tag as ShaderSection);
			else if (e.Node.Tag is ShaderUniform)
				Request(ShowUniformDetailsRequest, e.Node.Tag as ShaderUniform);
			else if (e.Node.Tag is ShaderSampler)
				Request(ShowSamplerDetailsRequest, e.Node.Tag as ShaderSampler);
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl.SelectedIndex == 0)
				Request(SwitchToDesignerRequest);
			else
				Request(SwitchToSourceRequest);
		}
	}
}
