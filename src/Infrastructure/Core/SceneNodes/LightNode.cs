using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Horde3DNET;

namespace Infrastructure.Core.SceneNodes
{
	[DataContract]
	public class LightNode : SceneNode
	{
		internal LightNode(int nodeHandle)
			: base(nodeHandle)
		{
		}

		public override Horde3D.SceneNodeTypes SceneNodeType
		{
			get { return Horde3D.SceneNodeTypes.Light; }
		}
	}
}
