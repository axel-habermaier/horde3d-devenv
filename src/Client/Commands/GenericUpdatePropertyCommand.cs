using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Models;
using Infrastructure.UserInterface.WinForms.Commands;

namespace Client.Commands
{
	class GenericUpdatePropertyCommand : Command<DebuggerShell>
	{
		string propertyName = String.Empty;
		object oldValue; 
		object newValue;
		IPropertyAccessor propertyAccessor;

		public GenericUpdatePropertyCommand(object oldValue, object newValue, IPropertyAccessor propertyAccessor)
		{
			this.oldValue = oldValue;
			this.newValue = newValue;
			this.propertyAccessor = propertyAccessor;
		}

		public override void Execute()
		{
			propertyAccessor.SetValue(newValue);
		}

		public override void Undo()
		{
			propertyAccessor.SetValue(oldValue);
		}
	}
}
