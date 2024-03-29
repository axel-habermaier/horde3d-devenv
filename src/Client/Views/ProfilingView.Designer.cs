namespace Client.Views
{
	partial class ProfilingView
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.historyGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.CallTime = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
			this.HistoryFunctionName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
			this.HistoryExecutionTime = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.searchTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.clearSearchButton = new System.Windows.Forms.ToolStripButton();
			this.profileToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.listTypeComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.graphComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
			this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
			this.tableEmptyLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.profilingDataGridView = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.NumCalls = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
			this.AverageFunctionName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
			this.AverageExecutionTime = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
			this.TotalExecutionTime = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
			this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
			this.graphEmptyLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.historyGridView)).BeginInit();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
			this.kryptonSplitContainer1.Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
			this.kryptonSplitContainer1.Panel2.SuspendLayout();
			this.kryptonSplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
			this.kryptonHeaderGroup1.Panel.SuspendLayout();
			this.kryptonHeaderGroup1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.profilingDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).BeginInit();
			this.kryptonHeaderGroup2.Panel.SuspendLayout();
			this.kryptonHeaderGroup2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
			this.SuspendLayout();
			// 
			// historyGridView
			// 
			this.historyGridView.AllowUserToAddRows = false;
			this.historyGridView.AllowUserToDeleteRows = false;
			this.historyGridView.AllowUserToResizeColumns = false;
			this.historyGridView.AllowUserToResizeRows = false;
			this.historyGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CallTime,
            this.HistoryFunctionName,
            this.HistoryExecutionTime});
			this.historyGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.historyGridView.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.List;
			this.historyGridView.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
			this.historyGridView.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.List;
			this.historyGridView.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.List;
			this.historyGridView.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.List;
			this.historyGridView.HideOuterBorders = true;
			this.historyGridView.Location = new System.Drawing.Point(0, 0);
			this.historyGridView.MultiSelect = false;
			this.historyGridView.Name = "historyGridView";
			this.historyGridView.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.historyGridView.ReadOnly = true;
			this.historyGridView.RowHeadersVisible = false;
			this.historyGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.historyGridView.Size = new System.Drawing.Size(429, 305);
			this.historyGridView.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
			this.historyGridView.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.historyGridView.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.historyGridView.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.historyGridView.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.historyGridView.TabIndex = 1;
			// 
			// CallTime
			// 
			this.CallTime.DataPropertyName = "CallTime";
			this.CallTime.HeaderText = "Call Time";
			this.CallTime.Name = "CallTime";
			this.CallTime.ReadOnly = true;
			this.CallTime.ToolTipText = "The relative point in time (in µs) of the function call.";
			this.CallTime.Width = 70;
			// 
			// HistoryFunctionName
			// 
			this.HistoryFunctionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.HistoryFunctionName.DataPropertyName = "FunctionName";
			this.HistoryFunctionName.HeaderText = "Function";
			this.HistoryFunctionName.Name = "HistoryFunctionName";
			this.HistoryFunctionName.ReadOnly = true;
			this.HistoryFunctionName.ToolTipText = "The name of the function.";
			// 
			// HistoryExecutionTime
			// 
			this.HistoryExecutionTime.DataPropertyName = "ExecutionTime";
			this.HistoryExecutionTime.HeaderText = "Execution Time (µs)";
			this.HistoryExecutionTime.Name = "HistoryExecutionTime";
			this.HistoryExecutionTime.ReadOnly = true;
			this.HistoryExecutionTime.ToolTipText = "The time (in µs) in took to execute the function.";
			this.HistoryExecutionTime.Width = 140;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.searchTextBox,
            this.toolStripSeparator1,
            this.clearSearchButton,
            this.profileToolStripButton,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.listTypeComboBox,
            this.toolStripSeparator3,
            this.toolStripLabel3,
            this.graphComboBox});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(914, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
			this.toolStripLabel1.Text = "Search:";
			// 
			// searchTextBox
			// 
			this.searchTextBox.Name = "searchTextBox";
			this.searchTextBox.Size = new System.Drawing.Size(150, 25);
			this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// clearSearchButton
			// 
			this.clearSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.clearSearchButton.Image = global::Client.Properties.Resources.ClearAll;
			this.clearSearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.clearSearchButton.Name = "clearSearchButton";
			this.clearSearchButton.Size = new System.Drawing.Size(23, 22);
			this.clearSearchButton.Text = "Clear Search";
			this.clearSearchButton.Click += new System.EventHandler(this.clearSearchButton_Click);
			// 
			// profileToolStripButton
			// 
			this.profileToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.profileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.profileToolStripButton.Enabled = false;
			this.profileToolStripButton.Image = global::Client.Properties.Resources.Profiling;
			this.profileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.profileToolStripButton.Name = "profileToolStripButton";
			this.profileToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.profileToolStripButton.Text = "Profile Horde3D Function Calls (F8)";
			this.profileToolStripButton.Click += new System.EventHandler(this.profileToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(59, 22);
			this.toolStripLabel2.Text = "Overview:";
			// 
			// listTypeComboBox
			// 
			this.listTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.listTypeComboBox.Items.AddRange(new object[] {
            "Statistics",
            "History"});
			this.listTypeComboBox.Name = "listTypeComboBox";
			this.listTypeComboBox.Size = new System.Drawing.Size(80, 25);
			this.listTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.listTypeComboBox_SelectedIndexChanged);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel3
			// 
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(42, 22);
			this.toolStripLabel3.Text = "Graph:";
			// 
			// graphComboBox
			// 
			this.graphComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.graphComboBox.Items.AddRange(new object[] {
            "Top 5 Average Execution Time",
            "Top 5 Invocations",
            "Top 5 Total Execution Time"});
			this.graphComboBox.Name = "graphComboBox";
			this.graphComboBox.Size = new System.Drawing.Size(190, 25);
			this.graphComboBox.SelectedIndexChanged += new System.EventHandler(this.graphComboBox_SelectedIndexChanged);
			// 
			// kryptonSplitContainer1
			// 
			this.kryptonSplitContainer1.ContainerBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelClient;
			this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
			this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 25);
			this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
			this.kryptonSplitContainer1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			// 
			// kryptonSplitContainer1.Panel1
			// 
			this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonHeaderGroup1);
			this.kryptonSplitContainer1.Panel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonSplitContainer1.Panel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelClient;
			// 
			// kryptonSplitContainer1.Panel2
			// 
			this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonHeaderGroup2);
			this.kryptonSplitContainer1.Panel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.kryptonSplitContainer1.Panel2.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelClient;
			this.kryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.LowProfile;
			this.kryptonSplitContainer1.Size = new System.Drawing.Size(914, 330);
			this.kryptonSplitContainer1.SplitterDistance = 431;
			this.kryptonSplitContainer1.TabIndex = 3;
			// 
			// kryptonHeaderGroup1
			// 
			this.kryptonHeaderGroup1.CollapseTarget = ComponentFactory.Krypton.Toolkit.HeaderGroupCollapsedTarget.CollapsedToPrimary;
			this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonHeaderGroup1.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
			this.kryptonHeaderGroup1.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlClient;
			this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
			this.kryptonHeaderGroup1.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
			this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
			this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
			this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
			this.kryptonHeaderGroup1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			// 
			// kryptonHeaderGroup1.Panel
			// 
			this.kryptonHeaderGroup1.Panel.Controls.Add(this.tableEmptyLabel);
			this.kryptonHeaderGroup1.Panel.Controls.Add(this.historyGridView);
			this.kryptonHeaderGroup1.Panel.Controls.Add(this.profilingDataGridView);
			this.kryptonHeaderGroup1.Size = new System.Drawing.Size(431, 330);
			this.kryptonHeaderGroup1.TabIndex = 4;
			this.kryptonHeaderGroup1.Text = "Horde3D Function Call Overview";
			this.kryptonHeaderGroup1.ValuesPrimary.Description = "";
			this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Horde3D Function Call Overview";
			this.kryptonHeaderGroup1.ValuesPrimary.Image = global::Client.Properties.Resources.Function;
			this.kryptonHeaderGroup1.ValuesSecondary.Description = "";
			this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Description";
			this.kryptonHeaderGroup1.ValuesSecondary.Image = null;
			// 
			// tableEmptyLabel
			// 
			this.tableEmptyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableEmptyLabel.AutoSize = false;
			this.tableEmptyLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
			this.tableEmptyLabel.Location = new System.Drawing.Point(-4, 28);
			this.tableEmptyLabel.Name = "tableEmptyLabel";
			this.tableEmptyLabel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.tableEmptyLabel.Size = new System.Drawing.Size(433, 25);
			this.tableEmptyLabel.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
			this.tableEmptyLabel.TabIndex = 3;
			this.tableEmptyLabel.Text = "No Profiling Data available.";
			this.tableEmptyLabel.Values.ExtraText = "";
			this.tableEmptyLabel.Values.Image = null;
			this.tableEmptyLabel.Values.Text = "No Profiling Data available.";
			// 
			// profilingDataGridView
			// 
			this.profilingDataGridView.AllowUserToAddRows = false;
			this.profilingDataGridView.AllowUserToDeleteRows = false;
			this.profilingDataGridView.AllowUserToResizeColumns = false;
			this.profilingDataGridView.AllowUserToResizeRows = false;
			this.profilingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumCalls,
            this.AverageFunctionName,
            this.AverageExecutionTime,
            this.TotalExecutionTime});
			this.profilingDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.profilingDataGridView.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.List;
			this.profilingDataGridView.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
			this.profilingDataGridView.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.List;
			this.profilingDataGridView.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.List;
			this.profilingDataGridView.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.List;
			this.profilingDataGridView.HideOuterBorders = true;
			this.profilingDataGridView.Location = new System.Drawing.Point(0, 0);
			this.profilingDataGridView.MultiSelect = false;
			this.profilingDataGridView.Name = "profilingDataGridView";
			this.profilingDataGridView.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.profilingDataGridView.ReadOnly = true;
			this.profilingDataGridView.RowHeadersVisible = false;
			this.profilingDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.profilingDataGridView.Size = new System.Drawing.Size(429, 305);
			this.profilingDataGridView.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
			this.profilingDataGridView.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.profilingDataGridView.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.profilingDataGridView.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.profilingDataGridView.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.profilingDataGridView.TabIndex = 2;
			this.profilingDataGridView.Visible = false;
			// 
			// NumCalls
			// 
			this.NumCalls.DataPropertyName = "NumCalls";
			this.NumCalls.HeaderText = "# Calls";
			this.NumCalls.Name = "NumCalls";
			this.NumCalls.ReadOnly = true;
			this.NumCalls.ToolTipText = "The number of times the function was called.";
			this.NumCalls.Width = 70;
			// 
			// AverageFunctionName
			// 
			this.AverageFunctionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.AverageFunctionName.DataPropertyName = "FunctionName";
			this.AverageFunctionName.HeaderText = "Function";
			this.AverageFunctionName.Name = "AverageFunctionName";
			this.AverageFunctionName.ReadOnly = true;
			this.AverageFunctionName.ToolTipText = "The name of the function.";
			// 
			// AverageExecutionTime
			// 
			this.AverageExecutionTime.DataPropertyName = "AverageExecutionTime";
			this.AverageExecutionTime.HeaderText = "Average Execution Time (µs)";
			this.AverageExecutionTime.Name = "AverageExecutionTime";
			this.AverageExecutionTime.ReadOnly = true;
			this.AverageExecutionTime.ToolTipText = "The average time it took to execute the function.";
			this.AverageExecutionTime.Width = 190;
			// 
			// TotalExecutionTime
			// 
			this.TotalExecutionTime.DataPropertyName = "TotalExecutionTime";
			this.TotalExecutionTime.HeaderText = "Total Execution Time (µs)";
			this.TotalExecutionTime.Name = "TotalExecutionTime";
			this.TotalExecutionTime.ReadOnly = true;
			this.TotalExecutionTime.ToolTipText = "The total execution time (in µs) of all function invocations combined.";
			this.TotalExecutionTime.Width = 170;
			// 
			// kryptonHeaderGroup2
			// 
			this.kryptonHeaderGroup2.CollapseTarget = ComponentFactory.Krypton.Toolkit.HeaderGroupCollapsedTarget.CollapsedToPrimary;
			this.kryptonHeaderGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonHeaderGroup2.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
			this.kryptonHeaderGroup2.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlClient;
			this.kryptonHeaderGroup2.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
			this.kryptonHeaderGroup2.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
			this.kryptonHeaderGroup2.HeaderVisibleSecondary = false;
			this.kryptonHeaderGroup2.Location = new System.Drawing.Point(0, 0);
			this.kryptonHeaderGroup2.Name = "kryptonHeaderGroup2";
			this.kryptonHeaderGroup2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			// 
			// kryptonHeaderGroup2.Panel
			// 
			this.kryptonHeaderGroup2.Panel.Controls.Add(this.graphEmptyLabel);
			this.kryptonHeaderGroup2.Panel.Controls.Add(this.chart);
			this.kryptonHeaderGroup2.Size = new System.Drawing.Size(478, 330);
			this.kryptonHeaderGroup2.TabIndex = 5;
			this.kryptonHeaderGroup2.Text = "Analysis";
			this.kryptonHeaderGroup2.ValuesPrimary.Description = "";
			this.kryptonHeaderGroup2.ValuesPrimary.Heading = "Analysis";
			this.kryptonHeaderGroup2.ValuesPrimary.Image = global::Client.Properties.Resources.Statistics;
			this.kryptonHeaderGroup2.ValuesSecondary.Description = "";
			this.kryptonHeaderGroup2.ValuesSecondary.Heading = "Description";
			this.kryptonHeaderGroup2.ValuesSecondary.Image = null;
			// 
			// graphEmptyLabel
			// 
			this.graphEmptyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.graphEmptyLabel.AutoSize = false;
			this.graphEmptyLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
			this.graphEmptyLabel.Location = new System.Drawing.Point(1, 28);
			this.graphEmptyLabel.Name = "graphEmptyLabel";
			this.graphEmptyLabel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
			this.graphEmptyLabel.Size = new System.Drawing.Size(472, 25);
			this.graphEmptyLabel.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
			this.graphEmptyLabel.TabIndex = 4;
			this.graphEmptyLabel.Text = "No Profiling Data available.";
			this.graphEmptyLabel.Values.ExtraText = "";
			this.graphEmptyLabel.Values.Image = null;
			this.graphEmptyLabel.Values.Text = "No Profiling Data available.";
			// 
			// chart
			// 
			chartArea1.Area3DStyle.Enable3D = true;
			chartArea1.Area3DStyle.Inclination = 45;
			chartArea1.Area3DStyle.IsRightAngleAxes = false;
			chartArea1.Name = "ChartArea1";
			chartArea1.ShadowColor = System.Drawing.Color.Silver;
			this.chart.ChartAreas.Add(chartArea1);
			this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
			legend1.Name = "Legend1";
			legend1.Title = "Top 5 ";
			this.chart.Legends.Add(legend1);
			this.chart.Location = new System.Drawing.Point(0, 0);
			this.chart.Name = "chart";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			series1.CustomProperties = "PieLabelStyle=Disabled";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			series1.SmartLabelStyle.Enabled = false;
			this.chart.Series.Add(series1);
			this.chart.Size = new System.Drawing.Size(476, 305);
			this.chart.TabIndex = 3;
			this.chart.Text = "chart1";
			this.chart.Visible = false;
			// 
			// ProfilingView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(914, 356);
			this.Controls.Add(this.kryptonSplitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "ProfilingView";
			this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			((System.ComponentModel.ISupportInitialize)(this.historyGridView)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
			this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
			this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
			this.kryptonSplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
			this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
			this.kryptonHeaderGroup1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.profilingDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).EndInit();
			this.kryptonHeaderGroup2.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
			this.kryptonHeaderGroup2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView historyGridView;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox searchTextBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton clearSearchButton;
		private System.Windows.Forms.ToolStripButton profileToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripComboBox listTypeComboBox;
		private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView profilingDataGridView;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn CallTime;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HistoryFunctionName;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn HistoryExecutionTime;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripLabel toolStripLabel3;
		private System.Windows.Forms.ToolStripComboBox graphComboBox;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel tableEmptyLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel graphEmptyLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
		private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn NumCalls;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn AverageFunctionName;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn AverageExecutionTime;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TotalExecutionTime;
	}
}
