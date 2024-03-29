using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horde3DNET;
using Server.NativeInterop;

namespace Infrastructure.Core.Server
{
	class Horde3DStateWatcher
	{
		/// <summary>
		/// Indicates whether the application allows debugging.
		/// </summary>
		private bool applicationAllowsDebugging = false;

		public Horde3DStateWatcher()
		{
			Horde3DCall.Render += OnRenderCalled;
			Horde3DCall.Init += OnInitCalled;
			Horde3DCall.CheckExtension += OnCheckExtensionCalled;
		}

		private void OnRenderCalled(bool returnValue, int cameraNode)
		{
			if (!applicationAllowsDebugging)
			{
				Interop.ShowMessageBox("The application does not allow debugging.\n\nTo allow debugging, the application must call 'Horde3D::checkExtension' and pass \"AllowDebugging\" as the 'extensionName' parameter before the first invocation of 'Horde3D::render'.\n\nThe application will now exit.", "Debugging not allowed");
				Environment.Exit(2);
			}
		}

		private void OnInitCalled(bool returnValue)
		{
			Horde3D.setOption(Horde3D.EngineOptions.MaxLogLevel, 5.0f);
		}

		private void OnCheckExtensionCalled(bool returnValue, string extensionName)
		{
			if (extensionName == "AllowDebugging")
				applicationAllowsDebugging = true;
		}
	}
}
