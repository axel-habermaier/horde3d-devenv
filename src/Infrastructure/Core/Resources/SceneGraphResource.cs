using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Horde3DNET;

namespace Infrastructure.Core.Resources
{
	[DataContract]
	public class SceneGraphResource : Resource
	{
		internal SceneGraphResource(int resHandle) 
			: base(resHandle)
		{

		}

		public override Horde3D.ResourceTypes ResourceType
		{
			get { return Horde3D.ResourceTypes.SceneGraph; }
		}
	}
}
