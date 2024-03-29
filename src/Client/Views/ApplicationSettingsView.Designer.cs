namespace Client.Views
{
	partial class ApplicationSettingsView
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
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.executableTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.dllTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.workingDirectoryTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.communicationAddressTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonCheckBox1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonTextBox4 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.contentDirectoryTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.utilsDllTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.utilsDllButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.contentDirectoryButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
			this.workingDirectoryButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
			this.dllButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
			this.executableButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Location = new System.Drawing.Point(12, 10);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(99, 22);
			this.kryptonLabel1.TabIndex = 0;
			this.kryptonLabel1.Text = "Executable Path:";
			this.kryptonLabel1.Values.ExtraText = "";
			this.kryptonLabel1.Values.Image = null;
			this.kryptonLabel1.Values.Text = "Executable Path:";
			// 
			// executableTextBox
			// 
			this.executableTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.executableTextBox.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.executableButton});
			this.executableTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ExecutablePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.executableTextBox.Location = new System.Drawing.Point(159, 10);
			this.executableTextBox.Name = "executableTextBox";
			this.executableTextBox.Size = new System.Drawing.Size(371, 24);
			this.executableTextBox.TabIndex = 1;
			this.executableTextBox.Text = "kryptonTextBox1";
			// 
			// dllTextBox
			// 
			this.dllTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dllTextBox.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.dllButton});
			this.dllTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OriginalHorde3DDllPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.dllTextBox.Location = new System.Drawing.Point(159, 38);
			this.dllTextBox.Name = "dllTextBox";
			this.dllTextBox.Size = new System.Drawing.Size(371, 24);
			this.dllTextBox.TabIndex = 2;
			this.dllTextBox.Text = "kryptonTextBox2";
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.Location = new System.Drawing.Point(12, 38);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.Size = new System.Drawing.Size(106, 22);
			this.kryptonLabel2.TabIndex = 2;
			this.kryptonLabel2.Text = "Horde3D.dll Path:";
			this.kryptonLabel2.Values.ExtraText = "";
			this.kryptonLabel2.Values.Image = null;
			this.kryptonLabel2.Values.Text = "Horde3D.dll Path:";
			// 
			// workingDirectoryTextBox
			// 
			this.workingDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.workingDirectoryTextBox.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.workingDirectoryButton});
			this.workingDirectoryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "WorkingDirectory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.workingDirectoryTextBox.Location = new System.Drawing.Point(159, 94);
			this.workingDirectoryTextBox.Name = "workingDirectoryTextBox";
			this.workingDirectoryTextBox.Size = new System.Drawing.Size(371, 24);
			this.workingDirectoryTextBox.TabIndex = 4;
			this.workingDirectoryTextBox.Text = "kryptonTextBox3";
			// 
			// kryptonLabel3
			// 
			this.kryptonLabel3.Location = new System.Drawing.Point(12, 94);
			this.kryptonLabel3.Name = "kryptonLabel3";
			this.kryptonLabel3.Size = new System.Drawing.Size(113, 22);
			this.kryptonLabel3.TabIndex = 4;
			this.kryptonLabel3.Text = "Working Directory:";
			this.kryptonLabel3.Values.ExtraText = "";
			this.kryptonLabel3.Values.Image = null;
			this.kryptonLabel3.Values.Text = "Working Directory:";
			// 
			// communicationAddressTextBox
			// 
			this.communicationAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.communicationAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CommunicationAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.communicationAddressTextBox.Location = new System.Drawing.Point(159, 174);
			this.communicationAddressTextBox.Name = "communicationAddressTextBox";
			this.communicationAddressTextBox.Size = new System.Drawing.Size(371, 20);
			this.communicationAddressTextBox.TabIndex = 7;
			this.communicationAddressTextBox.Text = "kryptonTextBox5";
			// 
			// kryptonLabel5
			// 
			this.kryptonLabel5.Location = new System.Drawing.Point(12, 174);
			this.kryptonLabel5.Name = "kryptonLabel5";
			this.kryptonLabel5.Size = new System.Drawing.Size(147, 22);
			this.kryptonLabel5.TabIndex = 8;
			this.kryptonLabel5.Text = "Communication Address:";
			this.kryptonLabel5.Values.ExtraText = "";
			this.kryptonLabel5.Values.Image = null;
			this.kryptonLabel5.Values.Text = "Communication Address:";
			// 
			// kryptonCheckBox1
			// 
			this.kryptonCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "LaunchDebugger", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.kryptonCheckBox1.Location = new System.Drawing.Point(18, 200);
			this.kryptonCheckBox1.Name = "kryptonCheckBox1";
			this.kryptonCheckBox1.Size = new System.Drawing.Size(321, 22);
			this.kryptonCheckBox1.TabIndex = 8;
			this.kryptonCheckBox1.Text = "Attach debugger when the Horde3D application starts.";
			this.kryptonCheckBox1.Values.ExtraText = "";
			this.kryptonCheckBox1.Values.Image = null;
			this.kryptonCheckBox1.Values.Text = "Attach debugger when the Horde3D application starts.";
			// 
			// kryptonLabel4
			// 
			this.kryptonLabel4.Location = new System.Drawing.Point(12, 150);
			this.kryptonLabel4.Name = "kryptonLabel4";
			this.kryptonLabel4.Size = new System.Drawing.Size(73, 22);
			this.kryptonLabel4.TabIndex = 6;
			this.kryptonLabel4.Text = "Arguments:";
			this.kryptonLabel4.Values.ExtraText = "";
			this.kryptonLabel4.Values.Image = null;
			this.kryptonLabel4.Values.Text = "Arguments:";
			// 
			// kryptonTextBox4
			// 
			this.kryptonTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonTextBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Arguments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.kryptonTextBox4.Location = new System.Drawing.Point(159, 150);
			this.kryptonTextBox4.Name = "kryptonTextBox4";
			this.kryptonTextBox4.Size = new System.Drawing.Size(371, 20);
			this.kryptonTextBox4.TabIndex = 6;
			this.kryptonTextBox4.Text = "kryptonTextBox4";
			// 
			// contentDirectoryTextBox
			// 
			this.contentDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.contentDirectoryTextBox.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.contentDirectoryButton});
			this.contentDirectoryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContentDirectory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.contentDirectoryTextBox.Location = new System.Drawing.Point(159, 122);
			this.contentDirectoryTextBox.Name = "contentDirectoryTextBox";
			this.contentDirectoryTextBox.Size = new System.Drawing.Size(371, 24);
			this.contentDirectoryTextBox.TabIndex = 5;
			this.contentDirectoryTextBox.Text = "kryptonTextBox1";
			// 
			// kryptonLabel6
			// 
			this.kryptonLabel6.Location = new System.Drawing.Point(12, 122);
			this.kryptonLabel6.Name = "kryptonLabel6";
			this.kryptonLabel6.Size = new System.Drawing.Size(110, 22);
			this.kryptonLabel6.TabIndex = 11;
			this.kryptonLabel6.Text = "Content Directory:";
			this.kryptonLabel6.Values.ExtraText = "";
			this.kryptonLabel6.Values.Image = null;
			this.kryptonLabel6.Values.Text = "Content Directory:";
			// 
			// utilsDllTextBox
			// 
			this.utilsDllTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.utilsDllTextBox.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.utilsDllButton});
			this.utilsDllTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OriginalHorde3DUtilsDllPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.utilsDllTextBox.Location = new System.Drawing.Point(159, 66);
			this.utilsDllTextBox.Name = "utilsDllTextBox";
			this.utilsDllTextBox.Size = new System.Drawing.Size(371, 24);
			this.utilsDllTextBox.TabIndex = 3;
			this.utilsDllTextBox.Text = "kryptonTextBox3";
			// 
			// kryptonLabel7
			// 
			this.kryptonLabel7.Location = new System.Drawing.Point(12, 66);
			this.kryptonLabel7.Name = "kryptonLabel7";
			this.kryptonLabel7.Size = new System.Drawing.Size(130, 22);
			this.kryptonLabel7.TabIndex = 13;
			this.kryptonLabel7.Text = "Horde3DUtils.dll Path:";
			this.kryptonLabel7.Values.ExtraText = "";
			this.kryptonLabel7.Values.Image = null;
			this.kryptonLabel7.Values.Text = "Horde3DUtils.dll Path:";
			// 
			// utilsDllButton
			// 
			this.utilsDllButton.ExtraText = "";
			this.utilsDllButton.Image = global::Client.Properties.Resources.Folder;
			this.utilsDllButton.Text = "";
			this.utilsDllButton.UniqueName = "CBCD4F97EC574444CBCD4F97EC574444";
			this.utilsDllButton.Click += new System.EventHandler(this.utilsDllButton_Click);
			// 
			// bindingSource
			// 
			this.bindingSource.DataSource = typeof(Client.Models.Horde3DApplication);
			// 
			// contentDirectoryButton
			// 
			this.contentDirectoryButton.ExtraText = "";
			this.contentDirectoryButton.Image = global::Client.Properties.Resources.Folder;
			this.contentDirectoryButton.Text = "";
			this.contentDirectoryButton.UniqueName = "EF842AE9BADD4B50EF842AE9BADD4B50";
			this.contentDirectoryButton.Click += new System.EventHandler(this.contentDirectoryButton_Click);
			// 
			// workingDirectoryButton
			// 
			this.workingDirectoryButton.ExtraText = "";
			this.workingDirectoryButton.Image = global::Client.Properties.Resources.Folder;
			this.workingDirectoryButton.Text = "";
			this.workingDirectoryButton.UniqueName = "CBCD4F97EC574444CBCD4F97EC574444";
			this.workingDirectoryButton.Click += new System.EventHandler(this.workingDirectoryButton_Click);
			// 
			// dllButton
			// 
			this.dllButton.ExtraText = "";
			this.dllButton.Image = global::Client.Properties.Resources.Folder;
			this.dllButton.Text = "";
			this.dllButton.UniqueName = "DB9197D21F634B69DB9197D21F634B69";
			this.dllButton.Click += new System.EventHandler(this.dllButton_Click);
			// 
			// executableButton
			// 
			this.executableButton.ExtraText = "";
			this.executableButton.Image = global::Client.Properties.Resources.Folder;
			this.executableButton.Text = "";
			this.executableButton.UniqueName = "5451545879A6413E5451545879A6413E";
			this.executableButton.Click += new System.EventHandler(this.executableButton_Click);
			// 
			// ApplicationSettingsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(542, 236);
			this.Controls.Add(this.utilsDllTextBox);
			this.Controls.Add(this.kryptonLabel7);
			this.Controls.Add(this.contentDirectoryTextBox);
			this.Controls.Add(this.kryptonLabel6);
			this.Controls.Add(this.kryptonCheckBox1);
			this.Controls.Add(this.communicationAddressTextBox);
			this.Controls.Add(this.kryptonLabel5);
			this.Controls.Add(this.kryptonTextBox4);
			this.Controls.Add(this.kryptonLabel4);
			this.Controls.Add(this.workingDirectoryTextBox);
			this.Controls.Add(this.kryptonLabel3);
			this.Controls.Add(this.dllTextBox);
			this.Controls.Add(this.kryptonLabel2);
			this.Controls.Add(this.executableTextBox);
			this.Controls.Add(this.kryptonLabel1);
			this.Name = "ApplicationSettingsView";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox executableTextBox;
		private System.Windows.Forms.BindingSource bindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox dllTextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox workingDirectoryTextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox communicationAddressTextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kryptonCheckBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox4;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny executableButton;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny dllButton;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny workingDirectoryButton;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox contentDirectoryTextBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny contentDirectoryButton;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox utilsDllTextBox;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny utilsDllButton;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
	}
}
