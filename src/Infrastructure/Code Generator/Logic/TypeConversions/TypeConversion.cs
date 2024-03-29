using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Horde3DNET;
using System.CodeDom;

namespace Infrastructure.CodeGenerator.Logic.TypeConversions
{
	/// <summary>
	/// This abstract class provides an interface to generate the type conversion code
	/// of a given type.
	/// </summary>
	[XmlInclude(typeof(CodeConversion))]
	[XmlInclude(typeof(InlineCodeConversion))]
	[XmlInclude(typeof(DereferencePointerConversion))]
	[XmlInclude(typeof(DirectConversion))]
	[XmlInclude(typeof(ToEnumConversion))]
	[XmlInclude(typeof(ToStringConversion))]
	public abstract class TypeConversion
	{
		/// <summary>
		/// The C# type name.
		/// </summary>
		[XmlIgnore]
		public System.Type CSharpType { get; set; }

		public string XmlType
		{
			get { return CSharpType.AssemblyQualifiedName; }
			set { CSharpType = System.Type.GetType(value); }
		}

		public abstract TypeConversion Copy { get; }

		public override string ToString()
		{
			return this.GetType().Name;
		}

		public virtual CodeParameterDeclarationExpression GenerateCSharpMethodParameter(string name)
		{
			return GenerateCSharpDelegateParameter(name);
		}

		public virtual CodeParameterDeclarationExpression GenerateCSharpDelegateParameter(string name)
		{
			if (CSharpType == typeof(void))
				return null;

			return new CodeParameterDeclarationExpression(new CodeTypeReference(CSharpType), name);
		}

		public virtual CodeExpression GenerateCSharpInvokeEventParameter(string name)
		{
			if (CSharpType == typeof(void))
				return null;

			return new CodeArgumentReferenceExpression(name);
		}

		public abstract string GenerateCppCSharpMethodCallParameter(string name);

		public virtual string GenerateToObjectConversion(string name)
		{
			return "(System::Object^)(" + GenerateCppCSharpMethodCallParameter(name) + ")";
		}
	}
}
