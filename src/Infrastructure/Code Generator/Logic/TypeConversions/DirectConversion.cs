using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.CodeGenerator.Logic.TypeConversions
{
	/// <summary>
	/// The given type can be directly converted to .NET.
	/// </summary>
	public class DirectConversion : InlineConversion
	{
		public override TypeConversion Copy
		{
			get
			{
				return new DirectConversion { CSharpType = CSharpType };
			}
		}

		public override string GenerateCppCSharpMethodCallParameter(string name)
		{
			if (CSharpType != typeof(void))
				return name;
			return null;
		}

		public override string ToString()
		{
			return "None";
		}
	}
}
