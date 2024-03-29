using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.CodeGenerator.Logic.TypeConversions;

namespace Infrastructure.CodeGenerator.Logic
{
	class ConversionRule
	{
		/// <summary>
		/// The C++ type this conversion rule applies to.
		/// </summary>
		public string CppType { get; set; }

		/// <summary>
		/// Indicates whether this conversion might be problematic.
		/// </summary>
		public bool Problematic { get; set; }

		/// <summary>
		/// Converts the given C++ type to a .NET type.
		/// </summary>
		public TypeConversion TypeConversion { get; set; }
	}
}
