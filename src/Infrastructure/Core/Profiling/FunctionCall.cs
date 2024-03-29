using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Infrastructure.Core.Misc
{
	[DataContract]
	public class FunctionCall
	{
		/// <summary>
		/// The name of the function that was called.
		/// </summary>
		[DataMember]
		public string FunctionName { get; private set; }

		/// <summary>
		/// The time (relative to the start time, in micro seconds) of the call.
		/// </summary>
		[DataMember]
		public long CallTime { get; private set; }

		/// <summary>
		/// The time (in micro seconds) it took to execute the function.
		/// </summary>
		[DataMember]
		public double ExecutionTime { get; private set; }

		/// <summary>
		/// The value that was returned by the function.
		/// </summary>
		[DataMember]
		public object ReturnValue { get; private set; }

		/// <summary>
		/// The parameters that were passed to the function.
		/// </summary>
		[DataMember]
		public object[] Parameters { get; private set; }

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		/// <param name="functionName">The name of the function that was called.</param>
		/// <param name="callTime">The time (relative to the start time, in seconds) of the call.</param>
		/// <param name="executionTime">The time (in seconds) it took to execute the function.</param>
		/// <param name="returnValue">The value that was returned by the function.</param>
		/// <param name="parameters">The parameters that were passed to the function.</param>
		public FunctionCall(string functionName, double callTime, double executionTime, object returnValue, object[] parameters)
		{
			FunctionName = functionName;
			CallTime = (long)(callTime * 1000000);
			ExecutionTime = Math.Round(executionTime * 1000000, 2);
			ReturnValue = returnValue;
			Parameters = parameters;
		}
	}
}
