using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;

namespace Infrastructure.CodeGenerator.Logic.TypeConversions
{
	/// <summary>
	/// The given type can be converted to a .NET enum.
	/// </summary>
	public class ToEnumConversion : InlineConversion
	{
		public override TypeConversion Copy
		{
			get
			{
				return new ToEnumConversion { CSharpType = CSharpType };
			}
		}

		public override CodeParameterDeclarationExpression GenerateCSharpMethodParameter(string name)
		{
			return new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(System.Int32)), name);
		}

		public override CodeExpression GenerateCSharpInvokeEventParameter(string name)
		{
			var enumReference = new CodeTypeReference("Enum");
			enumReference.TypeArguments.Add(new CodeTypeReference(CSharpType));
			return new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(enumReference), "Cast"),
				new CodeArgumentReferenceExpression(name));
		}

		public override string GenerateCppCSharpMethodCallParameter(string name)
		{
			if (CSharpType != typeof(void))
				return "(int)" + name;
			return null;
		}

		public override string ToString()
		{
			return "Convert to Enumeration";
		}
	}
}
