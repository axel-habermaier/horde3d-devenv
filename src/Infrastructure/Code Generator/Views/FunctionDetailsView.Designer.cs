namespace Infrastructure.CodeGenerator.Views
{
	partial class FunctionDetailsView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionDetailsView));
			this.tabControl = new System.Windows.Forms.TabControl();
			this.returnTypePage = new System.Windows.Forms.TabPage();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.functionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.removeOldFunctionLinkLabel = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
			this.kryptonBorderEdge1 = new ComponentFactory.Krypton.Toolkit.KryptonBorderEdge();
			this.showOldFunctionButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.noProfilingProxyPreview = new ICSharpCode.TextEditor.TextEditorControl();
			this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
			this.codePreviewTabs = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.profilingProxyPreview = new ICSharpCode.TextEditor.TextEditorControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.csharpPreview = new ICSharpCode.TextEditor.TextEditorControl();
			this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
			this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
			this.tabControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
			this.kryptonHeaderGroup1.Panel.SuspendLayout();
			this.kryptonHeaderGroup1.SuspendLayout();
			this.codePreviewTabs.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
			this.kryptonSplitContainer1.Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
			this.kryptonSplitContainer1.Panel2.SuspendLayout();
			this.kryptonSplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).BeginInit();
			this.kryptonHeaderGroup2.Panel.SuspendLayout();
			this.kryptonHeaderGroup2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.returnTypePage);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.ImageList = this.imageList;
			this.tabControl.Location = new System.Drawing.Point(5, 5);
			this.tabControl.Margin = new System.Windows.Forms.Padding(10);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(648, 245);
			this.tabControl.TabIndex = 0;
			// 
			// returnTypePage
			// 
			this.returnTypePage.Location = new System.Drawing.Point(4, 23);
			this.returnTypePage.Name = "returnTypePage";
			this.returnTypePage.Padding = new System.Windows.Forms.Padding(3);
			this.returnTypePage.Size = new System.Drawing.Size(640, 218);
			this.returnTypePage.TabIndex = 0;
			this.returnTypePage.Text = "Return Type";
			this.returnTypePage.UseVisualStyleBackColor = true;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Method.png");
			this.imageList.Images.SetKeyName(1, "ProblematicMethod.png");
			this.imageList.Images.SetKeyName(2, "ResolvedMethod.png");
			// 
			// functionLabel
			// 
			this.functionLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
			this.functionLabel.Location = new System.Drawing.Point(12, 12);
			this.functionLabel.Name = "functionLabel";
			this.functionLabel.Size = new System.Drawing.Size(86, 27);
			this.functionLabel.TabIndex = 1;
			this.functionLabel.Text = "function";
			this.functionLabel.Values.ExtraText = "";
			this.functionLabel.Values.Image = null;
			this.functionLabel.Values.Text = "function";
			// 
			// removeOldFunctionLinkLabel
			// 
			this.removeOldFunctionLinkLabel.Location = new System.Drawing.Point(12, 71);
			this.removeOldFunctionLinkLabel.Name = "removeOldFunctionLinkLabel";
			this.removeOldFunctionLinkLabel.Size = new System.Drawing.Size(491, 22);
			this.removeOldFunctionLinkLabel.TabIndex = 3;
			this.removeOldFunctionLinkLabel.Text = "Remove the old code generation settings. This marks the update problem(s) as reso" +
				"lved.";
			this.removeOldFunctionLinkLabel.Values.ExtraText = "";
			this.removeOldFunctionLinkLabel.Values.Image = null;
			this.removeOldFunctionLinkLabel.Values.Text = "Remove the old code generation settings. This marks the update problem(s) as reso" +
				"lved.";
			this.removeOldFunctionLinkLabel.Click += new System.EventHandler(this.removeOldFunctionLinkLabel_LinkClicked);
			// 
			// kryptonBorderEdge1
			// 
			this.kryptonBorderEdge1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonBorderEdge1.AutoSize = false;
			this.kryptonBorderEdge1.Location = new System.Drawing.Point(16, 40);
			this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
			this.kryptonBorderEdge1.Size = new System.Drawing.Size(652, 1);
			this.kryptonBorderEdge1.TabIndex = 4;
			this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
			// 
			// showOldFunctionButton
			// 
			this.showOldFunctionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.showOldFunctionButton.Location = new System.Drawing.Point(16, 47);
			this.showOldFunctionButton.Name = "showOldFunctionButton";
			this.showOldFunctionButton.Size = new System.Drawing.Size(652, 25);
			this.showOldFunctionButton.TabIndex = 5;
			this.showOldFunctionButton.Text = "Click to view the code generation settings for this function before the update.";
			this.showOldFunctionButton.Values.ExtraText = "";
			this.showOldFunctionButton.Values.Image = null;
			this.showOldFunctionButton.Values.ImageStates.ImageCheckedNormal = null;
			this.showOldFunctionButton.Values.ImageStates.ImageCheckedPressed = null;
			this.showOldFunctionButton.Values.ImageStates.ImageCheckedTracking = null;
			this.showOldFunctionButton.Values.Text = "Click to view the code generation settings for this function before the update.";
			this.showOldFunctionButton.Click += new System.EventHandler(this.showOldFunctionButton_Click);
			// 
			// noProfilingProxyPreview
			// 
			this.noProfilingProxyPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.noProfilingProxyPreview.IsReadOnly = false;
			this.noProfilingProxyPreview.Location = new System.Drawing.Point(3, 3);
			this.noProfilingProxyPreview.Name = "noProfilingProxyPreview";
			this.noProfilingProxyPreview.ShowVRuler = false;
			this.noProfilingProxyPreview.Size = new System.Drawing.Size(644, 103);
			this.noProfilingProxyPreview.TabIndex = 6;
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
			this.kryptonHeaderGroup1.Panel.Controls.Add(this.codePreviewTabs);
			this.kryptonHeaderGroup1.Size = new System.Drawing.Size(660, 160);
			this.kryptonHeaderGroup1.TabIndex = 7;
			this.kryptonHeaderGroup1.Text = "Generated Code";
			this.kryptonHeaderGroup1.ValuesPrimary.Description = "";
			this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Generated Code";
			this.kryptonHeaderGroup1.ValuesPrimary.Image = global::Infrastructure.CodeGenerator.Properties.Resources.Code;
			this.kryptonHeaderGroup1.ValuesSecondary.Description = "";
			this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Description";
			this.kryptonHeaderGroup1.ValuesSecondary.Image = null;
			// 
			// codePreviewTabs
			// 
			this.codePreviewTabs.Controls.Add(this.tabPage1);
			this.codePreviewTabs.Controls.Add(this.tabPage2);
			this.codePreviewTabs.Controls.Add(this.tabPage3);
			this.codePreviewTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.codePreviewTabs.Location = new System.Drawing.Point(0, 0);
			this.codePreviewTabs.Name = "codePreviewTabs";
			this.codePreviewTabs.SelectedIndex = 0;
			this.codePreviewTabs.Size = new System.Drawing.Size(658, 135);
			this.codePreviewTabs.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.noProfilingProxyPreview);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(650, 109);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "C++ No Profiling Proxy";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.profilingProxyPreview);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(650, 109);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "C++ Profiling Proxy";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// profilingProxyPreview
			// 
			this.profilingProxyPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.profilingProxyPreview.IsReadOnly = false;
			this.profilingProxyPreview.Location = new System.Drawing.Point(3, 3);
			this.profilingProxyPreview.Name = "profilingProxyPreview";
			this.profilingProxyPreview.ShowVRuler = false;
			this.profilingProxyPreview.Size = new System.Drawing.Size(644, 103);
			this.profilingProxyPreview.TabIndex = 7;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.csharpPreview);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(650, 109);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "C# Code";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// csharpPreview
			// 
			this.csharpPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.csharpPreview.IsReadOnly = false;
			this.csharpPreview.Location = new System.Drawing.Point(3, 3);
			this.csharpPreview.Name = "csharpPreview";
			this.csharpPreview.ShowVRuler = false;
			this.csharpPreview.Size = new System.Drawing.Size(644, 103);
			this.csharpPreview.TabIndex = 7;
			// 
			// kryptonSplitContainer1
			// 
			this.kryptonSplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
			this.kryptonSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.kryptonSplitContainer1.Location = new System.Drawing.Point(12, 99);
			this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
			this.kryptonSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// kryptonSplitContainer1.Panel1
			// 
			this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonHeaderGroup2);
			this.kryptonSplitContainer1.Panel1MinSize = 280;
			// 
			// kryptonSplitContainer1.Panel2
			// 
			this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonHeaderGroup1);
			this.kryptonSplitContainer1.Size = new System.Drawing.Size(660, 445);
			this.kryptonSplitContainer1.SplitterDistance = 280;
			this.kryptonSplitContainer1.TabIndex = 8;
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
			this.kryptonHeaderGroup2.Panel.Controls.Add(this.tabControl);
			this.kryptonHeaderGroup2.Panel.Padding = new System.Windows.Forms.Padding(5);
			this.kryptonHeaderGroup2.Size = new System.Drawing.Size(660, 280);
			this.kryptonHeaderGroup2.TabIndex = 9;
			this.kryptonHeaderGroup2.Text = "Type Settings";
			this.kryptonHeaderGroup2.ValuesPrimary.Description = "";
			this.kryptonHeaderGroup2.ValuesPrimary.Heading = "Type Settings";
			this.kryptonHeaderGroup2.ValuesPrimary.Image = global::Infrastructure.CodeGenerator.Properties.Resources.Properties;
			this.kryptonHeaderGroup2.ValuesSecondary.Description = "";
			this.kryptonHeaderGroup2.ValuesSecondary.Heading = "Description";
			this.kryptonHeaderGroup2.ValuesSecondary.Image = null;
			// 
			// FunctionDetailsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 556);
			this.Controls.Add(this.kryptonSplitContainer1);
			this.Controls.Add(this.showOldFunctionButton);
			this.Controls.Add(this.kryptonBorderEdge1);
			this.Controls.Add(this.removeOldFunctionLinkLabel);
			this.Controls.Add(this.functionLabel);
			this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)
						| WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
						| WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
						| WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
			this.Name = "FunctionDetailsView";
			this.Text = "Test";
			this.tabControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
			this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
			this.kryptonHeaderGroup1.ResumeLayout(false);
			this.codePreviewTabs.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
			this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
			this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
			this.kryptonSplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).EndInit();
			this.kryptonHeaderGroup2.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
			this.kryptonHeaderGroup2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage returnTypePage;
		private System.Windows.Forms.ImageList imageList;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel functionLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel removeOldFunctionLinkLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonBorderEdge kryptonBorderEdge1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton showOldFunctionButton;
		private ICSharpCode.TextEditor.TextEditorControl noProfilingProxyPreview;
		private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
		private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
		private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
		private System.Windows.Forms.TabControl codePreviewTabs;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private ICSharpCode.TextEditor.TextEditorControl profilingProxyPreview;
		private ICSharpCode.TextEditor.TextEditorControl csharpPreview;

	}
}
