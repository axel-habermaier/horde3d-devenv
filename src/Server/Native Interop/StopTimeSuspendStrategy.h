#pragma once

#include "ISuspendApplicationStrategy.h"

namespace Server
{
	namespace NativeInterop
	{
		ref class StopTimeSuspendStrategy : ISuspendApplicationStrategy
		{
		public:
			virtual void Resume();
			virtual void Suspend();

			StopTimeSuspendStrategy();
			virtual ~StopTimeSuspendStrategy();
			!StopTimeSuspendStrategy();

		private:
			bool attached;

			void CleanUp();
		};
	}
}