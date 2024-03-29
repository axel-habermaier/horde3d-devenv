namespace Infrastructure.CodeGenerator.Views
{
	partial class SettingsDetailsView
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
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.cppTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.cppButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
			this.csharpTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.csharpButton = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
			this.csharpFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.cppFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(152, 20);
			this.kryptonLabel1.TabIndex = 0;
			this.kryptonLabel1.Text = "Generated C++ Code File:";
			this.kryptonLabel1.Values.ExtraText = "";
			this.kryptonLabel1.Values.Image = null;
			this.kryptonLabel1.Values.Text = "Generated C++ Code File:";
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.Location = new System.Drawing.Point(12, 40);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.Size = new System.Drawing.Size(142, 20);
			this.kryptonLabel2.TabIndex = 1;
			this.kryptonLabel2.Text = "Generated C# Code File:";
			this.kryptonLabel2.Values.ExtraText = "";
			this.kryptonLabel2.Values.Image = null;
			this.kryptonLabel2.Values.Text = "Generated C# Code File:";
			// 
			// cppTextBox
			// 
			this.cppTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cppTextBox.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.cppButton});
			this.cppTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GeneratedCppCodeFilePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cppTextBox.Location = new System.Drawing.Point(170, 12);
			this.cppTextBox.Name = "cppTextBox";
			this.cppTextBox.Size = new System.Drawing.Size(325, 21);
			this.cppTextBox.TabIndex = 2;
			// 
			// cppButton
			// 
			this.cppButton.ExtraText = "";
			this.cppButton.Image = global::Infrastructure.CodeGenerator.Properties.Resources.Open;
			this.cppButton.Text = "";
			this.cppButton.UniqueName = "A725B4E41F804BD8A725B4E41F804BD8";
			this.cppButton.Click += new System.EventHandler(this.cppButton_Click);
			// 
			// csharpTextBox
			// 
			this.csharpTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.csharpTextBox.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.csharpButton});
			this.csharpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GeneratedCSharpCodeFilePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.csharpTextBox.Location = new System.Drawing.Point(170, 41);
			this.csharpTextBox.Name = "csharpTextBox";
			this.csharpTextBox.Size = new System.Drawing.Size(325, 21);
			this.csharpTextBox.TabIndex = 3;
			// 
			// csharpButton
			// 
			this.csharpButton.ExtraText = "";
			this.csharpButton.Image = global::Infrastructure.CodeGenerator.Properties.Resources.Open;
			this.csharpButton.Text = "";
			this.csharpButton.UniqueName = "A725B4E41F804BD8A725B4E41F804BD8";
			this.csharpButton.Click += new System.EventHandler(this.csharpButton_Click);
			// 
			// csharpFileDialog
			// 
			this.csharpFileDialog.CheckFileExists = true;
			this.csharpFileDialog.CreatePrompt = true;
			this.csharpFileDialog.Filter = "C# Files|*.cs";
			// 
			// cppFileDialog
			// 
			this.cppFileDialog.CheckFileExists = true;
			this.cppFileDialog.CreatePrompt = true;
			this.cppFileDialog.Filter = "C++ Header Files|*.h";
			// 
			// kryptonTextBox1
			// 
			this.kryptonTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Horde3DVersion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.kryptonTextBox1.Location = new System.Drawing.Point(170, 67);
			this.kryptonTextBox1.Name = "kryptonTextBox1";
			this.kryptonTextBox1.Size = new System.Drawing.Size(325, 20);
			this.kryptonTextBox1.TabIndex = 5;
			// 
			// kryptonLabel3
			// 
			this.kryptonLabel3.Location = new System.Drawing.Point(12, 66);
			this.kryptonLabel3.Name = "kryptonLabel3";
			this.kryptonLabel3.Size = new System.Drawing.Size(107, 20);
			this.kryptonLabel3.TabIndex = 4;
			this.kryptonLabel3.Text = "Horde3D Version:";
			this.kryptonLabel3.Values.ExtraText = "";
			this.kryptonLabel3.Values.Image = null;
			this.kryptonLabel3.Values.Text = "Horde3D Version:";
			// 
			// bindingSource
			// 
			this.bindingSource.DataSource = typeof(Infrastructure.CodeGenerator.Logic.CodeGenerationSettings);
			// 
			// SettingsDetailsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(518, 97);
			this.Controls.Add(this.kryptonTextBox1);
			this.Controls.Add(this.kryptonLabel3);
			this.Controls.Add(this.csharpTextBox);
			this.Controls.Add(this.cppTextBox);
			this.Controls.Add(this.kryptonLabel2);
			this.Controls.Add(this.kryptonLabel1);
			this.Name = "SettingsDetailsView";
			this.Text = "Code Generation Settings";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.BindingSource bindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox cppTextBox;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny cppButton;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox csharpTextBox;
		private ComponentFactory.Krypton.Toolkit.ButtonSpecAny csharpButton;
		private System.Windows.Forms.SaveFileDialog csharpFileDialog;
		private System.Windows.Forms.SaveFileDialog cppFileDialog;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;

	}
}
