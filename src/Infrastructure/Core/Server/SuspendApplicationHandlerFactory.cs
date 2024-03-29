using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Server
{
	class SuspendApplicationHandlerFactory : Singleton<SuspendApplicationHandlerFactory>
	{
		public ISuspendApplicationHandler CreateHandler(ServerConfiguration configuration)
		{
			return null;
		}
	}
}
