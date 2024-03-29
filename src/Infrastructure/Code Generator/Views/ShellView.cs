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
using Infrastructure.CodeGenerator.Logic;

namespace Infrastructure.CodeGenerator.Views
{
	public partial class ShellView : FormView
	{
		#region Requests
		public event RequestHandler NewSettingsRequest;
		public event RequestHandler LoadSettingsRequest;
		public event RequestHandler SaveSettingsRequest;
		public event RequestHandler ResetSettingsRequest;
		public event RequestHandler SaveSettingsAsRequest;
		public event RequestHandler ChangeSettingsRequest;
		public event RequestHandler<string> ParseRequest;
		public event RequestHandler ExitRequest;
		public event RequestHandler<string> AddHeaderFileRequest;
		public event RequestHandler ShowFunctionListRequest;
		public event RequestHandler GenerateCodeRequest;
		public event RequestHandler AboutRequest;
		#endregion

		string title = "Code Generator";
		public override string Title
		{
			get { return title; }
		}

		public void SetTitle(CodeGenerationSettings settings)
		{
			title = "Code Generator";
			if (settings != null)
				title += " - " + settings.Name;

			Text = title;
		}

		public ShellView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.Code.GetHicon());
		}

		public DockPanel DockPanel
		{
			get { return dockPanel; }
		}

		private void newToolStripButton_Click(object sender, EventArgs e)
		{
			Request(NewSettingsRequest);
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			Request(LoadSettingsRequest);
		}

		private void saveToolStripButton_Click(object sender, EventArgs e)
		{
			Request(SaveSettingsRequest);
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(SaveSettingsAsRequest);
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(ResetSettingsRequest);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(ExitRequest);
		}

		private void ShellView_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				Request(ExitRequest);
			}
		}

		private void parseFunctionsButton_Click(object sender, EventArgs e)
		{
			Request(ParseRequest, headerFileButton.Text);
		}

		private void headerFileButton_Click(object sender, EventArgs e)
		{
			if (openHeaderFileDialog.ShowDialog() == DialogResult.OK)
				Request(AddHeaderFileRequest, openHeaderFileDialog.FileName);
		}

		public void BuildHeaderFileMenu()
		{
			headerFileButton.DropDownItems.Clear();
			headerFileButton.DropDownItems.Add("Previously used Horde3D header files:");
			headerFileButton.DropDownItems.Add(new ToolStripSeparator());

			var headerFiles = Properties.Settings.Default.HeaderFiles;

			int count = 0;
			if (headerFiles != null)
			{
				if (headerFiles.Count >= 1)
					headerFileButton.Text = headerFiles[0];

				foreach (var file in headerFiles)
				{
					if (file == headerFileButton.Text)
						continue;

					var item = new ToolStripMenuItem(file);
					item.Click += new EventHandler((o, ex) => Request(AddHeaderFileRequest, ((ToolStripMenuItem)o).Text));
					headerFileButton.DropDownItems.Add(item);
					++count;
				}
			}

			if (count == 0)
				headerFileButton.DropDownItems.Add("none");
		}

		private void propertiesButton_Click(object sender, EventArgs e)
		{
			Request(ChangeSettingsRequest);
		}

		public bool AllowSaving
		{
			set 
			{
				saveToolStripButton.Enabled = value;
				saveAsToolStripMenuItem.Enabled = value;
				saveToolStripMenuItem.Enabled = value;
			}
		}

		public bool AllowParsing
		{
			set
			{
				parseFunctionsButton.Enabled = value;
				parseFunctionsToolStripMenuItem.Enabled = value;
			}
		}

		public bool AllowChangeSettings
		{
			set
			{
				propertiesButton.Enabled = value;
				changeSettingsToolStripMenuItem.Enabled = value;
			}
		}

		public bool AllowCodeGeneration
		{
			set
			{
				generateCodeButton.Enabled = value;
				generateCodeToolStripMenuItem.Enabled = value;
			}
		}

		public bool AllowReset
		{
			set { closeToolStripMenuItem.Enabled = value; }
		}

		private void functionListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(ShowFunctionListRequest);
		}

		private void generateCodeButton_Click(object sender, EventArgs e)
		{
			Request(GenerateCodeRequest);
		}

		private void aboutCodeGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Request(AboutRequest);
		}
	}
}
