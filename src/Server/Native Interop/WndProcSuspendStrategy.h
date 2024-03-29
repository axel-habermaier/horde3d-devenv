#pragma once

#include "ISuspendApplicationStrategy.h"

namespace Server
{
	namespace NativeInterop
	{
		ref class WndProcSuspendStrategy : ISuspendApplicationStrategy
		{
		public:
			WndProcSuspendStrategy();
			virtual ~WndProcSuspendStrategy();
			!WndProcSuspendStrategy();

			virtual void Resume();
			virtual void Suspend();

			EventHandler^ suspendRequested;
			EventHandler^ resumeRequested;
			EventHandler^ profilingRequested;

			event EventHandler^ SuspendRequested
			{
				void add(EventHandler^ handler)
				{
					suspendRequested += handler;
				}
				void remove(EventHandler^ handler)
				{
					suspendRequested -= handler;
				}
				void raise(Object^ sender, EventArgs^ e)
				{
					EventHandler^ tmp = suspendRequested;
					if (tmp)
						tmp->Invoke(sender, e);
				}
			}

			event EventHandler^ ResumeRequested
			{
				void add(EventHandler^ handler)
				{
					resumeRequested += handler;
				}
				void remove(EventHandler^ handler)
				{
					resumeRequested -= handler;
				}
				void raise(Object^ sender, EventArgs^ e)
				{
					EventHandler^ tmp = resumeRequested;
					if (tmp)
						tmp->Invoke(sender, e);
				}
			}

			event EventHandler^ ProfilingRequested
			{
				void add(EventHandler^ handler)
				{
					profilingRequested += handler;
				}
				void remove(EventHandler^ handler)
				{
					profilingRequested -= handler;
				}
				void raise(Object^ sender, EventArgs^ e)
				{
					EventHandler^ tmp = profilingRequested;
					if (tmp)
						tmp->Invoke(sender, e);
				}
			}

		private:
			void CleanUp();
		};
	}
}