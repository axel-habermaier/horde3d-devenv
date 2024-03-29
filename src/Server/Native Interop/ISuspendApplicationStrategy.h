#pragma once

using namespace System;

namespace Server 
{
	namespace NativeInterop
	{
		public interface class ISuspendApplicationStrategy
		{
			void Suspend();
			void Resume();
		};
	}
}