using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Resources
{
	/// <summary>
	/// The test function used by alpha and depth tests.
	/// </summary>
	public enum TestFunction
	{
		Always,
		Equal,
		Less,
		LessEqual,
		Greater,
		GreaterEqual
	}

	public static class TestFunctionStringConverter
	{
		public static string ConvertToString(TestFunction function)
		{
			switch (function)
			{
				default:
				case TestFunction.LessEqual:
					return "LESS_EQUAL";
				case TestFunction.Always:
					return "ALWAYS";
				case TestFunction.Equal:
					return "EQUAL";
				case TestFunction.Greater:
					return "GREATER";
				case TestFunction.GreaterEqual:
					return "GREATER_EQUAL";
				case TestFunction.Less:
					return "LESS";
			}
		}

		public static TestFunction ConvertToTestFunction(string function)
		{
			switch (function.ToUpper())
			{
				case "LESS_EQUAL":
				default:
					return TestFunction.LessEqual;
				case "ALWAYS":
					return TestFunction.Always;
				case "EQUAL":
					return TestFunction.Equal;
				case "GREATER":
					return TestFunction.Greater;
				case "GREATER_EQUAL":
					return TestFunction.GreaterEqual;
				case "LESS":
					return TestFunction.Less;
			}
		}
	}
}
