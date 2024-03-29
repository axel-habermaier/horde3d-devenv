using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.CodeGenerator.Views;
using System.ComponentModel;
using Infrastructure.CodeGenerator.Logic;
using Infrastructure.UserInterface;

namespace Infrastructure.CodeGenerator.Presenters
{
	class FunctionListPresenter : CodeGeneratorPresenter<FunctionListView>
	{
		private EventHandler registerFunctionHandler;
		private EventHandler unregisterFunctionHandler;
		private EventHandler setFunctionsHandler;

		public FunctionListPresenter()
			: base()
		{
			unregisterFunctionHandler = new EventHandler((o, e) => UnregisterFunctionUpdates());
			registerFunctionHandler = new EventHandler((o, e) => RegisterFunctionUpdates());
			setFunctionsHandler = new EventHandler((o2, e2) => SetFunctions());
		}

		protected override bool Initialize()
		{
			RegisterFunctionUpdates();

			return base.Initialize();
		}

		void RegisterFunctionUpdates()
		{
			if (Shell.CurrentSettings != null)
			{
				Shell.CurrentSettings.FunctionsChanged += setFunctionsHandler;
				SetFunctions();
			}
			else
				UpdateView(view => view.ClearFunctions());
		}

		void UnregisterFunctionUpdates()
		{
			if (Shell.CurrentSettings != null)
				Shell.CurrentSettings.FunctionsChanged -= setFunctionsHandler;
		}

		void SetFunctions()
		{
			if (Shell.CurrentSettings.Functions != null)
			{
				UpdateView(view => view.Functions = Shell.CurrentSettings.Functions);
				UpdateView(view => view.ProblematicFunctions = Shell.CurrentSettings.ProblematicFunctions);
			}
			else
				UpdateView(view => view.ClearFunctions());
		}

		protected override bool InitializeEvents()
		{
			Shell.CurrentSettingsChanged += registerFunctionHandler;
			Shell.CurrentSettingsChanging += unregisterFunctionHandler;

			UpdateView(view => view.FunctionDetailsRequest += new RequestHandler<Function>(f =>
			{
				var presenter = new FunctionDetailsPresenter(f);
				presenter.FunctionModified += new EventHandler((o, e) => view.UpdateFunction(presenter.Function));
				Shell.RegisterPresenter(presenter);
			}));

			return true;
		}

		protected override void Release()
		{
			UnregisterFunctionUpdates();

			Shell.CurrentSettingsChanged -= registerFunctionHandler;
			Shell.CurrentSettingsChanging -= unregisterFunctionHandler;

			base.Release();
		}
	}
}
