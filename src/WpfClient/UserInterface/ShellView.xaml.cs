using System;
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
using System.Windows.Shapes;
using AvalonDock;
using System.IO;

namespace WpfClient.UserInterface
{
	/// <summary>
	/// Interaction logic for AppWindow.xaml
	/// </summary>
	public partial class ShellView : Window
	{
		public ShellView()
		{
			InitializeComponent();
			this.DataContextChanged += new DependencyPropertyChangedEventHandler(ShellView_DataContextChanged);
		}

		void ShellView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue != null)
			{
				var viewModel = this.DataContext as Shell;
				InputBindings.Add(new KeyBinding(viewModel.SaveCommand, new KeyGesture(Key.S, ModifierKeys.Control)));
				((System.Collections.Specialized.INotifyCollectionChanged)viewModel.Documents).CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(ShellView_CollectionChanged);
			}
		}

		void ShellView_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
				foreach (var i in e.NewItems)
					dockingManager.Show(new DocumentContent { Content = i });
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			(this.DataContext as Shell).ExitCommand.Execute(null);
		}

		public void RestoreLayout(Stream stream)
		{
			dockingManager.RestoreLayout(stream);
		}

		public void SaveLayout(Stream stream)
		{
			dockingManager.SaveLayout(stream);
		}
	}
}
