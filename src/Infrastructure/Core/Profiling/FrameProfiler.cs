using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.Server;
using Infrastructure.Core.Communication;
using System.Diagnostics;

namespace Infrastructure.Core.Profiling
{
	internal class FrameProfiler : Singleton<FrameProfiler>
	{
		/// <summary>
		/// Indicates whether the profiler is currently profiling.
		/// </summary>
		public bool Profiling { get; set; }

		/// <summary>
		/// Indicates whether the application was suspended before the profiling started.
		/// </summary>
		private bool wasSuspended = false;

		public FrameProfiler()
			: base()
		{
			Profiling = false;
		}

		public void Profile()
		{
			Debug.Assert(!Profiling, "Cannot restart profiling whilst still profiling.");

			Horde3DCall.ClearFunctionCalls();
			Profiling = true;
			wasSuspended = false;
			Horde3DCall.FinalizeFrame += StartProfiling;
		}

		private void FinishProfiling(bool returnValue)
		{
			if (wasSuspended)
				Horde3DDebugger.Instance.Suspend();

			Horde3DCall.FinalizeFrame -= FinishProfiling;
			Horde3DDebugger.Instance.ProxyHandler.EnableProfiling = false;
			DebuggerService.OnProfiled();
			Profiling = false;
		}

		private void StartProfiling(bool returnValue)
		{
			Horde3DDebugger.Instance.ProxyHandler.EnableProfiling = true;
			wasSuspended = Horde3DDebugger.Instance.ApplicationState == ApplicationState.Suspended;
			Horde3DDebugger.Instance.Resume();
			Horde3DCall.FinalizeFrame -= StartProfiling;
			Horde3DCall.FinalizeFrame += FinishProfiling;
		}
	}
}
