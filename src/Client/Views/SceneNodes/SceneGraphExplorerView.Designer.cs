namespace Client.Views.SceneNodes
{
	partial class SceneGraphExplorerView
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneGraphExplorerView));
			this.treeView = new System.Windows.Forms.TreeView();
			this.treeViewImages = new System.Windows.Forms.ImageList(this.components);
			this.emptySceneGraphLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.SuspendLayout();
			// 
			// treeView
			// 
			this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.HideSelection = false;
			this.treeView.ImageIndex = 0;
			this.treeView.ImageList = this.treeViewImages;
			this.treeView.Location = new System.Drawing.Point(0, 0);
			this.treeView.Name = "treeView";
			this.treeView.SelectedImageIndex = 0;
			this.treeView.Size = new System.Drawing.Size(284, 264);
			this.treeView.TabIndex = 1;
			// 
			// treeViewImages
			// 
			this.treeViewImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImages.ImageStream")));
			this.treeViewImages.TransparentColor = System.Drawing.Color.Transparent;
			this.treeViewImages.Images.SetKeyName(0, "AnimationResource.png");
			this.treeViewImages.Images.SetKeyName(1, "Camera.png");
			this.treeViewImages.Images.SetKeyName(2, "CodeResource.png");
			this.treeViewImages.Images.SetKeyName(3, "Geometry.png");
			this.treeViewImages.Images.SetKeyName(4, "GroupNode.png");
			this.treeViewImages.Images.SetKeyName(5, "JointNode.png");
			this.treeViewImages.Images.SetKeyName(6, "LightNode.png");
			this.treeViewImages.Images.SetKeyName(7, "MaterialResource.png");
			this.treeViewImages.Images.SetKeyName(8, "MeshNode.png");
			this.treeViewImages.Images.SetKeyName(9, "Model.png");
			this.treeViewImages.Images.SetKeyName(10, "ParticleEffect.png");
			this.treeViewImages.Images.SetKeyName(11, "PipelineResource.png");
			this.treeViewImages.Images.SetKeyName(12, "ResourceGraph.png");
			this.treeViewImages.Images.SetKeyName(13, "SceneGraph.png");
			this.treeViewImages.Images.SetKeyName(14, "SceneGraphResource.png");
			this.treeViewImages.Images.SetKeyName(15, "ShaderResource.png");
			this.treeViewImages.Images.SetKeyName(16, "TextureResource.png");
			this.treeViewImages.Images.SetKeyName(17, "Profiling.png");
			// 
			// emptySceneGraphLabel
			// 
			this.emptySceneGraphLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.emptySceneGraphLabel.AutoSize = false;
			this.emptySceneGraphLabel.Location = new System.Drawing.Point(0, 25);
			this.emptySceneGraphLabel.Name = "emptySceneGraphLabel";
			this.emptySceneGraphLabel.Size = new System.Drawing.Size(284, 25);
			this.emptySceneGraphLabel.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
			this.emptySceneGraphLabel.TabIndex = 2;
			this.emptySceneGraphLabel.Text = "No Scene Graph Data available.";
			this.emptySceneGraphLabel.Values.ExtraText = "";
			this.emptySceneGraphLabel.Values.Image = null;
			this.emptySceneGraphLabel.Values.Text = "No Scene Graph Data available.";
			// 
			// SceneGraphExplorerView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 264);
			this.Controls.Add(this.emptySceneGraphLabel);
			this.Controls.Add(this.treeView);
			this.Name = "SceneGraphExplorerView";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.ImageList treeViewImages;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel emptySceneGraphLabel;
	}
}
