using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.UserInterface.WinForms
{
	public class SaveableDocumentView : DocumentView
	{
		SaveState saveState = SaveState.Saved;
		/// <summary>
		/// Gets or sets the view's save state.
		/// </summary>
		public SaveState SaveState 
		{
			get { return saveState; }
			set
			{
				if (saveState != value)
				{
					saveState = value;
					var title = Title + (saveState == SaveState.Unsaved ? "*" : String.Empty);
					Text = title;
					TabText = title;
					ToolTipText = title;
				}
			}
		}
	}
}
