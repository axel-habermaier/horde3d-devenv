#pragma once

#define WIN32_LEAN_AND_MEAN
#include <Windows.h>
#include <vcclr.h>

using namespace Infrastructure::Core::Server;

namespace Horde3D
{
	class Horde3DProfilingProxy;
	class Horde3DNoProfilingProxy;
	class Horde3DProxyBase;

	public ref class Horde3DProxyHandler : IProxyHandler
	{
	private:
		// The name of the original Horde3D Dll.
		const char* hordeDllName;

		// The dll instance.
		HINSTANCE dll;

		Horde3DProfilingProxy* profilingProxy;
		Horde3DNoProfilingProxy* noProfilingProxy;
		Horde3DProxyBase* currentProxy;

		void Initialize();
		void Uninitialize();

	public:
		property bool EnableProfiling
		{
			virtual bool get();
			virtual void set(bool enabled);
		}

		Horde3DProxyHandler()
			: hordeDllName(0), dll(0)
		{
			Initialize();
		}

		~Horde3DProxyHandler()
		{
			Uninitialize();
		}

		Horde3DProxyBase* GetCurrentProxy()
		{
			return currentProxy;
		}
	};

	// Native ProxyHandler class that wraps the Horde3DProxyHandler.
	class NativeProxyHandler
	{
	private:
		gcroot<Horde3DProxyHandler^> proxyHandler;

	public:
		NativeProxyHandler()
		{
			proxyHandler = gcnew Horde3DProxyHandler();
		}

		~NativeProxyHandler()
		{
			delete proxyHandler;
		}

		Horde3DProxyBase* GetCurrentProxy()
		{
			return proxyHandler->GetCurrentProxy();
		}
	};
}