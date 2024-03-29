using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Horde3DNET;
using Infrastructure.Core.Server;
using Server.NativeInterop;

namespace Infrastructure.Core.Resources
{
	[DataContract]
	public class MaterialResource : EditableResource
	{
		internal MaterialResource(int resHandle)
			: base(resHandle)
		{

		}

		public override Horde3D.ResourceTypes ResourceType
		{
			get { return Horde3D.ResourceTypes.Material; }
		}

		/// <summary>
		/// Unloads the resource currently used by Horde3D and reloads it immediately.
		/// </summary>
		internal override void UpdateHorde3D()
		{
			// Update all cloned materials.
			var resHandle = 0;
			var reload = new List<int>();
			while ((resHandle = Horde3D.getNextResource((int)Horde3D.ResourceTypes.Material, resHandle)) != 0)
			{
				if (Horde3D.getResourceName(resHandle).Contains(Name))
					reload.Add(resHandle);
			}

			var data = ASCIIEncoding.ASCII.GetBytes(FileContent);
			foreach (var materialRes in reload)
			{
				Horde3D.unloadResource(materialRes);
				Horde3D.loadResource(materialRes, data, data.Length);
			}

			Interop.LoadResourcesFromDisk(Horde3DDebugger.Instance.Configuration.ContentDirectory);
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
