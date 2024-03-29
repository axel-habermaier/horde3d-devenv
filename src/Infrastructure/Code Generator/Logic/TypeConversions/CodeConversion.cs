using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;

namespace Infrastructure.CodeGenerator.Logic.TypeConversions
{
	/// <summary>
	/// The given type requires a custom conversion that the user has to provide.
	/// Basically there are no restrictions on what the conversion code can do.
	/// </summary>
	public class CodeConversion : TypeConversion
	{
		/// <summary>
		/// Gets or sets the conversion code.
		/// </summary>
		public string Code { get; set; }

		public CodeConversion()
		{
			Code = String.Empty;
		}

		public override TypeConversion Copy
		{
			get
			{
				return new CodeConversion { CSharpType = CSharpType, Code = Code };
			}
		}

		public override string GenerateCppCSharpMethodCallParameter(string name)
		{
			return "__" + name;
		}

		public string GenerateCode(string name)
		{
			var builder = new StringBuilder();
			builder.Append("// Converts the value of '").Append(name).Append("' and stores it in the .NET variable '__").Append(name).AppendLine("'.");

			if (String.IsNullOrEmpty(Code))
			{
				builder.Append(CSharpType.FullName.Replace(".", "::"));

				if (!CSharpType.IsValueType)
					builder.Append("^");

				builder.Append(" __").Append(name).Append(" = ");

				if (CSharpType.IsValueType)
					builder.Append("0");
				else
					builder.Append("nullptr");

				builder.AppendLine(";");
			}
			else
				builder.AppendLine(Code);

			builder.Append("// Done converting '").Append(name).Append("'.");
			return builder.ToString();
		}

		public override string GenerateToObjectConversion(string name)
		{
			return "(System::Object^)(__" + name + ")";
		}

		public override string ToString()
		{
			return "Custom Code";
		}
	}
}
