using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.CodeGenerator.Logic.TypeConversions
{
	/// <summary>
	/// This abstract class provides an interface of type conversions that
	/// can happen inline, i.e. there are no temporary variables required for
	/// the conversion and it takes only one expression to convert the type.
	/// </summary>
	public abstract class InlineConversion : TypeConversion
	{
	}
}
