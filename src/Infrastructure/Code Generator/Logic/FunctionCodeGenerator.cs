using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.CodeGenerator.Logic.TypeConversions;
using System.CodeDom;

namespace Infrastructure.CodeGenerator.Logic
{
	public abstract class FunctionCodeGenerator
	{
		/// <summary>
		/// The Horde3D function for which the code is generated.
		/// </summary>
		protected Function function;

		/// <summary>
		/// Initializes a new FunctionCodeGenerator object.
		/// </summary>
		/// <param name="function">The Horde3D function for which the code is generated.</param>
		public FunctionCodeGenerator(Function function)
		{
			this.function = function;
		}

		/// <summary>
		/// Gets the function's name with the first letter capitalized.
		/// </summary>
		protected string CapitalizedFunctionName
		{
			get { return function.Name[0].ToString().ToUpper() + function.Name.Substring(1); }
		}

		/// <summary>
		/// Generates the parameters list.
		/// </summary>
		/// <typeparam name="T">The parameter's type.</typeparam>
		/// <param name="func">The function that is called on each TypeConversion object.</param>
		/// <returns>Returns the generated parameters.</returns>
		protected T[] GenerateParameters<T>(Func<TypeConversion, string, T> func)
		{
			var parameters = new List<T>();

			var returnParameter = func(function.ReturnType.TypeConversion, "returnValue");
			if (returnParameter != null)
				parameters.Add(returnParameter);

			function.Parameters.Foreach(p =>
			{
				var parameter = func(p.Type.TypeConversion, p.Name);
				if (parameter != null)
					parameters.Add(parameter);
			});

			return parameters.ToArray();
		}
	}
}
