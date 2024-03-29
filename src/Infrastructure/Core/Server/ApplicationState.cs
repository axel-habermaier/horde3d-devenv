using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Server
{
	/// <summary>
	/// The state of the Horde3D application.
	/// </summary>
	enum ApplicationState
	{
		/// <summary>
		/// The application is currently running.
		/// </summary>
		Running,
		/// <summary>
		/// The application is currently suspended.
		/// </summary>
		Suspended,
		/// <summary>
		/// The application is currently profiling.
		/// </summary>
		Profiling
	}
}
