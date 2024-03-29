#pragma once

#define WIN32_LEAN_AND_MEAN
#include <Windows.h>
#include "Horde3D.h"

using namespace System;
using namespace System::Drawing;

namespace Server
{
	namespace NativeInterop
	{
		public ref class Interop
		{
		public:
			// Shows a message box.
			static void ShowMessageBox(String^ message, String^ title);

			// Loads all unloaded Horde3D resources from the disk.
			static void LoadResourcesFromDisk(String^ contentDir);

			// Gets the data of a render target.
			static Image^ GetRenderTargetData(ResHandle pipelineResHandle, String^ renderTargetName, int colorBufferIndex);

			// Loads the dlls.
			static void LoadDlls(String^ horde3DDllPath, String^ horde3DUtilsDllPath);

		private:
			static HINSTANCE horde3DUtilsDll = 0;
			static HINSTANCE horde3DDll = 0;
		};
	}
}