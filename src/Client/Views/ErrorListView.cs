using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.Core.Messages;
using BinaryComponents.SuperList;

namespace Client.Views
{
	public partial class ErrorListView : DockView
	{
		List<InternalMessage> messages = new List<InternalMessage>();
	
		private class InternalMessage
		{
			public string Message { get; set; }
			public Image Image { get; set; }
			public DateTime Time { get; set; }
			internal MessageType MessageType { get; set; }
		}

		public ErrorListView()
		{
			InitializeComponent();

			Icon = Icon.FromHandle(Properties.Resources.ErrorList.GetHicon());

			SetStandardTextFont(messagesListView);

			var messageColumn = new Column("message", "Message", 100, o => ((InternalMessage)o).Message.Replace("\n", " ").Replace("<pre>", "").Replace("</pre>", ""));
			var timeColumn = new Column("time", "Time", 100, o => ((InternalMessage)o).Time.ToString("hh:mm:ss.fff"));
			var typeColumn = new Column("type", "", 30, o => ((InternalMessage)o).Image);

			messageColumn.IsFixedWidth = false;
			typeColumn.IsFixedWidth = true;

			messageColumn.Comparitor = (lhs, rhs) =>
			{
				var m1 = (InternalMessage)lhs;
				var m2 = (InternalMessage)rhs;

				return m1.Message.CompareTo(m2.Message);
			};

			timeColumn.Comparitor = (lhs, rhs) =>
			{
				var m1 = (InternalMessage)lhs;
				var m2 = (InternalMessage)rhs;

				return m1.Time.CompareTo(m2.Time);
			};

			typeColumn.Comparitor = (lhs, rhs) =>
			{
				var m1 = (InternalMessage)lhs;
				var m2 = (InternalMessage)rhs;

				return m1.MessageType.CompareTo(m2.MessageType);
			};

			messagesListView.Columns.Add(typeColumn);
			messagesListView.Columns.Add(messageColumn);
			messagesListView.Columns.Add(timeColumn);

			messagesListView.FillColumn = messageColumn;
			timeColumn.SortOrder = System.Windows.Forms.SortOrder.Descending;
		}

		public override string Title
		{
			get
			{
				return "Error List";
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
			return "ErrorList";
		}

		public void RemoveAll()
		{
			messages.Clear();
			messagesListView.Items.Clear();
		}

		public void AddMessage(Message message)
		{
			if (!(message is Horde3DMessage))
				return;

			Image image = null;

			switch (message.MessageType)
			{
				case MessageType.Unknown:
				default:
					image = Properties.Resources.SeriousWarning;
					break;
				case MessageType.Info:
					image = Properties.Resources.Info;
					break;
				case MessageType.Warning:
					image = Properties.Resources.Warning;
					break;
				case MessageType.Error:
					image = Properties.Resources.Error;
					break;
				case MessageType.DebugInfo:
					image = Properties.Resources.DebugInfo;
					break;
			}

			var internalMessage = new InternalMessage { Message = message.MessageContent, 
				Time = message.Time, Image = image, MessageType = message.MessageType };

			var scrollPos = messagesListView.AutoScrollPosition;
			messages.Add(internalMessage);
			if (!MessageFilteredOut(internalMessage))
				messagesListView.Items.Add(internalMessage);

			messagesListView.AutoScrollPosition = scrollPos;
		}

		private void categoryToolStripButton_Click(object sender, EventArgs e)
		{
			messagesListView.Items.Clear();
			var list = new List<InternalMessage>();
			messages.Foreach(m => { if (!MessageFilteredOut(m)) list.Add(m); });
			messagesListView.Items.AddRange(list);
		}

		private bool MessageFilteredOut(InternalMessage message)
		{
			if (message.MessageType == MessageType.Error && !errorsToolStripButton.Checked)
				return true;

			if (message.MessageType == MessageType.Warning && !warningsToolStripButton.Checked)
				return true;

			if (message.MessageType == MessageType.Info && !infoToolStripButton.Checked)
				return true;

			if (message.MessageType == MessageType.DebugInfo && !debugInfoToolStripButton.Checked)
				return true;

			return false;
		}
	}
}
