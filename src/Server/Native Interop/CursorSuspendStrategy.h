#pragma once

#include "ISuspendApplicationStrategy.h"

namespace Server
{
	namespace NativeInterop
	{
		ref class CursorSuspendStrategy : ISuspendApplicationStrategy
		{
		public:
			virtual void Resume();
			virtual void Suspend();

			CursorSuspendStrategy();
			virtual ~CursorSuspendStrategy();
			!CursorSuspendStrategy();

		private:
			bool attached;

			void CleanUp();
		};
	}
}