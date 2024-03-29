using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.UserInterface.WinForms
{
	/// <summary>
	/// Indicates whether there are any unsaved changes.
	/// </summary>
	public enum SaveState
	{
		/// <summary>
		/// All changes have been saved.
		/// </summary>
		Saved,
		/// <summary>
		/// There are currently unsaved changes.
		/// </summary>
		Unsaved
	}
}
