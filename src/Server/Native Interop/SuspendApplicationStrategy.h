#pragma once

#include "ISuspendApplicationStrategy.h"
#include "WndProcSuspendStrategy.h"

using namespace System;
using namespace System::Collections::Generic;

namespace Server 
{
	namespace NativeInterop
	{
		public ref class SuspendApplicationStrategy : ISuspendApplicationStrategy
		{
		private:
			List<ISuspendApplicationStrategy^>^ strategies;
			WndProcSuspendStrategy^ wndProcStrategy;

			void CleanUp();

		public:
			SuspendApplicationStrategy();
			virtual ~SuspendApplicationStrategy();
			!SuspendApplicationStrategy();

			virtual void Suspend();
			virtual void Resume();

			event EventHandler^ SuspendRequested
			{
				void add(EventHandler^ handler)
				{
					wndProcStrategy->SuspendRequested += handler;
				}
				void remove(EventHandler^ handler)
				{
					wndProcStrategy->SuspendRequested -= handler;
				}
			}

			event EventHandler^ ResumeRequested
			{
				void add(EventHandler^ handler)
				{
					wndProcStrategy->ResumeRequested += handler;
				}
				void remove(EventHandler^ handler)
				{
					wndProcStrategy->ResumeRequested -= handler;
				}
			}

			event EventHandler^ ProfilingRequested
			{
				void add(EventHandler^ handler)
				{
					wndProcStrategy->ProfilingRequested += handler;
				}
				void remove(EventHandler^ handler)
				{
					wndProcStrategy->ProfilingRequested -= handler;
				}
			}
		};
	}
}
