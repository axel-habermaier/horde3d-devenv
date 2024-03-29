using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views;
using Client.Models;
using Infrastructure.UserInterface.WinForms;
using Client.Commands;

namespace Client.Presenters
{
	class ApplicationSettingsPresenter : SaveableContentDebuggerPresenter<ApplicationSettingsView>
	{
		Horde3DApplication settings;

		protected override string FileName
		{
			get { return Shell.Application.FilePath; }
		}

		protected override void Save(System.IO.Stream stream)
		{
			XmlSerializer<Horde3DApplication>.Serialize(settings, stream);
			Shell.Application.Arguments = settings.Arguments;
			Shell.Application.CommunicationAddress = settings.CommunicationAddress;
			Shell.Application.ContentDirectory = settings.ContentDirectory;
			Shell.Application.ExecutablePath = settings.ExecutablePath;
			Shell.Application.LaunchDebugger = settings.LaunchDebugger;
			Shell.Application.OriginalHorde3DDllPath = settings.OriginalHorde3DDllPath;
			Shell.Application.OriginalHorde3DUtilsDllPath = settings.OriginalHorde3DUtilsDllPath;
			Shell.Application.WorkingDirectory = settings.WorkingDirectory;

			SaveState = SaveState.Saved;
		}

		protected override void Load(System.IO.Stream stream)
		{
			settings = XmlSerializer<Horde3DApplication>.Deserialize(stream);
			UpdateView(view => view.Settings = settings);

			SaveState = SaveState.Saved;
		}

		protected override object SaveableContent
		{
			get { return settings; }
		}

		protected override bool InitializeEvents()
		{
			settings.PropertyUpdated += ResourcePropertyUpdated;

			return base.InitializeEvents();
		}

		protected override void Release()
		{
			settings.PropertyUpdated -= ResourcePropertyUpdated;

			base.Release();
		}

		protected void ResourcePropertyUpdated(object sender, PropertyUpdatedEventArgs e)
		{
			SaveState = SaveState.Unsaved;
			HandleCommand(new GenericUpdatePropertyCommand(e.PreviousValue, e.CurrentValue, e.PropertyAccessor));
		}
	}
}
