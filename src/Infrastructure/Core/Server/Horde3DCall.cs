using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.Misc;
using System.Collections.ObjectModel;

namespace Infrastructure.Core.Server
{
	public static partial class Horde3DCall
	{
		public delegate void FunctionCalledHandler(string eventName);

		public static event FunctionCalledHandler BeforeFunctionCalled;
		public static event FunctionCalledHandler AfterFunctionCalled;

		private static List<FunctionCall> functionCalls = new List<FunctionCall>();
		public static ReadOnlyCollection<FunctionCall> FunctionCalls
		{
			get { return functionCalls.AsReadOnly(); }
		}

		public static void ClearFunctionCalls()
		{
			functionCalls.Clear();
		}

		public static void RegisterFunctionCall(string functionName, double callTime, double executionTime, object returnValue, object[] parameters)
		{
			functionCalls.Add(new FunctionCall(functionName, callTime, executionTime, returnValue, parameters));
		}
	}
}
