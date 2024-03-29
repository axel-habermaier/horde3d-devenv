using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horde3DNET;
using System.Collections.ObjectModel;

namespace Infrastructure.Core.SceneNodes
{
	public class SceneGraph : Graph<int, SceneNode>
	{
		#region Static Methods
		internal static List<SceneNode> GetSceneGraphFromHorde3D()
		{
			var numNodes = Horde3D.findNodes(Horde3D.RootNode, String.Empty, (int)Horde3D.SceneNodeTypes.Undefined);
			var list = new List<SceneNode>(numNodes);

			for (int i = 0; i < numNodes; ++i)
			{
				var nodeHandle = Horde3D.getNodeFindResult(i);
				var node = GetSceneNode(nodeHandle);
				if (node != null)
					list.Add(node);
			}

			return list;
		}

		private static SceneNode GetSceneNode(int nodeHandle)
		{
			var node = SceneNodeFactory.Instance.CreateSceneNode(nodeHandle);

			if (node == null)
				return null;

			node.InitializeFromHorde3DState();
			return node;
		}
		#endregion

		protected override Func<SceneNode, int> NodeIdentifier
		{
			get { return s => s.NodeHandle; }
		}
	}
}
