using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Infrastructure.Core
{
	[DataContract]
	public struct Vector3
	{
		/// <summary>
		/// Gets or sets the x component.
		/// </summary>
		[DataMember]
		public float X { get; set; }

		/// <summary>
		/// Gets or sets the y component.
		/// </summary>
		[DataMember]
		public float Y { get; set; }

		/// <summary>
		/// Gets or sets the z component.
		/// </summary>
		[DataMember]
		public float Z { get; set; }

		private static Vector3 zero = new Vector3(0.0f, 0.0f, 0.0f);
		/// <summary>
		/// Gets the zero vector.
		/// </summary>
		public static Vector3 Zero
		{
			get { return zero; }
		}

		/// <summary>
		/// Initializes a new vector instance.
		/// </summary>
		/// <param name="x">The x component</param>
		/// <param name="y">The y component</param>
		/// <param name="z">The z component</param>
		public Vector3(float x, float y, float z)
			: this()
		{
			X = x;
			Y = y;
			Z = z;
		}

		public override string ToString()
		{
			var builder = new StringBuilder();
			builder.Append("(").Append(X).Append(", ").Append(Y).Append(", ").Append(Z).Append(")");
			return builder.ToString();
		}
	}
}
