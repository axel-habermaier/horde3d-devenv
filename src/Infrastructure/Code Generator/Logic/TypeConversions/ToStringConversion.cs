using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.CodeGenerator.Logic.TypeConversions
{
	/// <summary>
	/// The given type is accepted by the System.String constructor.
	/// </summary>
	public class ToStringConversion : InlineConversion
	{
		public override TypeConversion Copy
		{
			get
			{
				return new ToStringConversion { CSharpType = CSharpType };
			}
		}

		public override string GenerateCppCSharpMethodCallParameter(string name)
		{
			if (CSharpType != typeof(void))
				return "gcnew System::String(" + name + ")";
			return null;
		}

		public override string ToString()
		{
			return "Convert to String";
		}
	}
}
