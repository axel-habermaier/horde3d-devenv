using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Horde3DNET;

namespace Infrastructure.Core.Resources
{
	[DataContract]
	public class ParticleEffectResource : EditableResource
	{
		internal ParticleEffectResource(int resHandle) 
			: base(resHandle)
		{

		}

		public override Horde3D.ResourceTypes ResourceType
		{
			get { return Horde3D.ResourceTypes.ParticleEffect; }
		}

		/// <summary>
		/// Loads the resource from Xml stored in the FileContent property.
		/// </summary>
		public override void LoadFromXml()
		{

		}

		/// <summary>
		/// Generates the Xml content and updates the FileContent property.
		/// </summary>
		public override void GenerateXml()
		{

		}
	}
}
