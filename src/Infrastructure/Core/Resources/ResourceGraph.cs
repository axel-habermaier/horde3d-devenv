using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horde3DNET;
using System.Threading;
using System.Collections.ObjectModel;

namespace Infrastructure.Core.Resources
{
	public class ResourceGraph : Graph<int, Resource>
	{
		#region Static Methods
		internal static List<Resource> GetResourceGraphFromHorde3D()
		{
			var list = new List<Resource>();

			var resHandle = 0;
			while ((resHandle = Horde3D.getNextResource((int)Horde3D.ResourceTypes.Undefined, resHandle)) != 0)
			{
				var resource = GetResource(resHandle);

				if (resource != null)
					list.Add(resource);
			}

			return list;
		}

		private static Resource GetResource(int resHandle)
		{
			var resource = ResourceFactory.Instance.CreateResource(resHandle);

			if (resource == null)
				return null;

			resource.InitializeFromHorde3DState();
			return resource;
		}
		#endregion

		protected override Func<Resource, int> NodeIdentifier
		{
			get { return r => r.ResHandle; }
		}
	}
}
