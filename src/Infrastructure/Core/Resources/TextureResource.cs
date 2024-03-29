using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Horde3DNET;

namespace Infrastructure.Core.Resources
{
	/// <summary>
	/// Defines the type of a texture.
	/// </summary>
	[DataContract]
	public enum TextureType
	{
		/// <summary>
		/// A 2-dimensional texture.
		/// </summary>
		[EnumMember()]
		Texture2D,
		/// <summary>
		/// A texture cube.
		/// </summary>
		[EnumMember()]
		TextureCube
	}

	/// <summary>
	/// Defines the format of a texture.
	/// </summary>
	[DataContract]
	public enum TextureFormat
	{
		[EnumMember()]
		RGB8,
		[EnumMember()]
		BGR8,
		[EnumMember()]
		RGBX8,
		[EnumMember()]
		BGRX8,
		[EnumMember()]
		RGBA8,
		[EnumMember()]
		BGRA8,
		[EnumMember()]
		DXT1,
		[EnumMember()]
		DXT3,
		[EnumMember()]
		DXT5,
		[EnumMember()]
		RGBA16F,
		[EnumMember()]
		RGBA32F
	}

	[DataContract]
	public class TextureResource : Resource
	{
		/// <summary>
		/// Gets the texture's type.
		/// </summary>
		[DataMember]
		public TextureType Type { get; private set; }

		/// <summary>
		/// Gets the texture's width.
		/// </summary>
		[DataMember]
		public int Width { get; private set; }

		/// <summary>
		/// Gets the texture's height.
		/// </summary>
		[DataMember]
		public int Height { get; private set; }

		/// <summary>
		/// Gets the texture's format.
		/// </summary>
		[DataMember]
		public TextureFormat Format { get; private set; }

		internal TextureResource(int resHandle) 
			: base(resHandle)
		{

		}

		public override Horde3D.ResourceTypes ResourceType
		{
			get { return Horde3D.ResourceTypes.Texture; }
		}

		internal override void InitializeFromHorde3DState()
		{
			base.InitializeFromHorde3DState();

			Height = Horde3D.getResourceParami(ResHandle, (int)Horde3D.TextureResParams.Height);
			Width = Horde3D.getResourceParami(ResHandle, (int)Horde3D.TextureResParams.Width);
			Format = Enum<TextureFormat>.Cast(Horde3D.getResourceParami(ResHandle, (int)Horde3D.TextureResParams.TexFormat));
			Type = Horde3D.getResourceParami(ResHandle, (int)Horde3D.TextureResParams.TexType) == 0 ? TextureType.Texture2D : TextureType.TextureCube;
		}
	}
}
