using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Resources
{
	/// <summary>
	/// The type of a shader.
	/// </summary>
	public enum ShaderType
	{
		/// <summary>
		/// The type is unknown.
		/// </summary>
		Unknown,
		/// <summary>
		/// A vertex shader.
		/// </summary>
		VertexShader,
		/// <summary>
		/// A geometry shader.
		/// </summary>
		GeometryShader,
		/// <summary>
		/// A fragment shader.
		/// </summary>
		FragmentShader
	}
}
