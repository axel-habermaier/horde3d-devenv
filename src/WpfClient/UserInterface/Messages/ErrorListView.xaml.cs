﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfClient.UserInterface.Messages
{
	/// <summary>
	/// Interaction logic for ErrorListView.xaml
	/// </summary>
	public partial class ErrorListView : UserControl
	{
		public ErrorListView()
		{
			InitializeComponent();

			DataContext = (Application.Current as DebuggerClient).ErrorList;
		}
	}
}
