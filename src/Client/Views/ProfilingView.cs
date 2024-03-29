using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using System.Collections.ObjectModel;
using Infrastructure.Core.Misc;
using Infrastructure.UserInterface;
using Client.Models;

namespace Client.Views
{
	public partial class ProfilingView : DockView
	{
		public event RequestHandler ProfileRequest;

		public ProfilingView()
		{
			InitializeComponent();
			Icon = Icon.FromHandle(Properties.Resources.Profiling.GetHicon());

			historyGridView.AutoGenerateColumns = false;
			profilingDataGridView.AutoGenerateColumns = false;

			sortedProfilingData = new SortableBindingList<InternalProfilingData>();

			profilingDataGridView.DataSource = sortedProfilingData;
			profilingDataGridView.Sort(TotalExecutionTime, ListSortDirection.Descending);

			listTypeComboBox.SelectedIndex = 0;
			graphComboBox.SelectedIndex = 0;

			chart.Legends["Legend1"].Font = StandardFont;
			chart.Legends["Legend1"].TitleFont = new Font(StandardFont, FontStyle.Bold);

			historyGridView.DataError += new DataGridViewDataErrorEventHandler(historyGridView_DataError);
			profilingDataGridView.DataError += new DataGridViewDataErrorEventHandler(historyGridView_DataError);
		}

		void historyGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			e.ThrowException = false;
		}

		SortableBindingList<InternalProfilingData> sortedProfilingData;
		ReadOnlyCollection<FunctionCall> profilingData;

		private class InternalProfilingData
		{
			public string FunctionName { get; set; }
			public int NumCalls { get; set; }
			public double AverageExecutionTime { get; set; }
			public double TotalExecutionTime { get; set; }
		}

		public override string Title
		{
			get
			{
				return "Horde3D Profiling";
			}
		}

		public override WeifenLuo.WinFormsUI.Docking.DockState DefaultDockState
		{
			get
			{
				return WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
			}
		}

		protected override string GetPersistString()
		{
			return "ProfilingView";
		}

		public ReadOnlyCollection<FunctionCall> ProfilingData
		{
			set
			{
				profilingData = value;
				ShowFilteredData();
				ShowGraph();

				var showEmptyLabels = value == null || value.Count == 0;
				tableEmptyLabel.Visible = showEmptyLabels;
				graphEmptyLabel.Visible = showEmptyLabels;
			}
		}

		private void ShowFilteredData()
		{
			if (profilingData == null || profilingData.Count == 0)
			{
				historyGridView.Visible = false;
				profilingDataGridView.Visible = false;
				return;
			}

			listTypeComboBox_SelectedIndexChanged(null, EventArgs.Empty);

			var data = profilingData as IEnumerable<FunctionCall>;
			if (!String.IsNullOrEmpty(searchTextBox.Text.Trim()))
				data = data.Where(f => f.FunctionName.Contains(searchTextBox.Text));

			var groupedData = from f in data
							  group f by f.FunctionName into g
							  select new InternalProfilingData { FunctionName = g.Key, NumCalls = g.Count(), AverageExecutionTime = Math.Round(g.Average(c => c.ExecutionTime), 2), TotalExecutionTime = Math.Round(g.Sum(c => c.ExecutionTime), 2) };

			sortedProfilingData.Clear();
			sortedProfilingData.AddRange(groupedData);

			if (profilingDataGridView.SortedColumn != null)
				profilingDataGridView.Sort(profilingDataGridView.SortedColumn, profilingDataGridView.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);

			historyGridView.DataSource = data.ToList();
		}

		private void clearSearchButton_Click(object sender, EventArgs e)
		{
			searchTextBox.Text = String.Empty;
			ShowFilteredData();
		}

		private void searchTextBox_TextChanged(object sender, EventArgs e)
		{
			ShowFilteredData();
		}

		private void profileToolStripButton_Click(object sender, EventArgs e)
		{
			Request(ProfileRequest);
		}

		public ApplicationState State
		{
			set
			{
				switch (value)
				{
					case ApplicationState.Running:
					case ApplicationState.Suspended:
						profileToolStripButton.Enabled = true;
						break;
					default:
						profileToolStripButton.Enabled = false;
						break;
				}
			}
		}

		private void listTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (profilingData == null || profilingData.Count == 0)
				return;

			if (listTypeComboBox.SelectedIndex == 1)
			{
				historyGridView.Visible = true;
				profilingDataGridView.Visible = false;
			}
			else
			{
				historyGridView.Visible = false;
				profilingDataGridView.Visible = true;
			}
		}

		private void graphComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowGraph();
		}

		private void ShowGraph()
		{
			if (profilingData == null || profilingData.Count == 0)
			{
				chart.Visible = false;
				return;
			}

			chart.Visible = true;

			if (graphComboBox.SelectedIndex == 0)
			{
				// The graph shows the average execution time.
				var numCalls = from f in profilingData
							   group f by f.FunctionName into g
							   orderby g.Average(c => c.ExecutionTime) descending
							   select new { FunctionName = g.Key, AverageExecutionTime = Math.Round(g.Average(c => c.ExecutionTime), 2) };

				var time = new List<double>();
				var name = new List<string>();
				foreach (var item in numCalls.Take(5))
				{
					time.Add(item.AverageExecutionTime);
					name.Add(item.FunctionName + " (" + item.AverageExecutionTime + " µs average)");
				}

				chart.Series["Series1"].Points.DataBindXY(name, time);
				chart.Legends["Legend1"].Title = "Top 5 Average Execution Time";
			}
			else if (graphComboBox.SelectedIndex == 1)
			{
				// The graph shows the number of calls.
				var numCalls = from f in profilingData
							   group f by f.FunctionName into g
							   orderby g.Count() descending
							   select new { FunctionName = g.Key, CallAmount = g.Count() };

				var calls = new List<int>();
				var name = new List<string>();
				foreach (var item in numCalls.Take(5))
				{
					calls.Add(item.CallAmount);
					name.Add(item.FunctionName + " (" + item.CallAmount + " invocations)");
				}

				chart.Series["Series1"].Points.DataBindXY(name, calls);
				chart.Legends["Legend1"].Title = "Top 5 Invocations";
			}
			else
			{
				// The graph shows the accumulated execution time.
				var numCalls = from f in profilingData
							   group f by f.FunctionName into g
							   orderby g.Sum(c => c.ExecutionTime) descending
							   select new { FunctionName = g.Key, AccumulatedTime = Math.Round(g.Sum(c => c.ExecutionTime), 2) };

				var time = new List<double>();
				var name = new List<string>();
				foreach (var item in numCalls.Take(5))
				{
					time.Add(item.AccumulatedTime);
					name.Add(item.FunctionName + " (" + item.AccumulatedTime + " µs total)");
				}

				chart.Series["Series1"].Points.DataBindXY(name, time);
				chart.Legends["Legend1"].Title = "Top 5 Total Execution Time";
			}
		}
	}
}
