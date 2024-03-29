namespace Client.Views.Resources
{
	partial class SamplerView
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
			this.filteringModeComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.addressModeComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonTextBox3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.stageConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.samplerBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.group)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.group.Panel)).BeginInit();
			this.group.Panel.SuspendLayout();
			this.group.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stageConfigBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.samplerBindingSource)).BeginInit();
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
			this.group.Panel.Controls.Add(this.filteringModeComboBox);
			this.group.Panel.Controls.Add(this.addressModeComboBox);
			this.group.Panel.Controls.Add(this.kryptonLabel6);
			this.group.Panel.Controls.Add(this.kryptonLabel5);
			this.group.Panel.Controls.Add(this.kryptonLabel4);
			this.group.Panel.Controls.Add(this.kryptonTextBox3);
			this.group.Panel.Controls.Add(this.kryptonLabel2);
			this.group.Panel.Controls.Add(this.kryptonTextBox2);
			this.group.Size = new System.Drawing.Size(324, 167);
			this.group.TabIndex = 0;
			this.group.Text = "Sampler";
			this.group.ValuesPrimary.Description = "";
			this.group.ValuesPrimary.Heading = "Sampler";
			this.group.ValuesPrimary.Image = global::Client.Properties.Resources.Sampler;
			this.group.ValuesSecondary.Description = "";
			this.group.ValuesSecondary.Heading = "Description";
			this.group.ValuesSecondary.Image = null;
			// 
			// filteringModeComboBox
			// 
			this.filteringModeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.stageConfigBindingSource, "FilteringMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.filteringModeComboBox.DropBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
			this.filteringModeComboBox.DropButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.InputControl;
			this.filteringModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.filteringModeComboBox.DropDownWidth = 121;
			this.filteringModeComboBox.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
			this.filteringModeComboBox.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem;
			this.filteringModeComboBox.Location = new System.Drawing.Point(150, 93);
			this.filteringModeComboBox.Name = "filteringModeComboBox";
			this.filteringModeComboBox.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.filteringModeComboBox.Size = new System.Drawing.Size(133, 21);
			this.filteringModeComboBox.TabIndex = 10;
			// 
			// addressModeComboBox
			// 
			this.addressModeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.stageConfigBindingSource, "AddressMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.addressModeComboBox.DropBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
			this.addressModeComboBox.DropButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.InputControl;
			this.addressModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.addressModeComboBox.DropDownWidth = 121;
			this.addressModeComboBox.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
			this.addressModeComboBox.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem;
			this.addressModeComboBox.Location = new System.Drawing.Point(150, 66);
			this.addressModeComboBox.Name = "addressModeComboBox";
			this.addressModeComboBox.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.addressModeComboBox.Size = new System.Drawing.Size(133, 21);
			this.addressModeComboBox.TabIndex = 9;
			// 
			// kryptonLabel6
			// 
			this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
			this.kryptonLabel6.Location = new System.Drawing.Point(14, 93);
			this.kryptonLabel6.Name = "kryptonLabel6";
			this.kryptonLabel6.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonLabel6.Size = new System.Drawing.Size(93, 20);
			this.kryptonLabel6.TabIndex = 8;
			this.kryptonLabel6.Text = "Filtering Mode:";
			this.kryptonLabel6.Values.ExtraText = "";
			this.kryptonLabel6.Values.Image = null;
			this.kryptonLabel6.Values.Text = "Filtering Mode:";
			// 
			// kryptonLabel5
			// 
			this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
			this.kryptonLabel5.Location = new System.Drawing.Point(14, 65);
			this.kryptonLabel5.Name = "kryptonLabel5";
			this.kryptonLabel5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonLabel5.Size = new System.Drawing.Size(92, 20);
			this.kryptonLabel5.TabIndex = 7;
			this.kryptonLabel5.Text = "Address Mode:";
			this.kryptonLabel5.Values.ExtraText = "";
			this.kryptonLabel5.Values.Image = null;
			this.kryptonLabel5.Values.Text = "Address Mode:";
			// 
			// kryptonLabel4
			// 
			this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
			this.kryptonLabel4.Location = new System.Drawing.Point(14, 37);
			this.kryptonLabel4.Name = "kryptonLabel4";
			this.kryptonLabel4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonLabel4.Size = new System.Drawing.Size(130, 20);
			this.kryptonLabel4.TabIndex = 6;
			this.kryptonLabel4.Text = "Maximum Anisotropy:";
			this.kryptonLabel4.Values.ExtraText = "";
			this.kryptonLabel4.Values.Image = null;
			this.kryptonLabel4.Values.Text = "Maximum Anisotropy:";
			// 
			// kryptonTextBox3
			// 
			this.kryptonTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stageConfigBindingSource, "MaxAnisotropy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.kryptonTextBox3.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
			this.kryptonTextBox3.Location = new System.Drawing.Point(150, 39);
			this.kryptonTextBox3.Name = "kryptonTextBox3";
			this.kryptonTextBox3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonTextBox3.Size = new System.Drawing.Size(133, 20);
			this.kryptonTextBox3.TabIndex = 5;
			this.kryptonTextBox3.Text = "kryptonTextBox3";
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
			this.kryptonLabel2.Location = new System.Drawing.Point(14, 12);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonLabel2.Size = new System.Drawing.Size(80, 20);
			this.kryptonLabel2.TabIndex = 3;
			this.kryptonLabel2.Text = "Texture Unit:";
			this.kryptonLabel2.Values.ExtraText = "";
			this.kryptonLabel2.Values.Image = null;
			this.kryptonLabel2.Values.Text = "Texture Unit:";
			// 
			// kryptonTextBox2
			// 
			this.kryptonTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.samplerBindingSource, "TexUnit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.kryptonTextBox2.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Standalone;
			this.kryptonTextBox2.Location = new System.Drawing.Point(150, 12);
			this.kryptonTextBox2.Name = "kryptonTextBox2";
			this.kryptonTextBox2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonTextBox2.Size = new System.Drawing.Size(133, 20);
			this.kryptonTextBox2.TabIndex = 2;
			this.kryptonTextBox2.Text = "kryptonTextBox2";
			// 
			// stageConfigBindingSource
			// 
			this.stageConfigBindingSource.DataSource = typeof(Infrastructure.Core.Resources.SamplerStageConfig);
			// 
			// samplerBindingSource
			// 
			this.samplerBindingSource.DataSource = typeof(Infrastructure.Core.Resources.ShaderSampler);
			// 
			// SamplerView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.group);
			this.Name = "SamplerView";
			this.Size = new System.Drawing.Size(324, 167);
			((System.ComponentModel.ISupportInitialize)(this.group.Panel)).EndInit();
			this.group.Panel.ResumeLayout(false);
			this.group.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.group)).EndInit();
			this.group.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.stageConfigBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.samplerBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.BindingSource samplerBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup group;
		private System.Windows.Forms.BindingSource stageConfigBindingSource;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox filteringModeComboBox;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox addressModeComboBox;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
	}
}
