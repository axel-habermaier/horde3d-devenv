using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.CodeGenerator.Logic.TypeConversions
{
	/// <summary>
	/// A special type of code conversion that is only a single expression and
	/// can therefore be done inline. It is derived from InlineConversion, however,
	/// because the code generation code takes different code paths depending on
	/// whether the conversion can be performed inline. Unfortunately, .NET doesn't 
	/// support multiple inheritance.
	/// </summary>
	public class InlineCodeConversion : InlineConversion
	{
		/// <summary>
		/// Gets or sets the conversion code.
		/// </summary>
		public string Code { get; set; }

		public InlineCodeConversion()
		{
			Code = String.Empty;
		}

		public override TypeConversion Copy 
		{
			get
			{
				return new InlineCodeConversion { CSharpType = CSharpType, Code = Code };
			}
		}

		public override string GenerateCppCSharpMethodCallParameter(string name)
		{
			if (CSharpType != typeof(void))
				return Code.Replace("{paramName}", name);
			return null;
		}

		public override string ToString()
		{
			return "Single Line Custom Code";
		}
	}
}
