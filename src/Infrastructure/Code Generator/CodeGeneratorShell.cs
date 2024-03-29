using System;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.CodeGenerator.Presenters;
using Infrastructure.CodeGenerator.Logic;
using Infrastructure.CodeGenerator.Commands;
using System.Threading;

namespace Infrastructure.CodeGenerator
{
	class CodeGeneratorShell : Shell<CodeGeneratorShell, ShellPresenter>
	{
		#region Current Code Generation Settings
		private CodeGenerationSettings currentSettings;

		/// <summary>
		/// Raised when the CurrentSettings property was changed.
		/// </summary>
		public event EventHandler CurrentSettingsChanged;

		/// <summary>
		/// Raised when the CurrentSettings property is about to change.
		/// </summary>
		public event EventHandler CurrentSettingsChanging;

		/// <summary>
		/// Gets or sets the current code generation settings.
		/// </summary>
		public CodeGenerationSettings CurrentSettings
		{
			get { return currentSettings; }
			set
			{
				if (CurrentSettingsChanging != null)
					CurrentSettingsChanging(this, EventArgs.Empty);

				currentSettings = value;

				if (CurrentSettingsChanged != null)
					CurrentSettingsChanged(this, EventArgs.Empty);
			}
		}
		#endregion

		public CodeGeneratorShell()
			: base()
		{
			// Close all function detail views when the settings change.
			CurrentSettingsChanged += new EventHandler(CodeGeneratorShell_CurrentSettingsChanged);
			CurrentSettingsChanging += new EventHandler(CodeGeneratorShell_CurrentSettingsChanging);

			RegisterPresenter(new FunctionListPresenter());

			// Load the previously used settings
			try
			{
				var settings = Properties.Settings.Default.LastSettings;
				if (!String.IsNullOrEmpty(settings))
					CurrentSettings = CodeGenerationSettings.LoadCodeGenerationSettings(settings);
			}
			catch (Exception)
			{
				// The old settings file has been removed. Just ignore it.
			}
		}

		void CodeGeneratorShell_CurrentSettingsChanging(object sender, EventArgs e)
		{
			if (CurrentSettings != null)
				CurrentSettings.FunctionsChanged -= new EventHandler((o2, e2) => ClearFunctionDetailsPresenters());
		}

		void  CodeGeneratorShell_CurrentSettingsChanged(object sender, EventArgs e)
		{
			if (CurrentSettings != null)
				CurrentSettings.FunctionsChanged += new EventHandler((o2, e2) => ClearFunctionDetailsPresenters());
			ClearFunctionDetailsPresenters();
		}

		private void ClearFunctionDetailsPresenters()
		{
			var presenters = from p in RegisteredPresenters
							 where p is FunctionDetailsPresenter
							 select p;

			presenters.Foreach(p => UnregisterPresenter(p));
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Application.ThreadException += HandleException;

			new CodeGeneratorShell();

			Application.Run();
			Application.ThreadException -= HandleException;
		}

		private static void HandleException(object sender, ThreadExceptionEventArgs e)
		{
			MessageBox.Show(e.Exception.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
