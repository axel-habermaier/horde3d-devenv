using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views;
using Infrastructure.UserInterface.WinForms;
using System.Windows.Data;
using Infrastructure.Core.Messages;
using System.Collections.ObjectModel;
using Client.Models;

namespace Client.Presenters
{
	class ErrorListPresenter : DebuggerPresenter<ErrorListView>
	{
		MessageAddedHandler messageAddedDelegate;
		EventHandler messagesRemovedDelegate;

		public ErrorListPresenter()
		{
			messageAddedDelegate = new MessageAddedHandler(OnMessageAdded);
			messagesRemovedDelegate = new EventHandler(OnMessagesRemoved);
		}

		protected override bool Initialize()
		{
			ResetMessages();
			
			return base.Initialize();
		}

		private void ResetMessages()
		{
			UpdateView(view => view.RemoveAll());
			Shell.MessagesDispatcher.Messages.Where(m => m.Category == MessageCategory.DebugSession).Foreach(m => UpdateView(view => view.AddMessage(m)));
		}

		protected override bool InitializeEvents()
		{
			Shell.MessagesDispatcher.MessageAdded += messageAddedDelegate;
			Shell.MessagesDispatcher.MessagesRemoved += messagesRemovedDelegate;

			return base.InitializeEvents();
		}

		protected override void Release()
		{
			Shell.MessagesDispatcher.MessageAdded -= messageAddedDelegate;
			Shell.MessagesDispatcher.MessagesRemoved -= messagesRemovedDelegate;

			base.Release();
		}

		private void OnMessageAdded(object sender, MessageAddedEventArgs e)
		{
			if (e.Message.Category == MessageCategory.DebugSession)
				UpdateView(view => view.AddMessage(e.Message));
		}

		private void OnMessagesRemoved(object sender, EventArgs e)
		{
			ResetMessages();
		}
	}
}
