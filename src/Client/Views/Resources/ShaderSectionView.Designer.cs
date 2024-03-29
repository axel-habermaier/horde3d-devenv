namespace Client.Views.Resources
{
	partial class ShaderSectionView
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
			this.textEditor = new ICSharpCode.TextEditor.TextEditorControl();
			this.group = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
			this.selectSectionButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
			this.sectionContextMenu = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
			this.contextMenuItems = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
			this.kryptonContextMenuHeading1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.group)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.group.Panel)).BeginInit();
			this.group.Panel.SuspendLayout();
			this.group.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// textEditor
			// 
			this.textEditor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Code", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textEditor.IsReadOnly = false;
			this.textEditor.Location = new System.Drawing.Point(0, 0);
			this.textEditor.Name = "textEditor";
			this.textEditor.ShowVRuler = false;
			this.textEditor.Size = new System.Drawing.Size(562, 275);
			this.textEditor.TabIndex = 1;
			// 
			// group
			// 
			this.group.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.selectSectionButton});
			this.group.CollapseTarget = ComponentFactory.Krypton.Toolkit.HeaderGroupCollapsedTarget.CollapsedToPrimary;
			this.group.Dock = System.Windows.Forms.DockStyle.Fill;
			this.group.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
			this.group.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlClient;
			this.group.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
			this.group.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
			this.group.HeaderVisibleSecondary = false;
			this.group.Location = new System.Drawing.Point(0, 0);
			this.group.Name = "group";
			this.group.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			// 
			// group.Panel
			// 
			this.group.Panel.Controls.Add(this.textEditor);
			this.group.Size = new System.Drawing.Size(564, 298);
			this.group.TabIndex = 2;
			this.group.Text = "Heading";
			this.group.ValuesPrimary.Description = "";
			this.group.ValuesPrimary.Heading = "Heading";
			this.group.ValuesPrimary.Image = global::Client.Properties.Resources.ShaderSection;
			this.group.ValuesSecondary.Description = "";
			this.group.ValuesSecondary.Heading = "Description";
			this.group.ValuesSecondary.Image = null;
			// 
			// selectSectionButton
			// 
			this.selectSectionButton.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Inherit;
			this.selectSectionButton.ExtraText = "";
			this.selectSectionButton.Image = global::Client.Properties.Resources.MagnifyingGlass;
			this.selectSectionButton.KryptonContextMenu = this.sectionContextMenu;
			this.selectSectionButton.Orientation = ComponentFactory.Krypton.Toolkit.PaletteButtonOrientation.Inherit;
			this.selectSectionButton.Text = "";
			this.selectSectionButton.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.DropDown;
			this.selectSectionButton.UniqueName = "3E189340234F4C093E189340234F4C09";
			this.selectSectionButton.Visible = false;
			// 
			// sectionContextMenu
			// 
			this.sectionContextMenu.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.contextMenuItems});
			this.sectionContextMenu.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.sectionContextMenu.Tag = null;
			// 
			// contextMenuItems
			// 
			this.contextMenuItems.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuHeading1});
			// 
			// kryptonContextMenuHeading1
			// 
			this.kryptonContextMenuHeading1.ExtraText = "";
			this.kryptonContextMenuHeading1.ImageTransparentColor = System.Drawing.Color.Empty;
			this.kryptonContextMenuHeading1.Text = "Select A Shader Section";
			// 
			// bindingSource
			// 
			this.bindingSource.DataSource = typeof(Infrastructure.Core.Resources.ShaderSection);
			// 
			// ShaderSectionView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.group);
			this.Name = "ShaderSectionView";
			this.Size = new System.Drawing.Size(564, 298);
			((System.ComponentModel.ISupportInitialize)(this.group.Panel)).EndInit();
			this.group.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.group)).EndInit();
			this.group.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ICSharpCode.TextEditor.TextEditorControl textEditor;
		private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup group;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup selectSectionButton;
		private ComponentFactory.Krypton.Toolkit.KryptonContextMenu sectionContextMenu;
		private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems contextMenuItems;
		private ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading kryptonContextMenuHeading1;
		private System.Windows.Forms.BindingSource bindingSource;
	}
}
