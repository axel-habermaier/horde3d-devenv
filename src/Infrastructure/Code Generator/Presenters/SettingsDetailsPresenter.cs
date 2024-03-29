using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.UserInterface.WinForms;
using Infrastructure.CodeGenerator.Views;

namespace Infrastructure.CodeGenerator.Presenters
{
	class SettingsDetailsPresenter : CodeGeneratorPresenter<SettingsDetailsView>
	{
		private EventHandler settingsChangedHandler;

		public SettingsDetailsPresenter()
			: base()
		{
			settingsChangedHandler = new EventHandler((o, e) =>
			{
				if (Shell.CurrentSettings != null)
					UpdateView(view => view.Settings = Shell.CurrentSettings);
				else
					Shell.UnregisterPresenter(this);
			});
		}

		protected override bool Initialize()
		{
			if (Shell.CurrentSettings != null)
				UpdateView(view => view.Settings = Shell.CurrentSettings);
			else
				return false;

			return true;
		}

		protected override bool InitializeEvents()
		{
			Shell.CurrentSettingsChanged += settingsChangedHandler;

			return base.InitializeEvents();
		}

		protected override void Release()
		{
			Shell.CurrentSettingsChanged -= settingsChangedHandler;

			base.Release();
		}
	}
}
