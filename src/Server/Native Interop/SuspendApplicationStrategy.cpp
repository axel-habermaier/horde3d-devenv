#include "SuspendApplicationStrategy.h"
#include "StopTimeSuspendStrategy.h"
#include "WndProcSuspendStrategy.h"
#include "CursorSuspendStrategy.h"

using namespace Server::NativeInterop;

SuspendApplicationStrategy::SuspendApplicationStrategy()
{
	wndProcStrategy = gcnew WndProcSuspendStrategy();
	strategies = gcnew List<ISuspendApplicationStrategy^>();
	strategies->Add(gcnew CursorSuspendStrategy());
	strategies->Add(wndProcStrategy);
	strategies->Add(gcnew StopTimeSuspendStrategy());
}

SuspendApplicationStrategy::~SuspendApplicationStrategy()
{
	CleanUp();
}

SuspendApplicationStrategy::!SuspendApplicationStrategy()
{
	CleanUp();
}

void SuspendApplicationStrategy::CleanUp()
{
	for (int i = 0; i < strategies->Count; ++i)
		delete strategies[i];

	strategies->Clear();
}

void SuspendApplicationStrategy::Suspend()
{
	for (int i = 0; i < strategies->Count; ++i)
		strategies[i]->Suspend();
}

void SuspendApplicationStrategy::Resume()
{
	for (int i = 0; i < strategies->Count; ++i)
		strategies[i]->Resume();
}