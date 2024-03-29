using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.CodeGenerator.Logic.TypeConversions;
using System.Xml.Serialization;
using Horde3DNET;

namespace Infrastructure.CodeGenerator.Logic
{
	public class Type
	{
		/// <summary>
		/// The type's C++ string representation.
		/// </summary>
		public string CppType { get; set; }

		/// <summary>
		/// Indicates whether the automatic type conversion problem has been resolved.
		/// </summary>
		public bool ProblemIsResolved { get; set; }

		/// <summary>
		/// Indicates whether the automatic type conversion is problematic.
		/// </summary>
		public bool Problematic { get; set; }

		/// <summary>
		/// Indicates whether the type conversion has been modified by the user.
		/// </summary>
		public bool UserModified { get; set; }

		/// <summary>
		/// Gets or sets this type's type conversion object.
		/// </summary>
		public TypeConversion TypeConversion { get; set; }

		/// <summary>
		/// Does its best to guess the correct type conversion.
		/// </summary>
		public void GuessTypeConversion()
		{
			AutomaticTypeConverter.Instance.GetTypeConversion(this);
		}
	}
}
