using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using Infrastructure.CodeGenerator.Logic.TypeConversions;

namespace Infrastructure.CodeGenerator.Logic
{
	/// <summary>
	/// Generates a function's C++ code. Unfortunately, we can't use CodeDOM here, as the C++ Code Generator
	/// generates C++/CLI code only.
	/// </summary>
	class CppFunctionCodeGenerator : FunctionCodeGenerator
	{
		public CppFunctionCodeGenerator(Function function)
			: base(function)
		{

		}

		/// <summary>
		/// Gets the function's C++ definition with a capitalized function name.
		/// </summary>
		private string CapitalizedCppDefinition
		{
			get { return function.CppDefinition.Replace(function.Name, CapitalizedFunctionName); }
		}

		#region Function Pointer
		/// <summary>
		/// Generates the function pointer member.
		/// </summary>
		/// <returns>Returns the generated function pointer member.</returns>
		public string GenerateFunctionPointerMember()
		{
			return FunctionPointerTypeName + " " + FunctionPointerName + ";";
		}

		/// <summary>
		/// Generates the function pointer typedef.
		/// </summary>
		/// <returns>Returns the generated function pointer typedef.</returns>
		public string GenerateFunctionPointerTypeDef()
		{
			var builder = new StringBuilder();

			builder.Append("typedef ").Append(function.ReturnType.CppType).Append("(*").Append(FunctionPointerTypeName).Append(")(");

			function.Parameters.Foreach(p => builder.Append(p.Type.CppType).Append(" ").Append(p.Name).Append(", "));
			RemoveLastCommaSeparatorFromParameterList(builder);

			builder.Append(");");

			return builder.ToString();
		}

		/// <summary>
		/// Generates the function pointer initialization code.
		/// </summary>
		/// <returns>Returns the generated code.</returns>
		public string GenerateFunctionPointerInitialization()
		{
			var builder = new StringBuilder();

			builder.Append(FunctionPointerName).Append(" = (").Append(FunctionPointerTypeName).Append(")(GetProcAddress(dll, \"");
			builder.Append(function.Name).Append("\"));").AppendLine(); 
			
			builder.Append("if (").Append(FunctionPointerName).Append(" == 0)").AppendLine();
			builder.Append("\tthrow exception(\"Unable to find address of function '").Append(function.Name).Append("'.\");");

			return builder.ToString();
		}

		/// <summary>
		/// Gets the function pointer's type name.
		/// </summary>
		private string FunctionPointerTypeName
		{
			get { return "h3dPtr" + CapitalizedFunctionName; }
		}

		/// <summary>
		/// Gets the function pointer member name.
		/// </summary>
		private string FunctionPointerName
		{
			get { return "h3d" + CapitalizedFunctionName; }
		}
		#endregion

		#region Proxy Functions
		/// <summary>
		/// Generates the proxy function.
		/// </summary>
		/// <returns>Returns the generated function.</returns>
		public string GenerateProxyFunction()
		{
			var builder = new StringBuilder();
			builder.Append("DLL ").AppendLine(function.CppDefinition);
			builder.AppendLine("{").Append("\t");

			if (!ReturnsVoid)
				builder.Append("return ");

			builder.Append("g_proxyHandler.GetCurrentProxy()->").Append(CapitalizedFunctionName).Append("(");

			function.Parameters.Foreach(p => builder.Append(p.Name).Append(", "));
			RemoveLastCommaSeparatorFromParameterList(builder);

			builder.AppendLine(");");
			builder.AppendLine("}");

			return builder.ToString();
		}

		/// <summary>
		/// Generates the virtual proxy function.
		/// </summary>
		/// <returns>Returns the generated function.</returns>
		public string GenerateVirtualProxyFunction()
		{
			var builder = new StringBuilder();
			builder.Append("virtual ").Append(CapitalizedCppDefinition).AppendLine(" = 0;");

			return builder.ToString();
		}

		/// <summary>
		/// Generates the no profiling proxy function.
		/// </summary>
		/// <returns>Returns the generated function.</returns>
		public string GenerateNoProfilingProxyFunction()
		{
			var builder = new StringBuilder();
			builder.AppendLine(CapitalizedCppDefinition);
			builder.AppendLine("{").Append("\t");

			GenerateFunctionPointerCall(builder);
			builder.AppendLine();
			builder.Append("\t");

			GenerateCodeConversions(builder);

			builder.AppendLine();
			builder.Append("\t");
			GenerateCSharpMethodCall(builder);

			GenerateReturnStatement(builder);

			builder.AppendLine().AppendLine("}");

			return builder.ToString();
		}

		/// <summary>
		/// Generates the profiling proxy function.
		/// </summary>
		/// <returns>Returns the generated function.</returns>
		public string GenerateProfilingProxyFunction()
		{
			var builder = new StringBuilder();
			builder.AppendLine(CapitalizedCppDefinition);
			builder.AppendLine("{");

			builder.AppendLine("\tdouble callTime = (double)stopwatch->ElapsedTicks;");
			builder.Append("\t");

			GenerateFunctionPointerCall(builder);
			builder.AppendLine();

			builder.AppendLine("\tdouble endCallTime = (double)stopwatch->ElapsedTicks;");

			GenerateCodeConversions(builder);
			GenerateRegisterFunctionCallMethodCall(builder);

			builder.AppendLine();
			builder.Append("\t");
			GenerateCSharpMethodCall(builder);
			builder.AppendLine();
			GenerateReturnStatement(builder);

			builder.AppendLine().AppendLine("}");

			return builder.ToString();
		}

		/// <summary>
		/// Generates the code that calls the Horde3DCall::RegisterFunctionCall method.
		/// </summary>
		/// <param name="builder">The string builder to which to append the generated code.</param>
		private void GenerateRegisterFunctionCallMethodCall(StringBuilder builder)
		{
			builder.AppendLine().Append("\tSystem::Object^ result = ");

			if (ReturnsVoid)
				builder.AppendLine("nullptr;");
			else
				builder.Append(function.ReturnType.TypeConversion.GenerateToObjectConversion("returnValue")).AppendLine(";");

			builder.Append("\tarray<System::Object^>^ parameters = ");

			if (function.Parameters == null || function.Parameters.Count == 0)
				builder.AppendLine("nullptr;");
			else
			{
				builder.Append("gcnew array<System::Object^>(").Append(function.Parameters.Count).AppendLine(");").AppendLine();
				int count = 0;
				function.Parameters.Foreach(p =>
				{
					builder.Append("\tparameters[").Append(count++).Append("] = ");
					builder.Append(p.Type.TypeConversion.GenerateToObjectConversion(p.Name));
					builder.AppendLine(";");
				});
			}

			builder.AppendLine().Append("\tHorde3DCall::RegisterFunctionCall(\"").Append(function.Name);
			builder.Append("\", callTime / (double)stopwatch->Frequency, (endCallTime - callTime) / (double)stopwatch->Frequency, result, parameters);");
		}

		/// <summary>
		/// Generates the call to the function pointer.
		/// </summary>
		/// <param name="builder">The string builder to which to append the generated code.</param>
		private void GenerateFunctionPointerCall(StringBuilder builder)
		{
			if (!ReturnsVoid)
				builder.Append(function.ReturnType.CppType).Append(" returnValue = ");

			builder.Append(FunctionPointerName).Append("(");

			function.Parameters.Foreach(p => builder.Append(p.Name).Append(", "));
			RemoveLastCommaSeparatorFromParameterList(builder);

			builder.Append(");");
		}

		/// <summary>
		/// Generates the call to the Horde3DCall method.
		/// </summary>
		/// <param name="builder">The string builder to which to append the generated code.</param>
		private void GenerateCSharpMethodCall(StringBuilder builder)
		{
			builder.Append("Horde3DCall::On").Append(function.Name[0].ToString().ToUpper()).Append(function.Name.Substring(1)).Append("(");
			var parameters = GenerateParameters((t, n) => t.GenerateCppCSharpMethodCallParameter(n));

			parameters.Foreach(p => builder.Append(p).Append(", "));
			RemoveLastCommaSeparatorFromParameterList(builder, true);

			builder.Append(");");
		}

		/// <summary>
		/// Generate the proxy function's return statement.
		/// </summary>
		/// <param name="builder">The string builder to which to append the generated code.</param>
		private void GenerateReturnStatement(StringBuilder builder)
		{
			if (!ReturnsVoid)
				builder.AppendLine().Append("\treturn returnValue;");
		}

		/// <summary>
		/// Generates the custom code conversion code.
		/// </summary>
		/// <param name="builder">The string builder to which to append the generated code.</param>
		private void GenerateCodeConversions(StringBuilder builder)
		{
			var codeConversions = (from p in function.Parameters
								  where p.Type.TypeConversion is CodeConversion
								  select new { p.Name, CodeConversion = p.Type.TypeConversion as CodeConversion }).ToList();

			if (function.ReturnType.TypeConversion is CodeConversion)
				codeConversions.Insert(0, new { Name = "returnValue", CodeConversion = function.ReturnType.TypeConversion as CodeConversion });

			codeConversions.Foreach(c =>
			{
				builder.AppendLine().Append("\t");
				builder.Append(c.CodeConversion.GenerateCode(c.Name).Replace(Environment.NewLine, Environment.NewLine + "\t"));
				builder.AppendLine();
			});
		}
		#endregion

		#region Helper Methods
		/// <summary>
		/// Indicates whether the function returns void.
		/// </summary>
		private bool ReturnsVoid
		{
			get { return function.ReturnType.CppType == "void"; }
		}

		/// <summary>
		/// Removes the last comma separator from the parameter list. The builder's last two characters
		/// must be ", ".
		/// </summary>
		/// <param name="builder">The builder from which to remove the comma separator.</param>
		/// <param name="containsReturnType">Indicates whether the return type is also in the parameter list.</param>
		private void RemoveLastCommaSeparatorFromParameterList(StringBuilder builder, bool containsReturnType)
		{
			if ((function.Parameters != null && function.Parameters.Count > 0) || (containsReturnType && !ReturnsVoid))
				builder.Remove(builder.Length - 2, 2);
		}

		/// <summary>
		/// Removes the last comma separator from the parameter list (which does not contain the return type). 
		/// The builder's last two characters must be ", ".
		/// </summary>
		/// <param name="builder">The builder from which to remove the comma separator.</param>
		private void RemoveLastCommaSeparatorFromParameterList(StringBuilder builder)
		{
			RemoveLastCommaSeparatorFromParameterList(builder, false);
		}
		#endregion
	}
}
