using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using System.Reflection;
using System.CodeDom.Compiler;
using System.IO;

namespace Infrastructure.CodeGenerator.Logic
{
	public class Function
	{
		/// <summary>
		/// The function's name as it appears in the Horde3D header file.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The function's return type.
		/// </summary>
		public Type ReturnType { get; set; }

		/// <summary>
		/// The function's parameters.
		/// </summary>
		public List<Parameter> Parameters { get; set; }

		/// <summary>
		/// The function's C++ definition.
		/// </summary>
		public string CppDefinition { get; set; }

		/// <summary>
		/// Does its best to guess the correct type conversions for its return type and parameters.
		/// </summary>
		public void GuessTypeConversions()
		{
			ReturnType.GuessTypeConversion();
			Parameters.Foreach(p => p.GuessTypeConversion());
		}

		/// <summary>
		/// Indicates whether the return type or any of the parameters is a problematic conversion that has
		/// not yet been marked as resolved.
		/// </summary>
		public bool Problematic
		{
			get
			{
				bool returnValue = false;
				returnValue = returnValue || ReturnType.Problematic;

				Parameters.Foreach(p => returnValue = returnValue | p.Problematic);

				return returnValue;
			}
		}

		/// <summary>
		/// Indicates whether all conversion problems have been resolved.
		/// </summary>
		public bool AllProblemsResolved
		{
			get
			{
				bool returnValue = true;
				returnValue = returnValue && (!ReturnType.Problematic || (ReturnType.Problematic && ReturnType.ProblemIsResolved));

				Parameters.Foreach(p => returnValue = returnValue && (!p.Problematic || (p.Problematic && p.ProblemIsResolved)));

				return returnValue;
			}
		}

		/// <summary>
		/// Gets or sets the old function that represented the Horde3D function before the last update.
		/// </summary>
		public Function OldFunction { get; set; }
	}
}
