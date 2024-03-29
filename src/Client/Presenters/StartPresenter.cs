using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Views;
using Client.Commands;
using Client.Models;
using System.Windows.Forms;
using System.IO;

namespace Client.Presenters
{
	class StartPresenter : DebuggerPresenter<StartView>
	{
		protected override bool Initialize()
		{
			return base.Initialize();
		}

		protected override bool InitializeEvents()
		{
			UpdateView(view => view.CreateApplicationRequest += () => HandleCommand(new NewApplicationCommand()));
			UpdateView(view => view.OpenApplicationRequest += () => HandleCommand(new LoadApplicationCommand()));
			UpdateView(view => view.OpenSampleApplicationRequest += () =>
			{
				var sample = new Horde3DApplication();
				sample.ContentDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Knight Sample\Content");
				sample.ExecutablePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Knight Sample/Binaries\Sample_Knight.exe");
				sample.OriginalHorde3DDllPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Knight Sample\Binaries\Horde3D.dll");
				sample.OriginalHorde3DUtilsDllPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Knight Sample\Binaries\Horde3DUtils.dll");
				sample.WorkingDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Knight Sample");
				sample.CommunicationAddress = "net.pipe://localhost/sample";

				using (var writer = new FileStream("Knight Sample/Knight.h3dproj", FileMode.Create, FileAccess.Write))
					XmlSerializer<Horde3DApplication>.Serialize(sample, writer);

				HandleCommand(new LoadApplicationCommand("Knight Sample/Knight.h3dproj"));
				MessageBox.Show("The knight sample has been loaded.", "Sample Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
			});
			Shell.ApplicationStateChanged += OnApplicationStateChanged;

			return base.InitializeEvents();
		}

		protected override void Release()
		{
			Shell.ApplicationStateChanged -= OnApplicationStateChanged;
			base.Release();
		}

		private void OnApplicationStateChanged(object sender, ApplicationStateChangedEventArgs e)
		{
			UpdateView(view => view.State = e.CurrentState);
		}
	}
}
