using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.CodeGenerator.Logic.TypeConversions
{
	/// <summary>
	/// The given type is a pointer that can be converted to .NET by simply
	/// dereferencing it.
	/// </summary>
	public class DereferencePointerConversion : InlineConversion
	{
		public override TypeConversion Copy
		{
			get
			{
				return new DereferencePointerConversion { CSharpType = CSharpType };
			}
		}

		public override string GenerateCppCSharpMethodCallParameter(string name)
		{
			if (CSharpType != typeof(void))
				return name + " == 0 ? " + (CSharpType.IsValueType ? "0" : "nullptr") + " : *" + name;
			return null;
		}

		public override string ToString()
		{
			return "Dereference Pointer";
		}
	}
}
