using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace Infrastructure.CodeGenerator.Logic
{
	public class Horde3DHeaderFileParser
	{
		/// <summary>
		/// Path to the Horde3D Header file.
		/// </summary>
		string filePath;

		/// <summary>
		/// The header file's content.
		/// </summary>
		public string HeaderFileContent { get; private set; }

		private Regex findFunctionRegex;
		private Regex functionRegex;
		private Regex whiteSpaceRegex = new Regex(@"\s+");

		/// <summary>
		/// A regular expression string that extracts the entire function body of a function. This makes parsing
		/// function definitions spanning multiple lines easier.
		/// </summary>
		static readonly string regexPatternFunction = @"(?<function>(DLL(\t| )+(|[a-z]|[A-Z]|[0-9]|\*|,|\(|\)|:|_|\s)*\);))";
		/// <summary>
		/// A regular expression string that extracts the return type of a function. If the return type is a pointer a whitespace
		/// is expected between the return type's * and the function name (e.g. void * getNode()).
		/// </summary>
		static readonly string regexPatternReturnType = @"(?<returnType>((\w|::)+(\s+\w+)?(\s?\*)?))\s";
		/// <summary>
		/// A regular expression string that extracts the name of a function.
		/// </summary>
		static readonly string regexPatternFunctionName = @"(?<functionName>(\w+))";
		/// <summary>
		/// A regular expression string that extracts the parameter list of a function.
		/// </summary>
		static readonly string regexPatternFunctionParameters = @"\((?<parameters>(.*))\);";

		public Horde3DHeaderFileParser(string filePath)
		{
			this.filePath = filePath;
			findFunctionRegex = new Regex(regexPatternFunction, RegexOptions.Compiled | RegexOptions.Multiline);
			functionRegex = new Regex(regexPatternReturnType + regexPatternFunctionName + regexPatternFunctionParameters,
			   RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
		}

		/// <summary>
		/// Parses the functions in the header file.
		/// </summary>
		public List<Function> Parse()
		{
			var functions = new List<Function>();

			if (!File.Exists(filePath))
				throw new ArgumentException("Unable to open the Horde3D C++ Header File. Please check the path you entered.");

			using (var reader = new StreamReader(filePath))
				HeaderFileContent = reader.ReadToEnd();

			var functionMatch = findFunctionRegex.Match(HeaderFileContent);

			// We get the entire function first before parsing its return type, name and parameters. This makes handling
			// function definitions spanning multiple lines easier.
			while (functionMatch.Success)
			{
				var function = ParseFunction(functionMatch.Groups["function"].Value);
				if (function != null)
					functions.Add(function);
				functionMatch = functionMatch.NextMatch();
			}

			return functions;
		}

		/// <summary>
		/// Extracts the return type, name and parameters from the given function definition string.
		/// </summary>
		/// <param name="functionString">The function definition that should be parsed.</param>
		/// <returns>Returns the created Function object.</returns>
		private Function ParseFunction(string functionString)
		{
			functionString = functionString.Substring(4).Replace('\t', ' ').Replace("*", "* ");
			var match = functionRegex.Match(functionString);

			if (match.Success)
			{
				var functionName = match.Groups["functionName"].Value;
				var returnType = match.Groups["returnType"].Value;

				var parameters = match.Groups["parameters"].Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
				var functionParameters = new List<Parameter>();
				int position = 0;
				foreach (var p in parameters)
				{
					var trimmedP = p.Trim();
					var index = trimmedP.LastIndexOf(" ");
					var parameter = new Parameter { Name = trimmedP.Substring(index).Trim(), Type = new Type { CppType = trimmedP.Substring(0, index).Trim().Replace(" *", "*") }, Position = position++ };
					functionParameters.Add(parameter);
				}

				var cppDefinition = functionString.Replace(Environment.NewLine, " ").Replace("\t", "");
				cppDefinition = whiteSpaceRegex.Replace(cppDefinition, " ");
				cppDefinition = cppDefinition.Replace(" * ", "* ");
				cppDefinition = cppDefinition.Replace("( ", "(");
				cppDefinition = cppDefinition.Replace(" )", ")");
				cppDefinition = cppDefinition.Substring(0, cppDefinition.Length - 1);

				var function = new Function { Name = functionName, ReturnType = new Type { CppType = returnType.Replace(" *", "*") }, Parameters = functionParameters, CppDefinition = cppDefinition };
				function.GuessTypeConversions();
				return function;
			}
			else
				MessageBox.Show("Could not parse function definition: " + functionString, "Error");

			return null;
		}
	}
}
