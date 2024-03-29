namespace Infrastructure.CodeGenerator.Views
{
	partial class TypeDetailsView
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
			this.settingsPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.csharpTypeComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.problemSolvedCheckBox = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.conversionSettingsGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
			this.conversionCode = new ICSharpCode.TextEditor.TextEditorControl();
			this.conversionComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.typeNameLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.noProblemsLinkLabel = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.noProblemsLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			((System.ComponentModel.ISupportInitialize)(this.settingsPanel)).BeginInit();
			this.settingsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.conversionSettingsGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.conversionSettingsGroup.Panel)).BeginInit();
			this.conversionSettingsGroup.Panel.SuspendLayout();
			this.conversionSettingsGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// settingsPanel
			// 
			this.settingsPanel.Controls.Add(this.csharpTypeComboBox);
			this.settingsPanel.Controls.Add(this.problemSolvedCheckBox);
			this.settingsPanel.Controls.Add(this.kryptonLabel3);
			this.settingsPanel.Controls.Add(this.conversionSettingsGroup);
			this.settingsPanel.Controls.Add(this.conversionComboBox);
			this.settingsPanel.Controls.Add(this.kryptonLabel2);
			this.settingsPanel.Controls.Add(this.kryptonLabel1);
			this.settingsPanel.Controls.Add(this.typeNameLabel);
			this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.settingsPanel.Location = new System.Drawing.Point(0, 0);
			this.settingsPanel.Name = "settingsPanel";
			this.settingsPanel.Size = new System.Drawing.Size(532, 127);
			this.settingsPanel.TabIndex = 0;
			// 
			// csharpTypeComboBox
			// 
			this.csharpTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.csharpTypeComboBox.DropDownWidth = 188;
			this.csharpTypeComboBox.FormattingEnabled = false;
			this.csharpTypeComboBox.Location = new System.Drawing.Point(118, 43);
			this.csharpTypeComboBox.Name = "csharpTypeComboBox";
			this.csharpTypeComboBox.Size = new System.Drawing.Size(188, 21);
			this.csharpTypeComboBox.TabIndex = 8;
			// 
			// problemSolvedCheckBox
			// 
			this.problemSolvedCheckBox.Location = new System.Drawing.Point(17, 97);
			this.problemSolvedCheckBox.Name = "problemSolvedCheckBox";
			this.problemSolvedCheckBox.Size = new System.Drawing.Size(258, 22);
			this.problemSolvedCheckBox.TabIndex = 7;
			this.problemSolvedCheckBox.Text = "Mark type conversion problem as resolved.";
			this.problemSolvedCheckBox.Values.ExtraText = "";
			this.problemSolvedCheckBox.Values.Image = null;
			this.problemSolvedCheckBox.Values.Text = "Mark type conversion problem as resolved.";
			// 
			// kryptonLabel3
			// 
			this.kryptonLabel3.Location = new System.Drawing.Point(12, 13);
			this.kryptonLabel3.Name = "kryptonLabel3";
			this.kryptonLabel3.Size = new System.Drawing.Size(67, 22);
			this.kryptonLabel3.TabIndex = 6;
			this.kryptonLabel3.Text = "C++ Type:";
			this.kryptonLabel3.Values.ExtraText = "";
			this.kryptonLabel3.Values.Image = null;
			this.kryptonLabel3.Values.Text = "C++ Type:";
			// 
			// conversionSettingsGroup
			// 
			this.conversionSettingsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.conversionSettingsGroup.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
			this.conversionSettingsGroup.HeaderVisibleSecondary = false;
			this.conversionSettingsGroup.Location = new System.Drawing.Point(324, 13);
			this.conversionSettingsGroup.Name = "conversionSettingsGroup";
			// 
			// conversionSettingsGroup.Panel
			// 
			this.conversionSettingsGroup.Panel.Controls.Add(this.conversionCode);
			this.conversionSettingsGroup.Size = new System.Drawing.Size(194, 101);
			this.conversionSettingsGroup.TabIndex = 5;
			this.conversionSettingsGroup.Text = "Custom Conversion Code";
			this.conversionSettingsGroup.ValuesPrimary.Description = "";
			this.conversionSettingsGroup.ValuesPrimary.Heading = "Custom Conversion Code";
			this.conversionSettingsGroup.ValuesPrimary.Image = global::Infrastructure.CodeGenerator.Properties.Resources.Code;
			this.conversionSettingsGroup.ValuesSecondary.Description = "";
			this.conversionSettingsGroup.ValuesSecondary.Heading = "Description";
			this.conversionSettingsGroup.ValuesSecondary.Image = null;
			// 
			// conversionCode
			// 
			this.conversionCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.conversionCode.IsReadOnly = false;
			this.conversionCode.Location = new System.Drawing.Point(0, 0);
			this.conversionCode.Name = "conversionCode";
			this.conversionCode.ShowVRuler = false;
			this.conversionCode.Size = new System.Drawing.Size(192, 76);
			this.conversionCode.TabIndex = 0;
			// 
			// conversionComboBox
			// 
			this.conversionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.conversionComboBox.DropDownWidth = 188;
			this.conversionComboBox.FormattingEnabled = false;
			this.conversionComboBox.Location = new System.Drawing.Point(118, 70);
			this.conversionComboBox.Name = "conversionComboBox";
			this.conversionComboBox.Size = new System.Drawing.Size(188, 21);
			this.conversionComboBox.TabIndex = 4;
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.Location = new System.Drawing.Point(12, 69);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.Size = new System.Drawing.Size(74, 22);
			this.kryptonLabel2.TabIndex = 3;
			this.kryptonLabel2.Text = "Conversion:";
			this.kryptonLabel2.Values.ExtraText = "";
			this.kryptonLabel2.Values.Image = null;
			this.kryptonLabel2.Values.Text = "Conversion:";
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Location = new System.Drawing.Point(12, 41);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(67, 22);
			this.kryptonLabel1.TabIndex = 1;
			this.kryptonLabel1.Text = ".NET Type:";
			this.kryptonLabel1.Values.ExtraText = "";
			this.kryptonLabel1.Values.Image = null;
			this.kryptonLabel1.Values.Text = ".NET Type:";
			// 
			// typeNameLabel
			// 
			this.typeNameLabel.Location = new System.Drawing.Point(114, 13);
			this.typeNameLabel.Name = "typeNameLabel";
			this.typeNameLabel.Size = new System.Drawing.Size(41, 22);
			this.typeNameLabel.TabIndex = 0;
			this.typeNameLabel.Text = "name";
			this.typeNameLabel.Values.ExtraText = "";
			this.typeNameLabel.Values.Image = null;
			this.typeNameLabel.Values.Text = "name";
			// 
			// noProblemsLinkLabel
			// 
			this.noProblemsLinkLabel.Location = new System.Drawing.Point(12, 37);
			this.noProblemsLinkLabel.Name = "noProblemsLinkLabel";
			this.noProblemsLinkLabel.Size = new System.Drawing.Size(263, 22);
			this.noProblemsLinkLabel.TabIndex = 8;
			this.noProblemsLinkLabel.Text = "Click here if you want to change them anyway.";
			this.noProblemsLinkLabel.Values.ExtraText = "";
			this.noProblemsLinkLabel.Values.Image = null;
			this.noProblemsLinkLabel.Values.Text = "Click here if you want to change them anyway.";
			this.noProblemsLinkLabel.LinkClicked += new System.EventHandler(this.noProblemsLinkLabel_LinkClicked);
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.noProblemsLinkLabel);
			this.kryptonPanel1.Controls.Add(this.settingsPanel);
			this.kryptonPanel1.Controls.Add(this.noProblemsLabel);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(532, 127);
			this.kryptonPanel1.TabIndex = 8;
			// 
			// noProblemsLabel
			// 
			this.noProblemsLabel.Location = new System.Drawing.Point(11, 14);
			this.noProblemsLabel.Name = "noProblemsLabel";
			this.noProblemsLabel.Size = new System.Drawing.Size(581, 22);
			this.noProblemsLabel.TabIndex = 0;
			this.noProblemsLabel.Text = "The type conversion seems unproblematic. It should not be necessary to change any" +
				" conversion settings.";
			this.noProblemsLabel.Values.ExtraText = "";
			this.noProblemsLabel.Values.Image = null;
			this.noProblemsLabel.Values.Text = "The type conversion seems unproblematic. It should not be necessary to change any" +
				" conversion settings.";
			// 
			// TypeDetailsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.kryptonPanel1);
			this.Name = "TypeDetailsView";
			this.Size = new System.Drawing.Size(532, 127);
			((System.ComponentModel.ISupportInitialize)(this.settingsPanel)).EndInit();
			this.settingsPanel.ResumeLayout(false);
			this.settingsPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.conversionSettingsGroup.Panel)).EndInit();
			this.conversionSettingsGroup.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.conversionSettingsGroup)).EndInit();
			this.conversionSettingsGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonPanel settingsPanel;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel typeNameLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox conversionComboBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup conversionSettingsGroup;
		private ICSharpCode.TextEditor.TextEditorControl conversionCode;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox problemSolvedCheckBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel noProblemsLinkLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox csharpTypeComboBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel noProblemsLabel;

	}
}
