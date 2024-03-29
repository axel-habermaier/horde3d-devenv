using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Infrastructure.Core.Server;
using Horde3DNET;

namespace Infrastructure.Core.SceneNodes
{
	[DataContract]
	public abstract class SceneNode
	{
		/// <summary>
		/// Initializes a scene node instance.
		/// </summary>
		/// <param name="nodeHandle">The node handle.</param>
		internal SceneNode(int nodeHandle)
		{
			NodeHandle = nodeHandle;
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		[DataMember]
		public string Name { get; private set; }

		/// <summary>
		/// Gets the node handle.
		/// </summary>
		[DataMember]
		public int NodeHandle { get; private set; }

		/// <summary>
		/// Gets the parent.
		/// </summary>
		[DataMember]
		public int ParentHandle { get; private set; }

		/// <summary>
		/// Gets the position.
		/// </summary>
		[DataMember]
		public Vector3 Position { get; private set; }

		/// <summary>
		/// Gets the rotation.
		/// </summary>
		[DataMember]
		public Vector3 Rotation { get; private set; }

		/// <summary>
		/// Gets the scale.
		/// </summary>
		[DataMember]
		public Vector3 Scale { get; private set; }

		/// <summary>
		/// Gets or sets the scene graph this scene node belongs to.
		/// </summary>
		public SceneGraph SceneGraph { get; set; }

		/// <summary>
		/// Gets the scene node's Horde3D type.
		/// </summary>
		public abstract Horde3D.SceneNodeTypes SceneNodeType { get; }

		/// <summary>
		/// Gets the parent.
		/// </summary>
		public SceneNode Parent
		{
			get { return SceneGraph[ParentHandle]; }
		}

		/// <summary>
		/// Initializes the scene node instance with the current Horde3D state. Deriving classes must override this
		/// method but must also call the base implementation.
		/// </summary>
		internal virtual void InitializeFromHorde3DState()
		{
			Name = Horde3D.getNodeParamstr(NodeHandle, (int)Horde3D.SceneNodeParams.Name);
			ParentHandle = Horde3D.getNodeParent(NodeHandle);

			float x, y, z, rx, ry, rz, sx, sy, sz;
			Horde3D.getNodeTransform(NodeHandle, out x, out y, out z, out rx, out ry, out rz, out sx, out sy, out sz);
			Position = new Vector3(x, y, z);
			Rotation = new Vector3(rx, ry, rz);
			Scale = new Vector3(sx, sy, sz);
		}

		public override string ToString()
		{
			return this.GetType().Name + ": " + NodeHandle + ", " + (String.IsNullOrEmpty(Name) ? "unnamed" : Name);
		}
	}
}
