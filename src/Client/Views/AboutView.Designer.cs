namespace Client.Views
{
	partial class AboutView
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
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.closeButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.SuspendLayout();
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitlePanel;
			this.kryptonLabel1.Location = new System.Drawing.Point(33, 22);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonLabel1.Size = new System.Drawing.Size(357, 27);
			this.kryptonLabel1.StateCommon.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
			this.kryptonLabel1.TabIndex = 0;
			this.kryptonLabel1.Text = "  Horde3D Development Environment";
			this.kryptonLabel1.Values.ExtraText = "";
			this.kryptonLabel1.Values.Image = global::Client.Properties.Resources.Logo;
			this.kryptonLabel1.Values.Text = "  Horde3D Development Environment";
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
			this.kryptonLabel2.Location = new System.Drawing.Point(64, 55);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonLabel2.Size = new System.Drawing.Size(147, 54);
			this.kryptonLabel2.TabIndex = 1;
			this.kryptonLabel2.Text = "(c) 2009 Axel Habermaier\r\nBachelor Thesis\r\nUniversity of Augsburg";
			this.kryptonLabel2.Values.ExtraText = "";
			this.kryptonLabel2.Values.Image = null;
			this.kryptonLabel2.Values.Text = "(c) 2009 Axel Habermaier\r\nBachelor Thesis\r\nUniversity of Augsburg";
			// 
			// closeButton
			// 
			this.closeButton.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
			this.closeButton.Location = new System.Drawing.Point(300, 138);
			this.closeButton.Name = "closeButton";
			this.closeButton.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.closeButton.Size = new System.Drawing.Size(90, 25);
			this.closeButton.TabIndex = 2;
			this.closeButton.Text = "Close";
			this.closeButton.Values.ExtraText = "";
			this.closeButton.Values.Image = null;
			this.closeButton.Values.ImageStates.ImageCheckedNormal = null;
			this.closeButton.Values.ImageStates.ImageCheckedPressed = null;
			this.closeButton.Values.ImageStates.ImageCheckedTracking = null;
			this.closeButton.Values.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// AboutView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 175);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.kryptonLabel2);
			this.Controls.Add(this.kryptonLabel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About Code Generator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonButton closeButton;
	}
}