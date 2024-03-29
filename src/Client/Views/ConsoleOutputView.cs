using System;
using System.Collections.Generic;
using System.Drawing;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.UserInterface;
using Infrastructure.Core.Messages;
using ICSharpCode.TextEditor;

namespace Client.Views
{
	public partial class ConsoleOutputView : DockView
	{
		public event RequestHandler<MessageCategory> CategoryChangedRequest;
		public event RequestHandler ClearAllRequest;

		public ConsoleOutputView()
		{
			InitializeComponent();

			categoriesComboBox.Items.Add("Debug Session");
			categoriesComboBox.Items.Add("System");

			Icon = Icon.FromHandle(Properties.Resources.Output.GetHicon());
			textBox.Document.ReadOnly = true;
			textBox.Font = new Font("Courier New", 8.25f);
		}

		public override string Title
		{
			get
			{
				return "Output";
			}
		}

		public override WeifenLuo.WinFormsUI.Docking.DockState DefaultDockState
		{
			get
			{
				return WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
			}
		}

		public void AppendLogMessage(Message message)
		{
			textBox.Text += (GenerateLogMessageString(message) + Environment.NewLine);
			textBox.ActiveTextAreaControl.ScrollTo(textBox.Document.TotalNumberOfLines);
			//textBox.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
		}

		public void ShowMessages(IEnumerable<Message> messages)
		{
			var text = String.Empty;
			messages.Foreach(m => text += GenerateLogMessageString(m) + Environment.NewLine);

			textBox.Text = String.Empty;
			textBox.Text = text;
			textBox.ActiveTextAreaControl.ScrollTo(textBox.Document.TotalNumberOfLines);
			textBox.Document.RequestUpdate(new TextAreaUpdate(TextAreaUpdateType.WholeTextArea));
		}

		string GenerateLogMessageString(Message message)
		{
			return message.Time.ToString("hh:mm:ss.fff") + "\t" + message.MessageContent.Replace("<pre>", "");
		}

		public MessageCategory CurrentCategory
		{
			set
			{
				if (value == MessageCategory.DebugSession)
					categoriesComboBox.SelectedItem = "Debug Session";
				else
					categoriesComboBox.SelectedItem = "System";
			}
		}

		private void categoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var categoryString = categoriesComboBox.SelectedItem.ToString();

			MessageCategory category = MessageCategory.DebugSession;
			if (categoryString == "System")
				category = MessageCategory.System;

			Request(CategoryChangedRequest, category);
		}

		private void clearAllButton_Click(object sender, EventArgs e)
		{
			Request(ClearAllRequest);
		}

		protected override string GetPersistString()
		{
			return "ConsoleOutput";
		}
	}
}
