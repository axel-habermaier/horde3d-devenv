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
	public class CodeGenerator
	{
		public CodeGenerationSettings CurrentSettings { get; private set; }

		public CodeGenerator(CodeGenerationSettings settings)
		{
			CurrentSettings = settings;
		}

		public void GenerateCode()
		{
			GenerateCSharpCode();
			GenerateCppCode();
		}

		private void GenerateCppCode()
		{
			var cppGenerators = new List<CppFunctionCodeGenerator>();
			CurrentSettings.Functions.Foreach(f => cppGenerators.Add(new CppFunctionCodeGenerator(f)));

			var functionPointerMembers = GenerateCodeForeachFunction(cppGenerators, 
				(g, b) => b.Append("\t\t").AppendLine(g.GenerateFunctionPointerMember()));

			var functionPointerTypeDefs = GenerateCodeForeachFunction(cppGenerators, 
				(g, b) => b.Append("\t").AppendLine(g.GenerateFunctionPointerTypeDef()));

			var functionPointerInitialization = GenerateCodeForeachFunction(cppGenerators,
				(g, b) => b.Append("\t\t\t").AppendLine(g.GenerateFunctionPointerInitialization().Replace(Environment.NewLine, Environment.NewLine + "\t\t\t")).AppendLine());

			var noProfilingProxyFunctions = GenerateCodeForeachFunction(cppGenerators, 
				(g, b) => b.Append("\t\t").AppendLine(g.GenerateNoProfilingProxyFunction().Replace(Environment.NewLine, Environment.NewLine + "\t\t")));

			var profilingProxyFunctions = GenerateCodeForeachFunction(cppGenerators,
				(g, b) => b.Append("\t\t").AppendLine(g.GenerateProfilingProxyFunction().Replace(Environment.NewLine, Environment.NewLine + "\t\t")));

			var proxyFunctions = GenerateCodeForeachFunction(cppGenerators,
				(g, b) => b.Append("\t").AppendLine(g.GenerateProxyFunction().Replace(Environment.NewLine, Environment.NewLine + "\t")));

			var virtualProxyFunctions = GenerateCodeForeachFunction(cppGenerators,
				(g, b) => b.Append("\t\t").AppendLine(g.GenerateVirtualProxyFunction().Replace(Environment.NewLine, Environment.NewLine + "\t\t")));

			var code = Properties.Resources.Horde3DProxies;
			code = code.Replace("{funcPtrDefs}", functionPointerMembers);
			code = code.Replace("{noProfilingFuncProxies}", noProfilingProxyFunctions);
			code = code.Replace("{profilingFuncProxies}", profilingProxyFunctions);
			code = code.Replace("{funcProxies}", proxyFunctions);
			code = code.Replace("{virtualFuncProxies}", virtualProxyFunctions);
			code = code.Replace("{funcPtrTypeDefs}", functionPointerTypeDefs);
			code = code.Replace("{h3dVersion}", CurrentSettings.Horde3DVersion);
			code = code.Replace("{funcPtrInit}", functionPointerInitialization);
			code = code.Replace("{genTime}", DateTime.Now.ToString());
			code = code.Replace("{headerFile}", CurrentSettings.Horde3DHeaderFileContent);
		
			using (var writer = new StreamWriter(new FileStream(CurrentSettings.GeneratedCppCodeFilePath,
				FileMode.Create, FileAccess.Write)))
				writer.Write(code);
		}

		/// <summary>
		/// Iterates over each function and calls the given method.
		/// </summary>
		/// <param name="codeGenerators">The function code generators.</param>
		/// <param name="func">Calls the method for each function code generator.</param>
		/// <returns>Returns the generated code.</returns>
		private string GenerateCodeForeachFunction(List<CppFunctionCodeGenerator> codeGenerators, Action<CppFunctionCodeGenerator, StringBuilder> func)
		{
			var builder = new StringBuilder();
			codeGenerators.Foreach(f => func(f, builder));
			return builder.ToString();
		}

		private void GenerateCSharpCode()
		{
			// Generate the C# class.
			var codeClass = new CodeTypeDeclaration("Horde3DCall");
			codeClass.IsClass = true;
			codeClass.TypeAttributes = TypeAttributes.Public;

			var versionProperty = new CodeMemberProperty();
			versionProperty.Name = "Horde3DVersion";
			versionProperty.Type = new CodeTypeReference(typeof(string));
			versionProperty.Attributes = MemberAttributes.Static | MemberAttributes.Public;
			versionProperty.HasGet = true;
			versionProperty.HasSet = false;
			versionProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodePrimitiveExpression(CurrentSettings.Horde3DVersion)));
			codeClass.Members.Add(versionProperty);

			// Add the C# code for each Horde3D function.
			CurrentSettings.Functions.Foreach(f => codeClass.Members.AddRange(new CSharpFunctionCodeGenerator(f).ClassMembers));
			
			// Generate the namespace and add the class.
			var codeNamespace = new CodeNamespace("Infrastructure.Core.Server");
			codeNamespace.Types.Add(codeClass);
			codeNamespace.Imports.Add(new CodeNamespaceImport("System"));	

			// Generate the code.
			var compileUnit = new CodeCompileUnit();
			compileUnit.Namespaces.Add(codeNamespace);

			var provider = CodeDomProvider.CreateProvider("CSharp");
			var options = new CodeGeneratorOptions();
			options.BracingStyle = "C";

			using (var writer = new StreamWriter(new FileStream(CurrentSettings.GeneratedCSharpCodeFilePath, 
				FileMode.Create, FileAccess.Write)))
				provider.GenerateCodeFromCompileUnit(compileUnit, writer, options);

			// For whatever reason the C# code generation ignores the static flag on events and classes.
			// Therefore, "public event" will be replaced with "public static event" and
			// "public class" will be replaced with "public static class" manually.
			var code = String.Empty;
			using (var reader = new StreamReader(new FileStream(CurrentSettings.GeneratedCSharpCodeFilePath,
				FileMode.Open, FileAccess.Read)))
				code = reader.ReadToEnd();

			code = code.Replace("public event", "public static event");
			code = code.Replace("public class", "public static partial class");

			using (var writer = new StreamWriter(new FileStream(CurrentSettings.GeneratedCSharpCodeFilePath,
				FileMode.Create, FileAccess.Write)))
				writer.Write(code);
		}
	}
}
