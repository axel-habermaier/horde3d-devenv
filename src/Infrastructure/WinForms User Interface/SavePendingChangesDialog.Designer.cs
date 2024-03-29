namespace Infrastructure.UserInterface.WinForms
{
	partial class SavePendingChangesDialog
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
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.documentsList = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.yesButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.noButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.cancelButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.cancelButton);
			this.kryptonPanel1.Controls.Add(this.noButton);
			this.kryptonPanel1.Controls.Add(this.yesButton);
			this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
			this.kryptonPanel1.Controls.Add(this.documentsList);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(375, 302);
			this.kryptonPanel1.TabIndex = 0;
			// 
			// documentsList
			// 
			this.documentsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.documentsList.Location = new System.Drawing.Point(12, 40);
			this.documentsList.Name = "documentsList";
			this.documentsList.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
			this.documentsList.Size = new System.Drawing.Size(347, 210);
			this.documentsList.TabIndex = 0;
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(212, 22);
			this.kryptonLabel1.TabIndex = 1;
			this.kryptonLabel1.Text = "Save changes to the following items?";
			this.kryptonLabel1.Values.ExtraText = "";
			this.kryptonLabel1.Values.Image = null;
			this.kryptonLabel1.Values.Text = "Save changes to the following items?";
			// 
			// yesButton
			// 
			this.yesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.yesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.yesButton.Location = new System.Drawing.Point(122, 265);
			this.yesButton.Name = "yesButton";
			this.yesButton.Size = new System.Drawing.Size(75, 25);
			this.yesButton.TabIndex = 2;
			this.yesButton.Text = "Yes";
			this.yesButton.Values.ExtraText = "";
			this.yesButton.Values.Image = null;
			this.yesButton.Values.ImageStates.ImageCheckedNormal = null;
			this.yesButton.Values.ImageStates.ImageCheckedPressed = null;
			this.yesButton.Values.ImageStates.ImageCheckedTracking = null;
			this.yesButton.Values.Text = "Yes";
			// 
			// noButton
			// 
			this.noButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.noButton.DialogResult = System.Windows.Forms.DialogResult.No;
			this.noButton.Location = new System.Drawing.Point(203, 265);
			this.noButton.Name = "noButton";
			this.noButton.Size = new System.Drawing.Size(75, 25);
			this.noButton.TabIndex = 3;
			this.noButton.Text = "No";
			this.noButton.Values.ExtraText = "";
			this.noButton.Values.Image = null;
			this.noButton.Values.ImageStates.ImageCheckedNormal = null;
			this.noButton.Values.ImageStates.ImageCheckedPressed = null;
			this.noButton.Values.ImageStates.ImageCheckedTracking = null;
			this.noButton.Values.Text = "No";
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(284, 265);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 25);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Values.ExtraText = "";
			this.cancelButton.Values.Image = null;
			this.cancelButton.Values.ImageStates.ImageCheckedNormal = null;
			this.cancelButton.Values.ImageStates.ImageCheckedPressed = null;
			this.cancelButton.Values.ImageStates.ImageCheckedTracking = null;
			this.cancelButton.Values.Text = "Cancel";
			// 
			// SavePendingChangesDialog
			// 
			this.AcceptButton = this.yesButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(375, 302);
			this.Controls.Add(this.kryptonPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SavePendingChangesDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Horde3D Development Environment";
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonListBox documentsList;
		private ComponentFactory.Krypton.Toolkit.KryptonButton cancelButton;
		private ComponentFactory.Krypton.Toolkit.KryptonButton noButton;
		private ComponentFactory.Krypton.Toolkit.KryptonButton yesButton;
	}
}