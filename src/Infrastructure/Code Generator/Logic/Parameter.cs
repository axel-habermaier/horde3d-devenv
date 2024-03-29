using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.CodeGenerator.Logic
{
	public class Parameter
	{
		/// <summary>
		/// The parameter's name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The parameter's position in the function's parameter list.
		/// </summary>
		public int Position { get; set; }

		/// <summary>
		/// The parameter's type.
		/// </summary>
		public Type Type { get; set; }

		/// <summary>
		/// Does its best to guess the correct type conversion.
		/// </summary>
		public void GuessTypeConversion()
		{
			Type.GuessTypeConversion();
		}

		/// <summary>
		/// Indicates whether the conversion is problematic and has not yet been marked as resolved.
		/// </summary>
		public bool Problematic
		{
			get { return Type.Problematic; }
		}

		/// <summary>
		/// Indicates whether the automatic type conversion problem has been resolved.
		/// </summary>
		public bool ProblemIsResolved 
		{
			get { return Type.ProblemIsResolved; }
		}
	}
}
