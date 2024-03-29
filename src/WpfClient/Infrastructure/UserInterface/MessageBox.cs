using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfClient.Infrastructure.UserInterface
{
	class MessageBox
	{
		/// <summary>
		/// Shows a message box with the given question and title.
		/// </summary>
		/// <param name="question">The question that should be shown to the user.</param>
		/// <param name="title">The message box' title.</param>
		/// <returns>True if the user answered positively, otherwise false.</returns>
		public static bool Ask(string question, string title)
		{
			return System.Windows.MessageBox.Show(question, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
		}
	}
}
