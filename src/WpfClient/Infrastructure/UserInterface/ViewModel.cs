using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;

namespace WpfClient.Infrastructure.UserInterface
{
	public class ViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// Raised when a property of the view model changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises the PropertyChanged event.
		/// </summary>
		/// <param name="propertyName">The name of the property that changed.</param>
		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Gets the current DebuggerClient instance.
		/// </summary>
		protected DebuggerClient DebuggerClient
		{
			get { return Application.Current as DebuggerClient; }
		}

		/// <summary>
		/// Shows the model's view. If the view is already shown, it is focused.
		/// </summary>
		public virtual void Show()
		{

		}
	}
}
