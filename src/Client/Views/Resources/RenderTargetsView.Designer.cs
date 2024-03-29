namespace Client.Views.Resources
{
	partial class RenderTargetsView
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.updateIntervalComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.renderTargetData = new QAlbum.ScalablePictureBox();
			this.renderTargetsButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.noRenderTargetsKnownEitherTheApplicationHasNotYetBeenSuspendedOrItDoesNotUseAnyRenderTargetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderTargetsButton,
            this.updateIntervalComboBox,
            this.toolStripLabel1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(489, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// updateIntervalComboBox
			// 
			this.updateIntervalComboBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.updateIntervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.updateIntervalComboBox.Items.AddRange(new object[] {
            "250",
            "500",
            "1000",
            "5000"});
			this.updateIntervalComboBox.Name = "updateIntervalComboBox";
			this.updateIntervalComboBox.Size = new System.Drawing.Size(75, 25);
			this.updateIntervalComboBox.SelectedIndexChanged += new System.EventHandler(this.updateIntervalComboBox_SelectedIndexChanged);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(117, 22);
			this.toolStripLabel1.Text = "Update Interval (ms):";
			// 
			// renderTargetData
			// 
			this.renderTargetData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.renderTargetData.BackColor = System.Drawing.Color.Transparent;
			this.renderTargetData.Location = new System.Drawing.Point(0, 28);
			this.renderTargetData.Name = "renderTargetData";
			this.renderTargetData.Size = new System.Drawing.Size(489, 305);
			this.renderTargetData.TabIndex = 1;
			// 
			// renderTargetsButton
			// 
			this.renderTargetsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noRenderTargetsKnownEitherTheApplicationHasNotYetBeenSuspendedOrItDoesNotUseAnyRenderTargetsToolStripMenuItem});
			this.renderTargetsButton.Image = global::Client.Properties.Resources.RenderTarget;
			this.renderTargetsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.renderTargetsButton.Name = "renderTargetsButton";
			this.renderTargetsButton.Size = new System.Drawing.Size(147, 22);
			this.renderTargetsButton.Text = "Select a render target";
			// 
			// noRenderTargetsKnownEitherTheApplicationHasNotYetBeenSuspendedOrItDoesNotUseAnyRenderTargetsToolStripMenuItem
			// 
			this.noRenderTargetsKnownEitherTheApplicationHasNotYetBeenSuspendedOrItDoesNotUseAnyRenderTargetsToolStripMenuItem.Name = "noRenderTargetsKnownEitherTheApplicationHasNotYetBeenSuspendedOrItDoesNotUseAnyRe" +
				"nderTargetsToolStripMenuItem";
			this.noRenderTargetsKnownEitherTheApplicationHasNotYetBeenSuspendedOrItDoesNotUseAnyRenderTargetsToolStripMenuItem.Size = new System.Drawing.Size(668, 22);
			this.noRenderTargetsKnownEitherTheApplicationHasNotYetBeenSuspendedOrItDoesNotUseAnyRenderTargetsToolStripMenuItem.Text = "No render targets known. Either the application has not yet been suspended or it " +
				"does not use any render targets.";
			// 
			// RenderTargetsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(489, 334);
			this.Controls.Add(this.renderTargetData);
			this.Controls.Add(this.toolStrip1);
			this.Name = "RenderTargetsView";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private QAlbum.ScalablePictureBox renderTargetData;
		private System.Windows.Forms.ToolStripDropDownButton renderTargetsButton;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox updateIntervalComboBox;
		private System.Windows.Forms.ToolStripMenuItem noRenderTargetsKnownEitherTheApplicationHasNotYetBeenSuspendedOrItDoesNotUseAnyRenderTargetsToolStripMenuItem;
	}
}
