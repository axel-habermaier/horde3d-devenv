using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Horde3DNET;

namespace Infrastructure.Core.Resources
{
	[DataContract]
	public abstract class Resource
	{
		/// <summary>
		/// Initializes a resource instance.
		/// </summary>
		/// <param name="resHandle">The resource handle.</param>
		internal Resource(int resHandle)
		{
			ResHandle = resHandle;
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		[DataMember]
		public string Name { get; protected set; }

		/// <summary>
		/// Gets the resource handle.
		/// </summary>
		[DataMember]
		public int ResHandle { get; protected set; }

		/// <summary>
		/// Gets or sets the resource graph this resource belongs to.
		/// </summary>
		public ResourceGraph ResourceGraph { get; set; }

		/// <summary>
		/// Gets the resource's Horde3D type.
		/// </summary>
		public abstract Horde3D.ResourceTypes ResourceType { get; }

		/// <summary>
		/// Initializes the resource instance with the current Horde3D state. Deriving classes must override this
		/// method but must also call the base implementation.
		/// </summary>
		internal virtual void InitializeFromHorde3DState()
		{
			Name = Horde3D.getResourceName(ResHandle);
		}
	}
}
