using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horde3DNET;

namespace Infrastructure.Core.SceneNodes
{
	class SceneNodeFactory : Singleton<SceneNodeFactory>
	{
		internal SceneNode CreateSceneNode(int nodeHandle)
		{
			var nodeType = Horde3D.getNodeType(nodeHandle);

			switch (nodeType)
			{
				case Horde3D.SceneNodeTypes.Undefined:
				default:
					return null;
				case Horde3D.SceneNodeTypes.Model:
					return new ModelNode(nodeHandle);
				case Horde3D.SceneNodeTypes.Mesh:
					return new MeshNode(nodeHandle);
				case Horde3D.SceneNodeTypes.Light:
					return new LightNode(nodeHandle);
				case Horde3D.SceneNodeTypes.Joint:
					return new JointNode(nodeHandle);
				case Horde3D.SceneNodeTypes.Group:
					return new GroupNode(nodeHandle);
				case Horde3D.SceneNodeTypes.Emitter:
					return new EmitterNode(nodeHandle);
				case Horde3D.SceneNodeTypes.Camera:
					return new CameraNode(nodeHandle);
			}
		}
	}
}
