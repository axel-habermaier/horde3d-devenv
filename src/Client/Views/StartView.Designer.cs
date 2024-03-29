namespace Client.Views
{
	partial class StartView
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
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
			this.openSampleLink = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
			this.openLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.createLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.openLink = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
			this.createLink = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
			this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
			this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
			this.multilineLabel = new Infrastructure.UserInterface.WinForms.MultilineLabel();
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
			this.kryptonHeaderGroup1.Panel.SuspendLayout();
			this.kryptonHeaderGroup1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
			this.kryptonSplitContainer1.Panel1.SuspendLayout();
			this.kryptonSplitContainer1.Panel2.SuspendLayout();
			this.kryptonSplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
			this.kryptonHeaderGroup2.Panel.SuspendLayout();
			this.kryptonHeaderGroup2.SuspendLayout();
			this.SuspendLayout();
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
			this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(495, 27);
			this.kryptonLabel1.TabIndex = 1;
			this.kryptonLabel1.Values.Image = global::Client.Properties.Resources.StartPage;
			this.kryptonLabel1.Values.Text = "Welcome to the Horde3D Development Environment!";
			// 
			// kryptonHeaderGroup1
			// 
			this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
			this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
			this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
			this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
			// 
			// kryptonHeaderGroup1.Panel
			// 
			this.kryptonHeaderGroup1.Panel.Controls.Add(this.openSampleLink);
			this.kryptonHeaderGroup1.Panel.Controls.Add(this.openLabel);
			this.kryptonHeaderGroup1.Panel.Controls.Add(this.createLabel);
			this.kryptonHeaderGroup1.Panel.Controls.Add(this.openLink);
			this.kryptonHeaderGroup1.Panel.Controls.Add(this.createLink);
			this.kryptonHeaderGroup1.Size = new System.Drawing.Size(200, 390);
			this.kryptonHeaderGroup1.TabIndex = 3;
			this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Applications";
			this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
			// 
			// openSampleLink
			// 
			this.openSampleLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.openSampleLink.Location = new System.Drawing.Point(84, 49);
			this.openSampleLink.Name = "openSampleLink";
			this.openSampleLink.Size = new System.Drawing.Size(90, 22);
			this.openSampleLink.TabIndex = 5;
			this.openSampleLink.Values.Text = "Knight Sample";
			this.openSampleLink.LinkClicked += new System.EventHandler(this.openSampleLink_LinkClicked);
			// 
			// openLabel
			// 
			this.openLabel.Location = new System.Drawing.Point(3, 31);
			this.openLabel.Name = "openLabel";
			this.openLabel.Size = new System.Drawing.Size(60, 22);
			this.openLabel.TabIndex = 4;
			this.openLabel.Values.Image = global::Client.Properties.Resources.OpenApplication;
			this.openLabel.Values.Text = "Open:";
			// 
			// createLabel
			// 
			this.createLabel.Location = new System.Drawing.Point(3, 3);
			this.createLabel.Name = "createLabel";
			this.createLabel.Size = new System.Drawing.Size(66, 22);
			this.createLabel.TabIndex = 3;
			this.createLabel.Values.Image = global::Client.Properties.Resources.CreateApplication;
			this.createLabel.Values.Text = "Create:";
			// 
			// openLink
			// 
			this.openLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.openLink.Location = new System.Drawing.Point(84, 31);
			this.openLink.Name = "openLink";
			this.openLink.Size = new System.Drawing.Size(80, 22);
			this.openLink.TabIndex = 2;
			this.openLink.Values.Text = "Application...";
			this.openLink.LinkClicked += new System.EventHandler(this.openLink_LinkClicked);
			// 
			// createLink
			// 
			this.createLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.createLink.Location = new System.Drawing.Point(84, 3);
			this.createLink.Name = "createLink";
			this.createLink.Size = new System.Drawing.Size(80, 22);
			this.createLink.TabIndex = 1;
			this.createLink.Values.Text = "Application...";
			this.createLink.LinkClicked += new System.EventHandler(this.createLink_LinkClicked);
			// 
			// kryptonSplitContainer1
			// 
			this.kryptonSplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
			this.kryptonSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.kryptonSplitContainer1.IsSplitterFixed = true;
			this.kryptonSplitContainer1.Location = new System.Drawing.Point(12, 45);
			this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
			// 
			// kryptonSplitContainer1.Panel1
			// 
			this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonHeaderGroup1);
			this.kryptonSplitContainer1.Panel1MinSize = 200;
			// 
			// kryptonSplitContainer1.Panel2
			// 
			this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonHeaderGroup2);
			this.kryptonSplitContainer1.Panel2MinSize = 250;
			this.kryptonSplitContainer1.Size = new System.Drawing.Size(693, 390);
			this.kryptonSplitContainer1.SplitterDistance = 200;
			this.kryptonSplitContainer1.TabIndex = 4;
			// 
			// kryptonHeaderGroup2
			// 
			this.kryptonHeaderGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonHeaderGroup2.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
			this.kryptonHeaderGroup2.HeaderVisibleSecondary = false;
			this.kryptonHeaderGroup2.Location = new System.Drawing.Point(0, 0);
			this.kryptonHeaderGroup2.Name = "kryptonHeaderGroup2";
			// 
			// kryptonHeaderGroup2.Panel
			// 
			this.kryptonHeaderGroup2.Panel.Controls.Add(this.multilineLabel);
			this.kryptonHeaderGroup2.Size = new System.Drawing.Size(488, 390);
			this.kryptonHeaderGroup2.TabIndex = 4;
			this.kryptonHeaderGroup2.ValuesPrimary.Heading = "Overview";
			this.kryptonHeaderGroup2.ValuesPrimary.Image = null;
			// 
			// multilineLabel
			// 
			this.multilineLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.multilineLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.multilineLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.multilineLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.multilineLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
			this.multilineLabel.Location = new System.Drawing.Point(0, 0);
			this.multilineLabel.Name = "multilineLabel";
			this.multilineLabel.Size = new System.Drawing.Size(486, 365);
			this.multilineLabel.TabIndex = 2;
			this.multilineLabel.Text = "";
			// 
			// StartView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(717, 447);
			this.Controls.Add(this.kryptonSplitContainer1);
			this.Controls.Add(this.kryptonLabel1);
			this.Name = "StartView";
			this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
			this.kryptonHeaderGroup1.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
			this.kryptonHeaderGroup1.ResumeLayout(false);
			this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
			this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
			this.kryptonSplitContainer1.ResumeLayout(false);
			this.kryptonHeaderGroup2.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
			this.kryptonHeaderGroup2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
		private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
		private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel openLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel createLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel openLink;
		private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel createLink;
		private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel openSampleLink;
		private Infrastructure.UserInterface.WinForms.MultilineLabel multilineLabel;


	}
}
