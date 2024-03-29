using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;
using Infrastructure.UserInterface.WinForms.Commands;
using System.Collections.ObjectModel;

namespace Infrastructure.UserInterface.WinForms
{
	/// <summary>
	/// A WinForms shell presenter interface.
	/// </summary>
	/// <typeparam name="TView">The view's type.</typeparam>
	/// <typeparam name="TShell">The shell's type.</typeparam>
	public interface IShellPresenter
	{
		DockPanel DockPanel { get; }
	}
}
