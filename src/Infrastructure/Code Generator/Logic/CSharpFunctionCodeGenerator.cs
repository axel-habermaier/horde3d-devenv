using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using System.Diagnostics;
using Infrastructure.CodeGenerator.Logic.TypeConversions;
using System.CodeDom.Compiler;
using System.IO;

namespace Infrastructure.CodeGenerator.Logic
{
	class CSharpFunctionCodeGenerator : FunctionCodeGenerator
	{
		public CSharpFunctionCodeGenerator(Function function)
			: base(function)
		{
		}

		/// <summary>
		/// Generates the class members required for the function.
		/// </summary>
		/// <returns>Returns the generated members.</returns>
		public CodeTypeMember[] ClassMembers
		{
			get
			{
				var members = new List<CodeTypeMember>();
				members.Add(GenerateDelegate());
				members.Add(GenerateEvent());
				members.Add(GenerateMethod());
				return members.ToArray();
			}
		}

		#region Delegate and Event Code Generation
		/// <summary>
		/// Gets the delegate's name.
		/// </summary>
		private string DelegateName
		{
			get { return CapitalizedFunctionName + "Handler"; }
		}

		/// <summary>
		/// Generates the event.
		/// </summary>
		/// <returns>Returns the generated event.</returns>
		private CodeMemberEvent GenerateEvent()
		{
			var codeEvent = new CodeMemberEvent();
			codeEvent.Name = CapitalizedFunctionName;
			codeEvent.Type = new CodeTypeReference(DelegateName);
			// For whatever reason the C# code generation ignores the static flag.
			// Later, "public event" will be replaced with "public static event" manually.
			codeEvent.Attributes = MemberAttributes.Public | MemberAttributes.Static;

			return codeEvent;
		}

		/// <summary>
		/// Generates the event delegate.
		/// </summary>
		/// <returns>Returns the generated delegate.</returns>
		private CodeTypeDelegate GenerateDelegate()
		{
			var codeDelegate = new CodeTypeDelegate(DelegateName);
			codeDelegate.ReturnType = new CodeTypeReference(typeof(void));
			codeDelegate.Attributes = MemberAttributes.Public;

			codeDelegate.Parameters.AddRange(GenerateParameters((t, n) => t.GenerateCSharpDelegateParameter(n)));

			return codeDelegate;
		}
		#endregion

		#region Method Code Generation
		/// <summary>
		/// Generates the method.
		/// </summary>
		/// <returns>Returns the generated method.</returns>
		private CodeMemberMethod GenerateMethod()
		{
			var method = new CodeMemberMethod();
			method.Attributes = MemberAttributes.Public | MemberAttributes.Static;
			method.Name = "On" + CapitalizedFunctionName;
			method.ReturnType = new CodeTypeReference(typeof(void));

			method.Parameters.AddRange(GenerateParameters((t, n) => t.GenerateCSharpMethodParameter(n)));
			AddMethodBody(method);

			return method;
		}

		/// <summary>
		/// Adds the method body to the given method.
		/// </summary>
		/// <param name="method">The method to which the body should be added.</param>
		private void AddMethodBody(CodeMemberMethod method)
		{
			AddBeforeFunctionCalledEventInvocation(method);
			AddFunctionCalledEventInvocation(method);
			AddAfterFunctionCalledEventInvocation(method);
		}

		/// <summary>
		/// Adds the invocation code of the generic BeforeFunctionCalled event to the given method.
		/// </summary>
		/// <param name="method">The method to which the code should be added.</param>
		private void AddBeforeFunctionCalledEventInvocation(CodeMemberMethod method)
		{
			var conditionExpression = new CodeBinaryOperatorExpression(
				new CodeEventReferenceExpression(null, "BeforeFunctionCalled"),
				CodeBinaryOperatorType.IdentityInequality,
				new CodePrimitiveExpression(null));

			var invokeEventStatement = new CodeDelegateInvokeExpression();
			invokeEventStatement.TargetObject = new CodeEventReferenceExpression(null, "BeforeFunctionCalled");
			invokeEventStatement.Parameters.Add(new CodePrimitiveExpression(CapitalizedFunctionName));

			var conditionStatement = new CodeConditionStatement(conditionExpression,
				new CodeExpressionStatement(invokeEventStatement));

			method.Statements.Add(conditionStatement);
		}

		/// <summary>
		/// Adds the invocation code of the specific function called event to the given method.
		/// </summary>
		/// <param name="method">The method to which the code should be added.</param>
		private void AddFunctionCalledEventInvocation(CodeMemberMethod method)
		{
			var conditionExpression = new CodeBinaryOperatorExpression(
				new CodeEventReferenceExpression(null, CapitalizedFunctionName),
				CodeBinaryOperatorType.IdentityInequality,
				new CodePrimitiveExpression(null));

			var invokeEventStatement = new CodeDelegateInvokeExpression();
			invokeEventStatement.TargetObject = new CodeEventReferenceExpression(null, CapitalizedFunctionName);
			invokeEventStatement.Parameters.AddRange(GenerateParameters((t, n) => t.GenerateCSharpInvokeEventParameter(n)));

			var conditionStatement = new CodeConditionStatement(conditionExpression,
				new CodeExpressionStatement(invokeEventStatement));

			method.Statements.Add(conditionStatement);
		}

		/// <summary>
		/// Adds the invocation code of the generic AfterFunctionCalled event to the given method.
		/// </summary>
		/// <param name="method">The method to which the code should be added.</param>
		private void AddAfterFunctionCalledEventInvocation(CodeMemberMethod method)
		{
			var conditionExpression = new CodeBinaryOperatorExpression(
				new CodeEventReferenceExpression(null, "AfterFunctionCalled"),
				CodeBinaryOperatorType.IdentityInequality,
				new CodePrimitiveExpression(null));

			var invokeEventStatement = new CodeDelegateInvokeExpression();
			invokeEventStatement.TargetObject = new CodeEventReferenceExpression(null, "AfterFunctionCalled");
			invokeEventStatement.Parameters.Add(new CodePrimitiveExpression(CapitalizedFunctionName));

			var conditionStatement = new CodeConditionStatement(conditionExpression,
				new CodeExpressionStatement(invokeEventStatement));

			method.Statements.Add(conditionStatement);
		}
		#endregion

		/// <summary>
		/// Gets a preview of the generated code.
		/// </summary>
		public string CodePreview
		{
			get
			{
				var members = ClassMembers;
				var method = (from m in members
							  where m is CodeMemberMethod
							  select m).Single();

				var provider = CodeDomProvider.CreateProvider("CSharp");
				var options = new CodeGeneratorOptions();
				options.BracingStyle = "C";

				using (var memoryStream = new MemoryStream())
				using (TextWriter writer = new StreamWriter(memoryStream))
				{
					provider.GenerateCodeFromMember(method, writer, options);
					writer.Flush();
					var buffer = memoryStream.GetBuffer();
					return UTF8Encoding.UTF8.GetString(buffer);
				}
			}
		}
	}
}
