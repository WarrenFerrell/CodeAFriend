using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAFriend.DataModel.Constants
{
	/// <summary>
	/// Default execution parameters for any script running in an environment that does not specify the running parameters.
	/// </summary>
	/// <remarks>Will be deprecated in the future in favor of a method that pulls these values from a config file.</remarks>
	public class DefaultExecutionParameters : ExecutionParameters
	{
		/// <summary>
		/// Default maximum cpu time.
		/// </summary>
		public const double MAX_CPU_TIME = 5000;
		/// <summary>
		/// Default maximum memory usage.
		/// </summary>
		public const int MAX_MEMORY = 5000;

		/// <inheritdoc />
		public DefaultExecutionParameters() :
			base(maxCpuTime: MAX_CPU_TIME, maxMemory: MAX_MEMORY, input: null)
		{ }

		/// <inheritdoc />
		public DefaultExecutionParameters(string input) :
			base(maxCpuTime: MAX_CPU_TIME, maxMemory: MAX_MEMORY, input: input)
		{ }
	}
}
