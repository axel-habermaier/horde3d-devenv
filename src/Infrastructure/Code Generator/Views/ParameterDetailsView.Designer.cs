namespace Infrastructure.CodeGenerator.Views
{
	partial class ParameterDetailsView
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
			this.typePanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.parameterNameLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.positionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			((System.ComponentModel.ISupportInitialize)(this.typePanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// typePanel
			// 
			this.typePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.typePanel.Location = new System.Drawing.Point(0, 51);
			this.typePanel.Name = "typePanel";
			this.typePanel.Size = new System.Drawing.Size(387, 233);
			this.typePanel.TabIndex = 1;
			// 
			// kryptonPanel1
			// 
			this.kryptonPanel1.Controls.Add(this.positionLabel);
			this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
			this.kryptonPanel1.Controls.Add(this.parameterNameLabel);
			this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
			this.kryptonPanel1.Controls.Add(this.typePanel);
			this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new System.Drawing.Size(387, 284);
			this.kryptonPanel1.TabIndex = 2;
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Location = new System.Drawing.Point(12, 10);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(105, 22);
			this.kryptonLabel1.TabIndex = 2;
			this.kryptonLabel1.Text = "Parameter Name:";
			this.kryptonLabel1.Values.ExtraText = "";
			this.kryptonLabel1.Values.Image = null;
			this.kryptonLabel1.Values.Text = "Parameter Name:";
			// 
			// parameterNameLabel
			// 
			this.parameterNameLabel.Location = new System.Drawing.Point(114, 10);
			this.parameterNameLabel.Name = "parameterNameLabel";
			this.parameterNameLabel.Size = new System.Drawing.Size(41, 22);
			this.parameterNameLabel.TabIndex = 3;
			this.parameterNameLabel.Text = "name";
			this.parameterNameLabel.Values.ExtraText = "";
			this.parameterNameLabel.Values.Image = null;
			this.parameterNameLabel.Values.Text = "name";
			// 
			// positionLabel
			// 
			this.positionLabel.Location = new System.Drawing.Point(114, 38);
			this.positionLabel.Name = "positionLabel";
			this.positionLabel.Size = new System.Drawing.Size(17, 22);
			this.positionLabel.TabIndex = 5;
			this.positionLabel.Text = "0";
			this.positionLabel.Values.ExtraText = "";
			this.positionLabel.Values.Image = null;
			this.positionLabel.Values.Text = "0";
			// 
			// kryptonLabel3
			// 
			this.kryptonLabel3.Location = new System.Drawing.Point(12, 38);
			this.kryptonLabel3.Name = "kryptonLabel3";
			this.kryptonLabel3.Size = new System.Drawing.Size(57, 22);
			this.kryptonLabel3.TabIndex = 4;
			this.kryptonLabel3.Text = "Position:";
			this.kryptonLabel3.Values.ExtraText = "";
			this.kryptonLabel3.Values.Image = null;
			this.kryptonLabel3.Values.Text = "Position:";
			// 
			// ParameterDetailsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.kryptonPanel1);
			this.Name = "ParameterDetailsView";
			this.Size = new System.Drawing.Size(387, 284);
			((System.ComponentModel.ISupportInitialize)(this.typePanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonPanel typePanel;
		private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel parameterNameLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel positionLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
	}
}
