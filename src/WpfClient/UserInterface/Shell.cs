using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfClient.Infrastructure;
using WpfClient.Commands.Horde3DApplication;
using WpfClient.Commands;
using WpfClient.Commands.Shell;
using System.Windows;
using WpfClient.Infrastructure.UserInterface;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace WpfClient.UserInterface
{
	public class Shell : ViewModel
	{
		#region Debugging Commands
		public StartCommand StartApplicationCommand
		{
			get { return new StartCommand(); }
		}

		public StopCommand StopApplicationCommand
		{
			get { return new StopCommand(); }
		}

		public SuspendCommand SuspendApplicationCommand
		{
			get { return new SuspendCommand(); }
		}

		public AdvanceToNextRenderCallCommand AdvanceToNextRenderCallCommand
		{
			get { return new AdvanceToNextRenderCallCommand(); }
		}
		#endregion

		#region Horde3D Application Management Commands
		public NewCommand NewCommand
		{
			get { return new NewCommand(); }
		}

		public SaveCommand SaveCommand
		{
			get { return new SaveCommand(); }
		}

		public SaveAsCommand SaveAsCommand
		{
			get { return new SaveAsCommand(); }
		}

		public UnloadCommand UnloadCommand
		{
			get { return new UnloadCommand(); }
		}

		public LoadCommand LoadCommand
		{
			get { return new LoadCommand(); }
		}

		public ShowSettingsCommand ShowSettingsCommand
		{
			get { return new ShowSettingsCommand(); }
		}
		#endregion

		#region Shell Commands
		public ExitCommand ExitCommand
		{
			get { return new ExitCommand(); }
		}

		public RedoCommand RedoCommand
		{
			get { return new RedoCommand(); }
		}

		public UndoCommand UndoCommand
		{
			get { return new UndoCommand(); }
		}
		#endregion

		private string applicationName = String.Empty;
		/// <summary>
		/// Gets the name of the current Horde3D application.
		/// </summary>
		public string ApplicationName
		{
			get { return applicationName; }
			set
			{
				if (applicationName != value)
				{
					applicationName = value;
					OnPropertyChanged("ApplicationName");
				}
			}
		}

		public Shell()
		{
			DocumentModels = new ObservableCollection<object>();
			Documents = new CollectionView(DocumentModels);
		}

		public ObservableCollection<object> DocumentModels { get; set; }

		
		public CollectionView Documents { get; set; }
	}
}
