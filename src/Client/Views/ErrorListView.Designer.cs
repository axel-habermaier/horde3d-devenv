namespace Client.Views
{
	partial class ErrorListView
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
			BinaryComponents.SuperList.Sections.SectionFactory sectionFactory1 = new BinaryComponents.SuperList.Sections.SectionFactory();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.errorsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.warningsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.debugInfoToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.infoToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.messagesListView = new Infrastructure.UserInterface.WinForms.ListViewControl();
			this.kryptonGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
			this.kryptonGroup1.Panel.SuspendLayout();
			this.kryptonGroup1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorsToolStripButton,
            this.toolStripSeparator1,
            this.warningsToolStripButton,
            this.toolStripSeparator3,
            this.debugInfoToolStripButton,
            this.toolStripSeparator2,
            this.infoToolStripButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(758, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// errorsToolStripButton
			// 
			this.errorsToolStripButton.Checked = true;
			this.errorsToolStripButton.CheckOnClick = true;
			this.errorsToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.errorsToolStripButton.Image = global::Client.Properties.Resources.Error;
			this.errorsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.errorsToolStripButton.Name = "errorsToolStripButton";
			this.errorsToolStripButton.Size = new System.Drawing.Size(57, 22);
			this.errorsToolStripButton.Text = "Errors";
			this.errorsToolStripButton.Click += new System.EventHandler(this.categoryToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// warningsToolStripButton
			// 
			this.warningsToolStripButton.Checked = true;
			this.warningsToolStripButton.CheckOnClick = true;
			this.warningsToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.warningsToolStripButton.Image = global::Client.Properties.Resources.Warning;
			this.warningsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.warningsToolStripButton.Name = "warningsToolStripButton";
			this.warningsToolStripButton.Size = new System.Drawing.Size(77, 22);
			this.warningsToolStripButton.Text = "Warnings";
			this.warningsToolStripButton.Click += new System.EventHandler(this.categoryToolStripButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// debugInfoToolStripButton
			// 
			this.debugInfoToolStripButton.Checked = true;
			this.debugInfoToolStripButton.CheckOnClick = true;
			this.debugInfoToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.debugInfoToolStripButton.Image = global::Client.Properties.Resources.DebugInfo;
			this.debugInfoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.debugInfoToolStripButton.Name = "debugInfoToolStripButton";
			this.debugInfoToolStripButton.Size = new System.Drawing.Size(116, 22);
			this.debugInfoToolStripButton.Text = "Debug Messages";
			this.debugInfoToolStripButton.Click += new System.EventHandler(this.categoryToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// infoToolStripButton
			// 
			this.infoToolStripButton.CheckOnClick = true;
			this.infoToolStripButton.Image = global::Client.Properties.Resources.Info;
			this.infoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.infoToolStripButton.Name = "infoToolStripButton";
			this.infoToolStripButton.Size = new System.Drawing.Size(78, 22);
			this.infoToolStripButton.Text = "Messages";
			this.infoToolStripButton.Click += new System.EventHandler(this.categoryToolStripButton_Click);
			// 
			// messagesListView
			// 
			this.messagesListView.AllowDrop = true;
			this.messagesListView.AllowRowDragDrop = false;
			this.messagesListView.AllowSorting = true;
			this.messagesListView.AlternatingRowColor = System.Drawing.Color.Empty;
			this.messagesListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messagesListView.FillColumn = null;
			this.messagesListView.FocusedItem = null;
			this.messagesListView.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.messagesListView.GroupSectionFont = null;
			this.messagesListView.GroupSectionForeColor = System.Drawing.SystemColors.WindowText;
			this.messagesListView.GroupSectionTextPlural = "Items";
			this.messagesListView.GroupSectionTextSingular = "Item";
			this.messagesListView.GroupSectionVerticalAlignment = BinaryComponents.WinFormsUtility.Drawing.GdiPlusEx.VAlignment.Top;
			this.messagesListView.IndentColor = System.Drawing.Color.LightGoldenrodYellow;
			this.messagesListView.Location = new System.Drawing.Point(0, 0);
			this.messagesListView.MultiSelect = true;
			this.messagesListView.Name = "messagesListView";
			this.messagesListView.SectionFactory = sectionFactory1;
			this.messagesListView.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(164)))), ((int)(((byte)(224)))));
			this.messagesListView.ShowCustomizeSection = false;
			this.messagesListView.ShowHeaderSection = true;
			this.messagesListView.Size = new System.Drawing.Size(758, 356);
			this.messagesListView.TabIndex = 2;
			// 
			// kryptonGroup1
			// 
			this.kryptonGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonGroup1.Location = new System.Drawing.Point(0, 25);
			this.kryptonGroup1.Name = "kryptonGroup1";
			// 
			// kryptonGroup1.Panel
			// 
			this.kryptonGroup1.Panel.Controls.Add(this.messagesListView);
			this.kryptonGroup1.Size = new System.Drawing.Size(758, 357);
			this.kryptonGroup1.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom;
			this.kryptonGroup1.TabIndex = 3;
			// 
			// ErrorListView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(758, 383);
			this.Controls.Add(this.kryptonGroup1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "ErrorListView";
			this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
			this.kryptonGroup1.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
			this.kryptonGroup1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton errorsToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton warningsToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton infoToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton debugInfoToolStripButton;
		private Infrastructure.UserInterface.WinForms.ListViewControl messagesListView;
		private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup1;
	}
}
