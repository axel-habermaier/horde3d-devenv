using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.UserInterface.WinForms;
using System.IO;
using Infrastructure.UserInterface;
using Client.Models;
using System.Runtime.InteropServices;

namespace Client.Views
{
	public partial class StartView : DocumentView
	{
		public event RequestHandler CreateApplicationRequest;
		public event RequestHandler OpenApplicationRequest;
		public event RequestHandler OpenSampleApplicationRequest;

		public StartView()
		{
			InitializeComponent();
			Icon = Icon.FromHandle(Properties.Resources.StartPage.GetHicon());

			AddText("The Horde3D Development Environment helps you build your Horde3D application. First of all, you must register your application. To do so, click on the \"");
			AddItalicText("Create Application");
			AddText("\" link in the left column or choose \"");
			AddItalicText("Open Knight Sample");
			AddText("\". However, your application can only be started if it uses an unmodified version of the Horde3D 1.0.0 Beta 3 DLL without any extensions. Furthermore, you must call ");
			AddCode("Horde3D::checkExtension(\"AllowDebugging\")");
			AddText(" after ");
			AddCode("Horde3D::init()");
			AddText(".\n\n");

			AddText("After you've started the application (shortcut F5), the following features are available to you:\n\n");
			const int indent = 20;
			AddBoldText("Suspend/Freeze\n");
			AddText(indent, "You can suspend/freeze your application at any time (shortcut F7) and resume it later (shortcut F5).\n\n");

			AddBoldText("Change Resources\n");
			AddText(indent, "Once you've suspended your application, you can change all of its shaders, materials, particle effects, pipelines and code resources. After you've saved your changes, the updated resources are automatically used by your application. You can continue editing your resources after you've resumed the application.\n\n");

			AddBoldText("Browse the Scenegraph\n");
			AddText(indent, "Find out more about the current state of the scene graph.\n\n");

			AddBoldText("Profile the Horde3D Function Calls\n");
			AddText(indent, "Use the profiling function (shortcut F8) while your application is running or suspended to profile the calls made to Horde3D functions during a single frame.\n\n");

			AddBoldText("Debug Render Targets\n");
			AddText(indent, "After you've suspended your application, you can select a render target that you would like to debug. The displayed data is updated at some fixed interval, even once you've resumed the execution of your application.\n\n");
		}

		void AddText(string text)
		{
			AddText(0, text);
		}

		void AddText(int indent, string text)
		{
			multilineLabel.SelectionIndent = indent;
			multilineLabel.SelectionFont = StandardFont;
			multilineLabel.SelectedText = text;
		}

		void AddItalicText(string text)
		{
			multilineLabel.SelectionIndent = 0;
			multilineLabel.SelectionFont = new Font(StandardFont, FontStyle.Italic);
			multilineLabel.SelectedText = text;
		}

		void AddBoldText(string text)
		{
			multilineLabel.SelectionIndent = 0;
			multilineLabel.SelectionFont = new Font(StandardFont, FontStyle.Bold);
			multilineLabel.SelectedText = text;
		}

		void AddCode(string code)
		{
			multilineLabel.SelectionIndent = 0;
			multilineLabel.SelectionFont = new Font("Courier New", StandardFont.Size, FontStyle.Regular);
			multilineLabel.SelectedText = code;
		}

		public override string Title
		{
			get
			{
				return "Start Page";
			}
		}

		private void createLink_LinkClicked(object sender, EventArgs e)
		{
			Request(CreateApplicationRequest);
		}

		private void openLink_LinkClicked(object sender, EventArgs e)
		{
			Request(OpenApplicationRequest);
		}

		private void openSampleLink_LinkClicked(object sender, EventArgs e)
		{
			Request(OpenSampleApplicationRequest);
		}

		public ApplicationState State
		{
			set
			{
				switch (value)
				{
					case ApplicationState.Running:
					case ApplicationState.Suspended:
						openSampleLink.Enabled = false;
						createLink.Enabled = false;
						openLink.Enabled = false;
						break;
					case ApplicationState.Unloaded:
					case ApplicationState.Stopped:
					default:
						openSampleLink.Enabled = true;
						createLink.Enabled = true;
						openLink.Enabled = true;
						break;
				}
			}
		}
	}
}
