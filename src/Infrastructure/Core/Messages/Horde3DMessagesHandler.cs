using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.Server;
using Horde3DNET;
using System.Collections.ObjectModel;
using Infrastructure.Core.Communication;
using System.Threading;

namespace Infrastructure.Core.Messages
{
	class Horde3DMessagesHandler
	{
		/// <summary>
		/// Indicates whether the message handler should check for new Horde3D messages. It may not check for
		/// messages if Horde3D has not yet been initialized or if it has already been released.
		/// </summary>
		private bool checkForMessages = false;

		public Horde3DMessagesHandler()
		{
			// We are only allowed to check for messages if Horde3D has already been initialized
			// but not yet released.
			Horde3DCall.Init += r => checkForMessages = true;
			Horde3DCall.Release += () => checkForMessages = false;

			Horde3DCall.AfterFunctionCalled += OnFunctionCalled;
		}

		private void OnFunctionCalled(string eventName)
		{
			if (!checkForMessages)
				return;

			var level = 0;
			var time = 0.0f;
			var message = String.Empty;

			do
			{
				message = Horde3D.getMessage(out level, out time);

				if (!String.IsNullOrEmpty(message))
				{
					var newMessage = new Horde3DMessage(message, level, time);
					DebuggerService.SendMessage(newMessage);
				}
			}
			while (!String.IsNullOrEmpty(message));
		}
	}
}
