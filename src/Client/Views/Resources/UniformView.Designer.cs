namespace Client.Views.Resources
{
	partial class UniformView
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
			this.group = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
			this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonTextBox5 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonTextBox4 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonTextBox3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.group)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.group.Panel)).BeginInit();
			this.group.Panel.SuspendLayout();
			this.group.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// group
			// 
			this.group.CollapseTarget = ComponentFactory.Krypton.Toolkit.HeaderGroupCollapsedTarget.CollapsedToPrimary;
			this.group.Dock = System.Windows.Forms.DockStyle.Fill;
			this.group.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
			this.group.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlClient;
			this.group.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
			this.group.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
			this.group.HeaderVisibleSecondary = false;
			this.group.Location = new System.Drawing.Point(0, 0);
			this.group.Name = "group";
			this.group.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			// 
			// group.Panel
			// 
			this.group.Panel.Controls.Add(this.kryptonLabel5);
			this.group.Panel.Controls.Add(this.kryptonTextBox5);
			this.group.Panel.Controls.Add(this.kryptonLabel4);
			this.group.Panel.Controls.Add(this.kryptonTextBox4);
			this.group.Panel.Controls.Add(this.kryptonLabel3);
			this.group.Panel.Controls.Add(this.kryptonTextBox3);
			this.group.Panel.Controls.Add(this.kryptonLabel2);
			this.group.Panel.Controls.Add(this.kryptonTextBox2);
			this.group.Size = new System.Drawing.Size(325, 154);
			this.group.TabIndex = 0;
			this.group.Text = "Heading";
			this.group.ValuesPrimary.Description = "";
			this.group.ValuesPrimary.Heading = "Heading";
			this.group.ValuesPrimary.Image = global::Client.Properties.Resources.Uniform;
			this.group.ValuesSecondary.Description = "";
			this.group.ValuesSecondary.Heading = "Description";
			this.group.ValuesSecondary.Image = null;
			// 
			// kryptonLabel5
			// 
			this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
			this.kryptonLabel5.Location = new System.Drawing.Point(13, 97);
			this.kryptonLabel5.Name = "kryptonLabel5";
			this.kryptonLabel5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonLabel5.Size = new System.Drawing.Size(146, 20);
			this.kryptonLabel5.TabIndex = 11;
			this.kryptonLabel5.Text = "Default Value Channel D:";
			this.kryptonLabel5.Values.ExtraText = "";
			this.kryptonLabel5.Values.Image = null;
			this.kryptonLabel5.Values.Text = "Default Value Channel D:";
			// 
			// kryptonTextBox5
			// 
			this.kryptonTextBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "D", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.kryptonTextBox5.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
			this.kryptonTextBox5.Location = new System.Drawing.Point(165, 97);
			this.kryptonTextBox5.Name = "kryptonTextBox5";
			this.kryptonTextBox5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonTextBox5.Size = new System.Drawing.Size(133, 20);
			this.kryptonTextBox5.TabIndex = 10;
			this.kryptonTextBox5.Text = "kryptonTextBox5";
			// 
			// kryptonLabel4
			// 
			this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
			this.kryptonLabel4.Location = new System.Drawing.Point(13, 69);
			this.kryptonLabel4.Name = "kryptonLabel4";
			this.kryptonLabel4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonLabel4.Size = new System.Drawing.Size(145, 20);
			this.kryptonLabel4.TabIndex = 9;
			this.kryptonLabel4.Text = "Default Value Channel C:";
			this.kryptonLabel4.Values.ExtraText = "";
			this.kryptonLabel4.Values.Image = null;
			this.kryptonLabel4.Values.Text = "Default Value Channel C:";
			// 
			// kryptonTextBox4
			// 
			this.kryptonTextBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "C", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.kryptonTextBox4.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
			this.kryptonTextBox4.Location = new System.Drawing.Point(165, 69);
			this.kryptonTextBox4.Name = "kryptonTextBox4";
			this.kryptonTextBox4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonTextBox4.Size = new System.Drawing.Size(133, 20);
			this.kryptonTextBox4.TabIndex = 8;
			this.kryptonTextBox4.Text = "kryptonTextBox4";
			// 
			// kryptonLabel3
			// 
			this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
			this.kryptonLabel3.Location = new System.Drawing.Point(13, 41);
			this.kryptonLabel3.Name = "kryptonLabel3";
			this.kryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonLabel3.Size = new System.Drawing.Size(145, 20);
			this.kryptonLabel3.TabIndex = 7;
			this.kryptonLabel3.Text = "Default Value Channel B:";
			this.kryptonLabel3.Values.ExtraText = "";
			this.kryptonLabel3.Values.Image = null;
			this.kryptonLabel3.Values.Text = "Default Value Channel B:";
			// 
			// kryptonTextBox3
			// 
			this.kryptonTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "B", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.kryptonTextBox3.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
			this.kryptonTextBox3.Location = new System.Drawing.Point(165, 41);
			this.kryptonTextBox3.Name = "kryptonTextBox3";
			this.kryptonTextBox3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonTextBox3.Size = new System.Drawing.Size(133, 20);
			this.kryptonTextBox3.TabIndex = 6;
			this.kryptonTextBox3.Text = "kryptonTextBox3";
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
			this.kryptonLabel2.Location = new System.Drawing.Point(13, 13);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonLabel2.Size = new System.Drawing.Size(146, 20);
			this.kryptonLabel2.TabIndex = 5;
			this.kryptonLabel2.Text = "Default Value Channel A:";
			this.kryptonLabel2.Values.ExtraText = "";
			this.kryptonLabel2.Values.Image = null;
			this.kryptonLabel2.Values.Text = "Default Value Channel A:";
			// 
			// kryptonTextBox2
			// 
			this.kryptonTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "A", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.kryptonTextBox2.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
			this.kryptonTextBox2.Location = new System.Drawing.Point(165, 13);
			this.kryptonTextBox2.Name = "kryptonTextBox2";
			this.kryptonTextBox2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonTextBox2.Size = new System.Drawing.Size(133, 20);
			this.kryptonTextBox2.TabIndex = 4;
			this.kryptonTextBox2.Text = "kryptonTextBox2";
			// 
			// bindingSource
			// 
			this.bindingSource.DataSource = typeof(Infrastructure.Core.Resources.ShaderUniform);
			// 
			// UniformView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.group);
			this.Name = "UniformView";
			this.Size = new System.Drawing.Size(325, 154);
			((System.ComponentModel.ISupportInitialize)(this.group.Panel)).EndInit();
			this.group.Panel.ResumeLayout(false);
			this.group.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.group)).EndInit();
			this.group.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup group;
		private System.Windows.Forms.BindingSource bindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox5;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox4;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox3;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
	}
}
