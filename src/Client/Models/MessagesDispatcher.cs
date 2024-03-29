using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.Communication;
using System.Collections.ObjectModel;
using Infrastructure.Core.Resources;
using System.Threading;
using Infrastructure.Core.Messages;

namespace Client.Models
{
	public class MessagesDispatcher
	{
		/// <summary>
		/// List of all messages.
		/// </summary>
		private List<Message> messages = new List<Message>();

		/// <summary>
		/// Gets a read-only list of all messages.
		/// </summary>
		public ReadOnlyCollection<Message> Messages
		{
			get { return messages.AsReadOnly(); }
		}

		/// <summary>
		/// Raised when a message was added.
		/// </summary>
		public event MessageAddedHandler MessageAdded;

		/// <summary>
		/// Raised when messages were removed.
		/// </summary>
		public event EventHandler MessagesRemoved;

		/// <summary>
		/// Initializes a new messages dispatcher instance.
		/// </summary>
		public MessagesDispatcher()
		{
			DebuggerShell.Current.ApplicationStateChanged += (o, e) =>
			{
				if (e.PreviousState == ApplicationState.Stopped)
					ClearMessages(MessageCategory.DebugSession);
			};

			DebuggerShell.Current.CallbackHandler.MessageGenerated += (o, e) => AddMessage(e.Message);
			DebuggerShell.Current.CallbackHandler.Suspended += (o, e) => AddDebugSessionMessage("Application suspended.");
			DebuggerShell.Current.CallbackHandler.Resumed += (o, e) => AddDebugSessionMessage("Application resumed.");
		}

		/// <summary>
		/// Adds the given message to the internal list of messages and fires the MessageAdded event.
		/// </summary>
		/// <param name="message">The message that should be added.</param>
		public void AddMessage(Message message)
		{
			DebuggerShell.Current.RunSync(() =>
			{
				messages.Add(message);
				if (MessageAdded != null)
					MessageAdded(this, new MessageAddedEventArgs(message));
			});
		}

		/// <summary>
		/// Adds a debug session message.
		/// </summary>
		/// <param name="message">The message's content.</param>
		public void AddDebugSessionMessage(string message)
		{
			AddMessage(new Message(message, MessageType.Info, DateTime.Now, MessageCategory.DebugSession));
		}

		/// <summary>
		/// Adds a debug session warning.
		/// </summary>
		/// <param name="message">The message's content.</param>
		public void AddDebugSessionWarning(string message)
		{
			AddMessage(new Message(message, MessageType.Warning, DateTime.Now, MessageCategory.DebugSession));
		}

		/// <summary>
		/// Adds a debug session error.
		/// </summary>
		/// <param name="message">The message's content.</param>
		public void AddDebugSessionError(string message)
		{
			AddMessage(new Message(message, MessageType.Error, DateTime.Now, MessageCategory.DebugSession));
		}

		/// <summary>
		/// Adds a system debug message.
		/// </summary>
		/// <param name="message">The message's content.</param>
		public void AddSystemDebugMessage(string message)
		{
			AddMessage(new Message(message, MessageType.DebugInfo, DateTime.Now, MessageCategory.System));
		}

		/// <summary>
		/// Adds a system info message.
		/// </summary>
		/// <param name="message">The message's content.</param>
		public void AddSystemInfoMessage(string message)
		{
			AddMessage(new Message(message, MessageType.Info, DateTime.Now, MessageCategory.System));
		}

		/// <summary>
		/// Adds a system error message.
		/// </summary>
		/// <param name="message">The message's content.</param>
		public void AddSystemErrorMessage(string message)
		{
			AddMessage(new Message(message, MessageType.Error, DateTime.Now, MessageCategory.System));
		}

		/// <summary>
		/// Clears all messages that are in the given category.
		/// </summary>
		/// <param name="category">The category that should be cleared.</param>
		public void ClearMessages(MessageCategory category)
		{
			var clearMessages = (from m in messages
								 where m.Category == category
								 select m).ToList();

			clearMessages.Foreach(m => messages.Remove(m));

			if (clearMessages.Count != 0 && MessagesRemoved != null)
				MessagesRemoved(this, EventArgs.Empty);
		}
	}

	#region Message Added Delegates and EventArgs
	/// <summary>
	/// Delegated used by the MessageAdded event.
	/// </summary>
	/// <param name="sender">The event's source.</param>
	/// <param name="e">Further information associated with the event.</param>
	public delegate void MessageAddedHandler(object sender, MessageAddedEventArgs e);

	/// <summary>
	/// A class containing further details when the MessageAdded event is handled.
	/// </summary>
	public class MessageAddedEventArgs : EventArgs
	{
		/// <summary>
		/// The message that was added.
		/// </summary>
		public Message Message { get; private set; }

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="message">The message that was added.</param>
		public MessageAddedEventArgs(Message message)
		{
			Message = message;
		}
	}
	#endregion
}
