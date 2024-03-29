#define WIN32_LEAN_AND_MEAN

#include "StopTimeSuspendStrategy.h"
#include <Windows.h>
#include "detours.h"

using namespace Server::NativeInterop;

#pragma unmanaged
/* Global state */
// QueryPerformanceCounter function pointer.
typedef BOOL (WINAPI *ptrQueryPerformanceCounter)(__out LARGE_INTEGER *lpPerformanceCount);
ptrQueryPerformanceCounter g_pQueryPerformanceTimer;

// Indicates whether the time should be stopped.
bool g_stopTime = false;

// The last time returned by QueryPerformanceCounter before the application was suspended.
LARGE_INTEGER g_last;

// The amount of time the application was in suspended state.
LARGE_INTEGER g_timeDelta;

// This is the function that is actually called when the application calls QueryPerformanceTimer.
BOOL WINAPI QueryPerformanceCounterDetour(__out LARGE_INTEGER* lpPerformanceCount)
{
	BOOL res = g_pQueryPerformanceTimer(lpPerformanceCount);

	if (!g_stopTime)
		lpPerformanceCount->QuadPart = lpPerformanceCount->QuadPart - g_timeDelta.QuadPart;
	else
		lpPerformanceCount->QuadPart = g_last.QuadPart - g_timeDelta.QuadPart;

	return res;
}
#pragma managed

void StopTimeSuspendStrategy::Suspend()
{
	g_stopTime = true;

	LARGE_INTEGER currentTime;
	g_pQueryPerformanceTimer(&currentTime);

	g_last.QuadPart = currentTime.QuadPart;
}

void StopTimeSuspendStrategy::Resume()
{
	g_stopTime = false;

	LARGE_INTEGER currentTime;
	g_pQueryPerformanceTimer(&currentTime);

	g_timeDelta.QuadPart = g_timeDelta.QuadPart + (currentTime.QuadPart - g_last.QuadPart);
}

StopTimeSuspendStrategy::StopTimeSuspendStrategy()
{
	HINSTANCE kernel32Dll = LoadLibrary("kernel32.dll");

	g_last.QuadPart = 0;
	g_timeDelta.QuadPart = 0;
	g_pQueryPerformanceTimer = (ptrQueryPerformanceCounter)GetProcAddress(kernel32Dll, "QueryPerformanceCounter");

	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());
	DetourAttach(&(PVOID&)g_pQueryPerformanceTimer, QueryPerformanceCounterDetour);
	DetourTransactionCommit();
	attached = true;
}

StopTimeSuspendStrategy::~StopTimeSuspendStrategy()
{
	CleanUp();
}

StopTimeSuspendStrategy::!StopTimeSuspendStrategy()
{
	CleanUp();
}

void StopTimeSuspendStrategy::CleanUp()
{
	if (!attached)
		return;

	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());
	DetourDetach(&(PVOID&)g_pQueryPerformanceTimer, QueryPerformanceCounterDetour);
	DetourTransactionCommit();
	attached = false;
}