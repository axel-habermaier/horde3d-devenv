using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Server
{
	public class ServerConfiguration
	{
		/// <summary>
		/// Gets or sets the address used to communicate with the client.
		/// </summary>
		public string CommunicationAddress { get; set; }

		/// <summary>
		/// Indicates whether the debugger should be launched when the server starts.
		/// </summary>
		public bool LaunchDebugger { get; set; }

		/// <summary>
		/// Gets or sets the application's content directory.
		/// </summary>
		public string ContentDirectory { get; set; }

		/// <summary>
		/// Gets or sets the path to the original Horde3D.dll used by the application.
		/// </summary>
		public string OriginalHorde3DDllPath { get; set; }

		/// <summary>
		/// Gets or sets the path to the original Horde3DUtils.dll used by the application.
		/// </summary>
		public string OriginalHorde3DUtilsDllPath { get; set; }
	}
}
