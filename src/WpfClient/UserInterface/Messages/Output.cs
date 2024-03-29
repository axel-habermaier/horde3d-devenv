using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;
using Infrastructure.Core.Messages;
using System.Collections.ObjectModel;
using WpfClient.Infrastructure.UserInterface;

namespace WpfClient.UserInterface.Messages
{
	public class Output : ViewModel
	{
		public ObservableCollection<Message> Messages { get; private set; }

		public Output()
		{
			Messages = new ObservableCollection<Message>();
			Messages.Add(new Message("Blabla", MessageType.DebugInfo, DateTime.Now, MessageCategory.DebugSession));
		}
	}
}
