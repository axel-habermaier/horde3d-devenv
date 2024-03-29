namespace Client.Views.Resources
{
	partial class ResourcesExplorerView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourcesExplorerView));
			this.treeView = new System.Windows.Forms.TreeView();
			this.treeViewImages = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.searchTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.clearSearchButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView
			// 
			this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeView.HideSelection = false;
			this.treeView.ImageIndex = 0;
			this.treeView.ImageList = this.treeViewImages;
			this.treeView.Location = new System.Drawing.Point(0, 28);
			this.treeView.Name = "treeView";
			this.treeView.SelectedImageIndex = 0;
			this.treeView.Size = new System.Drawing.Size(284, 235);
			this.treeView.TabIndex = 2;
			this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseDoubleClick);
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
			this.treeViewImages.Images.SetKeyName(18, "ClosedFolder.png");
			this.treeViewImages.Images.SetKeyName(19, "OpenFolder.png");
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.searchTextBox,
            this.toolStripSeparator1,
            this.clearSearchButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(284, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
			this.toolStripLabel1.Text = "Search:";
			// 
			// searchTextBox
			// 
			this.searchTextBox.Name = "searchTextBox";
			this.searchTextBox.Size = new System.Drawing.Size(150, 25);
			this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// clearSearchButton
			// 
			this.clearSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.clearSearchButton.Image = global::Client.Properties.Resources.ClearAll;
			this.clearSearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.clearSearchButton.Name = "clearSearchButton";
			this.clearSearchButton.Size = new System.Drawing.Size(23, 22);
			this.clearSearchButton.Text = "Clear Search";
			this.clearSearchButton.Click += new System.EventHandler(this.clearSearchButton_Click);
			// 
			// ResourcesExplorerView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 264);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.treeView);
			this.Name = "ResourcesExplorerView";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.ImageList treeViewImages;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox searchTextBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton clearSearchButton;
	}
}
