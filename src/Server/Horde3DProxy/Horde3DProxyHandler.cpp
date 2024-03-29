#include "Horde3DProxyHandler.h"
#include <string>
#include "Horde3DProxies.h"

using namespace Horde3D;
using namespace std;

void Horde3DProxyHandler::Initialize()
{
	Horde3DDebugger::Instance->Initialize(this);
	
	// Read configuration
	hordeDllName = "Horde3D_org.dll";

	// Load the dll
	dll = LoadLibrary(hordeDllName);

	if (dll == 0)
		throw exception((string("Unable to load ") + hordeDllName).c_str());

	noProfilingProxy = new Horde3DNoProfilingProxy();
	profilingProxy = new Horde3DProfilingProxy();

	noProfilingProxy->Initialize(dll);
	profilingProxy->Initialize(dll);

	EnableProfiling = false;
}

void Horde3DProxyHandler::Uninitialize()
{
	if (dll != 0)
	{
		FreeLibrary(dll);
		dll = 0;
	}

	delete noProfilingProxy;
	delete profilingProxy;

	noProfilingProxy = 0;
	profilingProxy = 0;
}


bool Horde3DProxyHandler::EnableProfiling::get() 
{ 
	return currentProxy == profilingProxy; 
}

void Horde3DProxyHandler::EnableProfiling::set(bool enabled)
{
	if (enabled)
		currentProxy = profilingProxy;
	else
		currentProxy = noProfilingProxy;
}