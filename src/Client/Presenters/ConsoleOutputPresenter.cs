using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views;

using Infrastructure.Core.Messages;
using Client.Models;

namespace Client.Presenters
{
	class ConsoleOutputPresenter : DebuggerPresenter<ConsoleOutputView>
	{
		private MessageCategory currentCategory = MessageCategory.DebugSession;

		protected override bool InitializeEvents()
		{
			DebuggerShell.Current.MessagesDispatcher.MessageAdded += OnMessageAdded;
			DebuggerShell.Current.MessagesDispatcher.MessagesRemoved += OnMessagesRemoved;
			DebuggerShell.Current.ApplicationStateChanged += OnApplicationStateChanged;
			UpdateView(view => view.CategoryChangedRequest += OnCategoryChanged);
			UpdateView(view => view.ClearAllRequest += () => DebuggerShell.Current.MessagesDispatcher.ClearMessages(currentCategory));
			return base.InitializeEvents();
		}

		protected override void Release()
		{
			DebuggerShell.Current.MessagesDispatcher.MessageAdded -= OnMessageAdded;
			DebuggerShell.Current.MessagesDispatcher.MessagesRemoved -= OnMessagesRemoved;
			DebuggerShell.Current.ApplicationStateChanged -= OnApplicationStateChanged;
			base.Release();
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.CurrentCategory = currentCategory);
			DisplayMessages();
			return base.Initialize();
		}

		private void OnApplicationStateChanged(object sender, ApplicationStateChangedEventArgs e)
		{
			if (e.PreviousState == ApplicationState.Stopped)
			{
				currentCategory = MessageCategory.DebugSession;
				UpdateView(view => view.CurrentCategory = currentCategory);
			}
		}

		private void OnMessageAdded(object sender, MessageAddedEventArgs e)
		{
			if (e.Message.Category == currentCategory)
				UpdateView(view => view.AppendLogMessage(e.Message));
		}

		private void OnMessagesRemoved(object sender, EventArgs e)
		{
			DisplayMessages();
		}

		private void DisplayMessages()
		{
			var messages = from m in DebuggerShell.Current.MessagesDispatcher.Messages
						   where m.Category == currentCategory
						   select m;

			UpdateView(view => view.ShowMessages(messages));
		}

		private void OnCategoryChanged(MessageCategory category)
		{
			currentCategory = category;
			DisplayMessages();
		}
	}
}
