using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Server
{
	public interface IProxyHandler
	{
		bool EnableProfiling { get; set; }
	}
}
