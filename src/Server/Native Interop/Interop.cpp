#include "Interop.h"
#include "Horde3DUtils.h"
#include <sstream>

using namespace Server::NativeInterop;
using namespace System::Runtime::InteropServices;
using namespace System::Drawing;
using namespace System::Drawing::Imaging;

void Interop::LoadDlls(String^ horde3DDllPath, String^ horde3DUtilsDllPath)
{
	char* nativeHorde3DUtilsDllPath = (char*)Marshal::StringToHGlobalAnsi(horde3DUtilsDllPath).ToPointer();
	horde3DUtilsDll = LoadLibrary(nativeHorde3DUtilsDllPath);
	Marshal::FreeHGlobal(IntPtr(nativeHorde3DUtilsDllPath));

	if (horde3DUtilsDll == 0)
		throw gcnew ArgumentException("Cannot load library " + horde3DUtilsDllPath + ".");

	char* nativeHorde3DDllPath = (char*)Marshal::StringToHGlobalAnsi(horde3DDllPath).ToPointer();
	horde3DDll = LoadLibrary(nativeHorde3DDllPath);
	Marshal::FreeHGlobal(IntPtr(nativeHorde3DDllPath));

	if (horde3DDll == 0)
		throw gcnew ArgumentException("Cannot load library " + horde3DDllPath + ".");
}

void Interop::ShowMessageBox(String^ message, String^ title)
{
	char* nativeMessage = (char*)Marshal::StringToHGlobalAnsi(message).ToPointer();
	char* nativeTitle = (char*)Marshal::StringToHGlobalAnsi(title).ToPointer();
	::MessageBox(0, nativeMessage, nativeTitle, 0);
	Marshal::FreeHGlobal(IntPtr(nativeMessage));
	Marshal::FreeHGlobal(IntPtr(nativeTitle));
}

typedef bool(*h3dUtilsPtrLoadResourcesFromDisk)(const char* contentDir);
void Interop::LoadResourcesFromDisk(String^ contentDir)
{
	h3dUtilsPtrLoadResourcesFromDisk h3dUtilsLoadResourcesFromDisk = (h3dUtilsPtrLoadResourcesFromDisk)(GetProcAddress(horde3DUtilsDll, "loadResourcesFromDisk"));
	if (h3dUtilsLoadResourcesFromDisk == 0)
		ShowMessageBox("Unable to find address of function 'loadResourcesFromDisk'.", "Error");

	char* nativeContentDir = (char*)Marshal::StringToHGlobalAnsi(contentDir).ToPointer();
	h3dUtilsLoadResourcesFromDisk(nativeContentDir);
	Marshal::FreeHGlobal(IntPtr(nativeContentDir));
}

typedef bool(*h3dPtrGetPipelineRenderTargetData)(ResHandle pipelineRes, const char* targetName, int bufIndex, int* width, int* height, int* compCount, float* dataBuffer, int bufferSize);
Image^ Interop::GetRenderTargetData(ResHandle pipelineResHandle, String^ renderTargetName, int colorBufferIndex)
{
	h3dPtrGetPipelineRenderTargetData h3dGetPipelineRenderTargetData = (h3dPtrGetPipelineRenderTargetData)(GetProcAddress(horde3DDll, "getPipelineRenderTargetData"));
	if (h3dGetPipelineRenderTargetData == 0)
		ShowMessageBox("Unable to find address of function 'getPipelineRenderTargetData'.", "Error");

	char* nativeRenderTargetName = (char*)Marshal::StringToHGlobalAnsi(renderTargetName).ToPointer();	
	int width, height, compCount;
	h3dGetPipelineRenderTargetData(pipelineResHandle, nativeRenderTargetName, colorBufferIndex, &width, &height, &compCount, 0, 0);

	if (compCount != 4)
		ShowMessageBox("Render Target type currently unsupported. CompCount must be 4, but is " + compCount.ToString(), "Error");

	float* databuffer = new float[width * height * compCount];

	h3dGetPipelineRenderTargetData(pipelineResHandle, nativeRenderTargetName, colorBufferIndex, &width, &height, &compCount, databuffer, width * height * compCount * sizeof(float));
	Marshal::FreeHGlobal(IntPtr(nativeRenderTargetName));

	Bitmap^ image = gcnew Bitmap(width, height, PixelFormat::Format32bppArgb);
	BitmapData^ data = image->LockBits(System::Drawing::Rectangle(0, 0, width, height), ImageLockMode::WriteOnly, PixelFormat::Format32bppArgb);

	float* db = databuffer;
	char* imagePointer1 = (char*)data->Scan0.ToPointer();
	for(int i = 0; i < data->Height; i++) {
		for(int j = 0; j < data->Width; j++) {

			imagePointer1[2] = (char)(int)(Math::Max(Math::Min(1.0f, *db), 0.0f) * 255);
			++db;
			imagePointer1[1] = (char)(int)(Math::Max(Math::Min(1.0f, *db), 0.0f) * 255);
			++db;
			imagePointer1[0] = (char)(int)(Math::Max(Math::Min(1.0f, *db), 0.0f) * 255);
			++db;
			imagePointer1[3] = (char)(int)(Math::Max(Math::Min(1.0f, *db), 0.0f) * 255);
			++db;

			imagePointer1 += 4;
		}

		imagePointer1 += data->Stride - (data->Width * 4);
	}

	image->UnlockBits(data);
	delete[] databuffer;
	return image;
}