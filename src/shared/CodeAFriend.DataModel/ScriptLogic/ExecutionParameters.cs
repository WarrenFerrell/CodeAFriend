using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// Parameters to use when executing code. 
	/// </summary>
	public class ExecutionParameters
	{
		/// <summary>
		/// Maximum amount of time in ms that the code should be allowed to execute.
		/// </summary>
		public double MaxCpuTime { get; set; }

		/// <summary>
		/// Maximum amount of memory that the code should be allowed to allocate during execution. 
		/// </summary>
		public long MaxMemory { get; set; }

		/// <summary>
		/// Input to provide to stdin during program execution. 
		/// </summary>
		public string Input { get; set; }

		/// <summary>
		/// All Properties constructor.
		/// </summary>
		public ExecutionParameters(double maxCpuTime, long maxMemory, string input)
		{
			MaxCpuTime = maxCpuTime;
			MaxMemory = maxMemory;
			Input = input;
		}

	}
}
