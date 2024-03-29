using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.CodeGenerator.Views;
using WeifenLuo.WinFormsUI.Docking;
using Infrastructure.UserInterface;
using Infrastructure.UserInterface.WinForms.Commands;
using Infrastructure.CodeGenerator.Commands;
using System.Collections.Specialized;
using Infrastructure.UserInterface.WinForms;

namespace Infrastructure.CodeGenerator.Presenters
{
	class ShellPresenter : CodeGeneratorPresenter<ShellView>, IShellPresenter
	{
		private EventHandler settingsChangedEnableButtonsHandler;
		private EventHandler settingsChangedSetTitleHandler;

		public ShellPresenter()
			: base()
		{
			settingsChangedEnableButtonsHandler = new EventHandler((o, e) => EnableButtons(Shell.CurrentSettings != null));
			settingsChangedSetTitleHandler = new EventHandler((o, e) => UpdateView(view => view.SetTitle(Shell.CurrentSettings)));
		}

		public DockPanel DockPanel 
		{
			get
			{
				DockPanel panel = null;
				UpdateView(view => panel = view.DockPanel);
				return panel;
			}
		}

		protected override bool InitializeEvents()
		{
			UpdateView(view => view.ExitRequest += new RequestHandler(() => HandleCommand(new ExitCommand())));
			UpdateView(view => view.NewSettingsRequest += new RequestHandler(() => HandleCommand(new NewSettingsCommand())));
			UpdateView(view => view.SaveSettingsAsRequest += new RequestHandler(() => HandleCommand(new SaveSettingsAsCommand())));
			UpdateView(view => view.SaveSettingsRequest += new RequestHandler(() => HandleCommand(new SaveSettingsCommand())));
			UpdateView(view => view.LoadSettingsRequest += new RequestHandler(() => HandleCommand(new LoadSettingsCommand())));
			UpdateView(view => view.ResetSettingsRequest += new RequestHandler(() => HandleCommand(new ResetCommand())));
			UpdateView(view => view.ParseRequest += new RequestHandler<string>((filePath) => HandleCommand(new ParseCommand(filePath))));
			UpdateView(view => view.AddHeaderFileRequest += new RequestHandler<string>((filePath) => AddHeaderFile(filePath)));
			UpdateView(view => view.ChangeSettingsRequest += new RequestHandler(() => Shell.RegisterPresenter(new SettingsDetailsPresenter())));
			UpdateView(view => view.ShowFunctionListRequest += new RequestHandler(() => Shell.RegisterPresenter(new FunctionListPresenter())));
			UpdateView(view => view.GenerateCodeRequest += new RequestHandler(() => HandleCommand(new GenerateCodeCommand())));
			UpdateView(view => view.AboutRequest += new RequestHandler(() => Shell.RegisterPresenter(new CodeGeneratorPresenter<AboutView>())));

			Shell.CurrentSettingsChanged += settingsChangedEnableButtonsHandler;
			Shell.CurrentSettingsChanged += settingsChangedSetTitleHandler;

			return base.InitializeEvents();
		}

		protected override void Release()
		{
			Shell.CurrentSettingsChanged -= settingsChangedEnableButtonsHandler;
			Shell.CurrentSettingsChanged -= settingsChangedSetTitleHandler;

			base.Release();
		}

		protected void EnableButtons(bool enable)
		{
			UpdateView(view => view.AllowSaving = enable);
			UpdateView(view => view.AllowChangeSettings = enable);
			UpdateView(view => view.AllowReset = enable);
			UpdateView(view => view.AllowParsing = enable);
			UpdateView(view => view.AllowCodeGeneration = enable);
		}

		protected override bool Initialize()
		{
			UpdateView(view => view.BuildHeaderFileMenu());
			EnableButtons(false);

			return true;
		}

		private void AddHeaderFile(string filePath)
		{
			if (String.IsNullOrEmpty(filePath))
				return;

			var headerFiles = Properties.Settings.Default.HeaderFiles;
			if (headerFiles == null)
				headerFiles = new StringCollection();

			headerFiles.Remove(filePath);
			headerFiles.Insert(0, filePath);

			Properties.Settings.Default.HeaderFiles = headerFiles;
			Properties.Settings.Default.Save();

			UpdateView(view => view.BuildHeaderFileMenu());
		}
	}
}
