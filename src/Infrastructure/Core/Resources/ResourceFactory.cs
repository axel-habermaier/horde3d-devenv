using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Horde3DNET;

namespace Infrastructure.Core.Resources
{
	class ResourceFactory : Singleton<ResourceFactory>
	{
		internal Resource CreateResource(int resHandle)
		{
			var resType = (Horde3D.ResourceTypes)Horde3D.getResourceType(resHandle);

			switch (resType)
			{
				case Horde3D.ResourceTypes.Undefined:
				default:
					return null;
				case Horde3D.ResourceTypes.Animation:
					return new AnimationResource(resHandle);
				case Horde3D.ResourceTypes.Code:
					return new CodeResource(resHandle);
				case Horde3D.ResourceTypes.Geometry:
					return new GeometryResource(resHandle);
				case Horde3D.ResourceTypes.Material:
					return new MaterialResource(resHandle);
				case Horde3D.ResourceTypes.ParticleEffect:
					return new ParticleEffectResource(resHandle);
				case Horde3D.ResourceTypes.Pipeline:
					return new PipelineResource(resHandle);
				case Horde3D.ResourceTypes.SceneGraph:
					return new SceneGraphResource(resHandle);
				case Horde3D.ResourceTypes.Shader:
					return new ShaderResource(resHandle);
				case Horde3D.ResourceTypes.Texture:
					return new TextureResource(resHandle);
			}
		}
	}
}
