﻿namespace Infrastructure.UserInterface.WinForms
{
	partial class WpfDockView<TWpfUserControl>
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
			this.wpfHost = new System.Windows.Forms.Integration.ElementHost();
			this.SuspendLayout();
			// 
			// wpfHost
			// 
			this.wpfHost.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wpfHost.Location = new System.Drawing.Point(0, 0);
			this.wpfHost.Name = "wpfHost";
			this.wpfHost.Size = new System.Drawing.Size(284, 264);
			this.wpfHost.TabIndex = 0;
			this.wpfHost.Child = null;
			// 
			// WpfDockView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 264);
			this.Controls.Add(this.wpfHost);
			this.Name = "WpfDockView";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Integration.ElementHost wpfHost;
	}
}
