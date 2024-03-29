namespace Client.Views
{
	partial class ConsoleOutputView
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
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.categoriesComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.textBox = new ICSharpCode.TextEditor.TextEditorControl();
			this.clearAllButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.categoriesComboBox,
            this.toolStripSeparator1,
            this.clearAllButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(511, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(58, 22);
			this.toolStripLabel1.Text = "Category:";
			// 
			// categoriesComboBox
			// 
			this.categoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.categoriesComboBox.Name = "categoriesComboBox";
			this.categoriesComboBox.Size = new System.Drawing.Size(121, 25);
			this.categoriesComboBox.SelectedIndexChanged += new System.EventHandler(this.categoriesComboBox_SelectedIndexChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// textBox
			// 
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.IsReadOnly = false;
			this.textBox.Location = new System.Drawing.Point(0, 28);
			this.textBox.Name = "textBox";
			this.textBox.ShowLineNumbers = false;
			this.textBox.ShowMatchingBracket = false;
			this.textBox.ShowVRuler = false;
			this.textBox.Size = new System.Drawing.Size(511, 234);
			this.textBox.TabIndex = 2;
			this.textBox.VRulerRow = 2000;
			// 
			// clearAllButton
			// 
			this.clearAllButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.clearAllButton.Image = global::Client.Properties.Resources.ClearAll;
			this.clearAllButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.clearAllButton.Name = "clearAllButton";
			this.clearAllButton.Size = new System.Drawing.Size(23, 22);
			this.clearAllButton.Text = "Clear All";
			this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
			// 
			// ConsoleOutputView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 264);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.toolStrip1);
			this.DoubleBuffered = true;
			this.Name = "ConsoleOutputView";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox categoriesComboBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private ICSharpCode.TextEditor.TextEditorControl textBox;
		private System.Windows.Forms.ToolStripButton clearAllButton;



	}
}
