namespace Infrastructure.CodeGenerator.Views
{
	partial class ShellView
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShellView));
			this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.parseFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generateCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.functionListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutCodeGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.propertiesButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.parseFunctionsButton = new System.Windows.Forms.ToolStripButton();
			this.generateCodeButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.openHeaderFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.headerFileButton = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripContainer.ContentPanel.SuspendLayout();
			this.toolStripContainer.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripContainer
			// 
			// 
			// toolStripContainer.ContentPanel
			// 
			this.toolStripContainer.ContentPanel.Controls.Add(this.dockPanel);
			this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(984, 615);
			this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.Size = new System.Drawing.Size(984, 664);
			this.toolStripContainer.TabIndex = 0;
			this.toolStripContainer.Text = "toolStripContainer1";
			// 
			// toolStripContainer.TopToolStripPanel
			// 
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip1);
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip1);
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip2);
			// 
			// dockPanel
			// 
			this.dockPanel.ActiveAutoHideContent = null;
			this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockPanel.DockLeftPortion = 300;
			this.dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
			this.dockPanel.Location = new System.Drawing.Point(0, 0);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.Size = new System.Drawing.Size(984, 615);
			this.dockPanel.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolStripMenuItem2});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(984, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
			this.toolStripMenuItem1.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripButton_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(111, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripButton_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(111, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parseFunctionsToolStripMenuItem,
            this.changeSettingsToolStripMenuItem,
            this.generateCodeToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// parseFunctionsToolStripMenuItem
			// 
			this.parseFunctionsToolStripMenuItem.Image = global::Infrastructure.CodeGenerator.Properties.Resources.ExtractFunctions;
			this.parseFunctionsToolStripMenuItem.Name = "parseFunctionsToolStripMenuItem";
			this.parseFunctionsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.parseFunctionsToolStripMenuItem.Text = "&Parse Functions";
			this.parseFunctionsToolStripMenuItem.Click += new System.EventHandler(this.parseFunctionsButton_Click);
			// 
			// changeSettingsToolStripMenuItem
			// 
			this.changeSettingsToolStripMenuItem.Image = global::Infrastructure.CodeGenerator.Properties.Resources.Properties;
			this.changeSettingsToolStripMenuItem.Name = "changeSettingsToolStripMenuItem";
			this.changeSettingsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.changeSettingsToolStripMenuItem.Text = "&Change Settings";
			this.changeSettingsToolStripMenuItem.Click += new System.EventHandler(this.propertiesButton_Click);
			// 
			// generateCodeToolStripMenuItem
			// 
			this.generateCodeToolStripMenuItem.Image = global::Infrastructure.CodeGenerator.Properties.Resources.Compile;
			this.generateCodeToolStripMenuItem.Name = "generateCodeToolStripMenuItem";
			this.generateCodeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.generateCodeToolStripMenuItem.Text = "&Generate Code";
			this.generateCodeToolStripMenuItem.Click += new System.EventHandler(this.generateCodeButton_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionListToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// functionListToolStripMenuItem
			// 
			this.functionListToolStripMenuItem.Image = global::Infrastructure.CodeGenerator.Properties.Resources.List;
			this.functionListToolStripMenuItem.Name = "functionListToolStripMenuItem";
			this.functionListToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.functionListToolStripMenuItem.Text = "&Function List";
			this.functionListToolStripMenuItem.Click += new System.EventHandler(this.functionListToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutCodeGeneratorToolStripMenuItem});
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(24, 20);
			this.toolStripMenuItem2.Text = "?";
			// 
			// aboutCodeGeneratorToolStripMenuItem
			// 
			this.aboutCodeGeneratorToolStripMenuItem.Name = "aboutCodeGeneratorToolStripMenuItem";
			this.aboutCodeGeneratorToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.aboutCodeGeneratorToolStripMenuItem.Text = "About Code Generator";
			this.aboutCodeGeneratorToolStripMenuItem.Click += new System.EventHandler(this.aboutCodeGeneratorToolStripMenuItem_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.propertiesButton});
			this.toolStrip1.Location = new System.Drawing.Point(3, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(110, 25);
			this.toolStrip1.TabIndex = 1;
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.newToolStripButton.Text = "&New";
			this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openToolStripButton.Text = "&Open";
			this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Enabled = false;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.saveToolStripButton.Text = "&Save";
			this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// propertiesButton
			// 
			this.propertiesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.propertiesButton.Enabled = false;
			this.propertiesButton.Image = global::Infrastructure.CodeGenerator.Properties.Resources.Properties;
			this.propertiesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.propertiesButton.Name = "propertiesButton";
			this.propertiesButton.Size = new System.Drawing.Size(23, 22);
			this.propertiesButton.Text = "Code Generation Settings";
			this.propertiesButton.Click += new System.EventHandler(this.propertiesButton_Click);
			// 
			// toolStrip2
			// 
			this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.headerFileButton,
            this.parseFunctionsButton,
            this.generateCodeButton});
			this.toolStrip2.Location = new System.Drawing.Point(113, 24);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(432, 25);
			this.toolStrip2.TabIndex = 2;
			// 
			// parseFunctionsButton
			// 
			this.parseFunctionsButton.Enabled = false;
			this.parseFunctionsButton.Image = global::Infrastructure.CodeGenerator.Properties.Resources.ExtractFunctions;
			this.parseFunctionsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.parseFunctionsButton.Name = "parseFunctionsButton";
			this.parseFunctionsButton.Size = new System.Drawing.Size(117, 22);
			this.parseFunctionsButton.Text = "Extract Functions";
			this.parseFunctionsButton.Click += new System.EventHandler(this.parseFunctionsButton_Click);
			// 
			// generateCodeButton
			// 
			this.generateCodeButton.Enabled = false;
			this.generateCodeButton.Image = global::Infrastructure.CodeGenerator.Properties.Resources.Compile;
			this.generateCodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.generateCodeButton.Name = "generateCodeButton";
			this.generateCodeButton.Size = new System.Drawing.Size(105, 22);
			this.generateCodeButton.Text = "Generate Code";
			this.generateCodeButton.Click += new System.EventHandler(this.generateCodeButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// openHeaderFileDialog
			// 
			this.openHeaderFileDialog.FileName = "Horde3D.h";
			this.openHeaderFileDialog.Filter = "C Header Files|*.h";
			// 
			// kryptonManager
			// 
			this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.ProfessionalOffice2003;
			// 
			// headerFileButton
			// 
			this.headerFileButton.Image = global::Infrastructure.CodeGenerator.Properties.Resources.HeaderFile;
			this.headerFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.headerFileButton.Name = "headerFileButton";
			this.headerFileButton.Size = new System.Drawing.Size(198, 22);
			this.headerFileButton.Text = "Select the Horde3D header file";
			this.headerFileButton.ButtonClick += new System.EventHandler(this.headerFileButton_Click);
			// 
			// ShellView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 664);
			this.Controls.Add(this.toolStripContainer);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(1000, 700);
			this.Name = "ShellView";
			this.Text = "Code Generator";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShellView_FormClosing);
			this.toolStripContainer.ContentPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.PerformLayout();
			this.toolStripContainer.ResumeLayout(false);
			this.toolStripContainer.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripContainer toolStripContainer;
		private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton parseFunctionsButton;
		private System.Windows.Forms.OpenFileDialog openHeaderFileDialog;
		private System.Windows.Forms.ToolStripButton propertiesButton;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem parseFunctionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem functionListToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
		private System.Windows.Forms.ToolStripButton generateCodeButton;
		private System.Windows.Forms.ToolStripMenuItem generateCodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem aboutCodeGeneratorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSplitButton headerFileButton;
	}
}