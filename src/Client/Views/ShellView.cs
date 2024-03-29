using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using WeifenLuo.WinFormsUI.Docking;
using Infrastructure.UserInterface;
using Client.Models;
using System.Collections.Specialized;
using System.Runtime.InteropServices;


namespace Client.Views
{
	public partial class ShellView : FormView
	{
		#region Requests
		public event RequestHandler ExitRequest;
		public event RequestHandler NewApplicationRequest;
		public event RequestHandler LoadApplicationRequest;
		public event RequestHandler SaveRequest;
		public event RequestHandler SaveAllRequest;
		public event RequestHandler CloseApplicationRequest;
		public event RequestHandler StartDebuggingRequest;
		public event RequestHandler SuspendApplicationRequest;
		public event RequestHandler StopDebuggingRequest;
		public event RequestHandler ChangeApplicationSettingsRequest;
		public event RequestHandler ShowConsoleOutputRequest;
		public event RequestHandler ShowFunctionCallHistory;
		public event RequestHandler ShowErrorListRequest;
		public event RequestHandler<string> LoadRecentApplicationRequest;
		public event RequestHandler ProfileFrameRequest;
		public event RequestHandler ShowSceneGraphExplorerRequest;
		public event RequestHandler ShowResourcesExplorerRequest;
		public event RequestHandler UndoRequest;
		public event RequestHandler RedoRequest;
		public event RequestHandler AboutRequest;
		public event RequestHandler DebugRenderTargetsRequest;
		public event RequestHandler ShowStartPageRequest;
		public event RequestHandler CloseAllDocumentsRequest;
		#endregion

		LinkedList<IDockContent> documents = new LinkedList<IDockContent>();
		bool controlDown = false;

		public ShellView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.Logo.GetHicon());
			dockPanel.ActiveDocumentChanged += new EventHandler(dockPanel_ActiveDocumentChanged);
		}

		void dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
		{
			if (dockPanel.ActiveDocument == null)
			    return;

			documents.AddLast(dockPanel.ActiveDocument);
		}

		public void UpdateTitle(string appName)
		{
			if (String.IsNullOrEmpty(appName))
				Text = Title;
			else
				Text = Title + " - " + appName;
		}

		public bool EnableRedo
		{
			set
			{
				redoToolStripMenuItem.Enabled = value;
				redoToolStripButton.Enabled = value;
			}
		}

		public bool EnableUndo
		{
			set
			{
				undoToolStripMenuItem.Enabled = value;
				undoToolStripButton.Enabled = value;
			}
		}

		public ApplicationState State
		{
			set
			{
				switch (value)
				{
					case ApplicationState.Stopped:
						applicationToolStripMenuItem.Visible = true;
						runToolStripButton.Enabled = true;
						runToolStripButton.Text = "Launch Application (F5)";
						runToolStripMenuItem.Enabled = true;
						runToolStripMenuItem.Text = "Launch";
						suspendToolStripMenuItem.Enabled = false;
						stopToolStripMenuItem.Enabled = false;
						suspendToolStripButton.Enabled = false;
						stopToolStripButton.Enabled = false;
						settingsToolStripButton.Enabled = true;
						applicationSettingsToolStripMenuItem.Enabled = true;
						newToolStripButton.Enabled = true;
						newApplicationToolStripMenuItem.Enabled = true;
						loadApplicationToolStripMenuItem.Enabled = true;
						openToolStripButton.Enabled = true;
						closeToolStripMenuItem.Enabled = true;
						recentApplicationsMenuItem.Enabled = true;
						profilingToolStripButton.Enabled = false;
						debugRenderTargetsToolStripMenuItem.Enabled = false;
						renderTargetButton.Enabled = false;
						//consoleOutputToolStripMenuItem1.Enabled = false;
						//errorListToolStripMenuItem1.Enabled = false;
						//horde3DProfilingToolStripMenuItem.Enabled = false;
						//sceneGraphExplorerToolStripMenuItem1.Enabled = false;
						//resourceExplorerToolStripMenuItem1.Enabled = false;
						//renderTargetsExplorerToolStripMenuItem.Enabled = false;
						renderTargetsExplorerToolStripMenuItem.Enabled = false;
						break;
					case ApplicationState.Running:
						applicationToolStripMenuItem.Visible = true;
						runToolStripButton.Enabled = false;
						runToolStripMenuItem.Enabled = false;
						suspendToolStripMenuItem.Enabled = true;
						stopToolStripMenuItem.Enabled = true;
						suspendToolStripButton.Enabled = true;
						stopToolStripButton.Enabled = true;
						settingsToolStripButton.Enabled = true;
						applicationSettingsToolStripMenuItem.Enabled = true;
						newToolStripButton.Enabled = false;
						newApplicationToolStripMenuItem.Enabled = false;
						loadApplicationToolStripMenuItem.Enabled = false;
						openToolStripButton.Enabled = false;
						closeToolStripMenuItem.Enabled = false;
						recentApplicationsMenuItem.Enabled = false;
						profilingToolStripButton.Enabled = true;
						debugRenderTargetsToolStripMenuItem.Enabled = true;
						renderTargetButton.Enabled = true;
						renderTargetsExplorerToolStripMenuItem.Enabled = true;
						break;
					case ApplicationState.Unloaded:
						applicationToolStripMenuItem.Visible = false;
						runToolStripButton.Enabled = false;
						runToolStripMenuItem.Enabled = false;
						suspendToolStripMenuItem.Enabled = false;
						stopToolStripMenuItem.Enabled = false;
						suspendToolStripButton.Enabled = false;
						stopToolStripButton.Enabled = false;
						settingsToolStripButton.Enabled = false;
						applicationSettingsToolStripMenuItem.Enabled = false;
						newToolStripButton.Enabled = true;
						newApplicationToolStripMenuItem.Enabled = true;
						loadApplicationToolStripMenuItem.Enabled = true;
						openToolStripButton.Enabled = true;
						closeToolStripMenuItem.Enabled = false;
						recentApplicationsMenuItem.Enabled = true;
						profilingToolStripButton.Enabled = false;
						debugRenderTargetsToolStripMenuItem.Enabled = false;
						renderTargetButton.Enabled = false;
						renderTargetsExplorerToolStripMenuItem.Enabled = false;
						break;
					case ApplicationState.Suspended:
						applicationToolStripMenuItem.Visible = true;
						runToolStripButton.Enabled = true;
						runToolStripButton.Text = "Resume Application (F5)";
						runToolStripMenuItem.Enabled = true;
						runToolStripMenuItem.Text = "Resume";
						suspendToolStripMenuItem.Enabled = false;
						stopToolStripMenuItem.Enabled = true;
						suspendToolStripButton.Enabled = false;
						stopToolStripButton.Enabled = true;
						settingsToolStripButton.Enabled = true;
						applicationSettingsToolStripMenuItem.Enabled = true;
						newToolStripButton.Enabled = false;
						newApplicationToolStripMenuItem.Enabled = false;
						loadApplicationToolStripMenuItem.Enabled = false;
						openToolStripButton.Enabled = false;
						closeToolStripMenuItem.Enabled = false;
						recentApplicationsMenuItem.Enabled = false;
						profilingToolStripButton.Enabled = true;
						debugRenderTargetsToolStripMenuItem.Enabled = true;
						renderTargetButton.Enabled = true;
						renderTargetsExplorerToolStripMenuItem.Enabled = true;
						break;
				}
			}
		}

		public DockPanel DockPanel
		{
			get { return dockPanel; }
		}

		public override string Title
		{
			get { return "Horde3D Development Environment"; }
		}

		private void ShellView_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				Request(ExitRequest);
			}
		}

		private void newToolStripButton_Click(object sender, EventArgs e)
		{
			Request(NewApplicationRequest);
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			Request(LoadApplicationRequest);
		}

		private void saveToolStripButton_Click(object sender, EventArgs e)
		{
			Request(SaveRequest);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(ExitRequest);
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(CloseApplicationRequest);
		}

		private void runToolStripButton_Click(object sender, EventArgs e)
		{
			Request(StartDebuggingRequest);
		}

		private void suspendToolStripButton_Click(object sender, EventArgs e)
		{
			Request(SuspendApplicationRequest);
		}

		private void stopToolStripButton_Click(object sender, EventArgs e)
		{
			Request(StopDebuggingRequest);
		}

		private void settingsToolStripButton_Click(object sender, EventArgs e)
		{
			Request(ChangeApplicationSettingsRequest);
		}

		private void consoleOutputToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(ShowConsoleOutputRequest);
		}

		private void errorListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(ShowErrorListRequest);
		}

		public StringCollection RecentApplications
		{
			set
			{
				recentApplicationsMenuItem.Enabled = value != null && value.Count > 0;

				if (value != null && value.Count > 0)
				{
					recentApplicationsMenuItem.DropDownItems.Clear();
					var count = 0;

					foreach (var app in value)
					{
						var item = new ToolStripMenuItem(app);
						item.Click += (o, e) => Request(LoadRecentApplicationRequest, (o as ToolStripMenuItem).Text);
						recentApplicationsMenuItem.DropDownItems.Add(item);

						++count;
						if (count == Properties.Settings.Default.NumRecentApplications)
							break;
					}
				}
			}
		}

		private void profilingToolStripButton_Click(object sender, EventArgs e)
		{
			Request(ProfileFrameRequest);
		}

		private void functionCallHistoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(ShowFunctionCallHistory);
		}

		private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(SaveAllRequest);
		}

		private void sceneGraphExplorerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(ShowSceneGraphExplorerRequest);
		}

		private void resourceExplorerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(ShowResourcesExplorerRequest);
		}

		private void redoToolStripButton_Click(object sender, EventArgs e)
		{
			Request(RedoRequest);
		}

		private void undoToolStripButton_Click(object sender, EventArgs e)
		{
			Request(UndoRequest);
		}

		private void aboutHorde3DDebuggerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(AboutRequest);
		}

		private void renderTargetButton_Click(object sender, EventArgs e)
		{
			Request(DebugRenderTargetsRequest);
		}

		private void startPageButton_Click(object sender, EventArgs e)
		{
			Request(ShowStartPageRequest);
		}

		private void closeAllDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(CloseAllDocumentsRequest);
		}

		private void ShellView_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Tab && controlDown)
				ShowPreviousDocument();
		}

		private void ShowPreviousDocument()
		{
			if (documents.Count < 2)
				return;

			var document = documents.Last.Previous;
			documents.Remove(document);

			if (((Control)document.Value).IsDisposed)
				ShowPreviousDocument();
			else
				document.Value.DockHandler.Show(dockPanel);
		}

		private void ShellView_KeyDown(object sender, KeyEventArgs e)
		{
			controlDown = e.Control;
		}
	}
}
