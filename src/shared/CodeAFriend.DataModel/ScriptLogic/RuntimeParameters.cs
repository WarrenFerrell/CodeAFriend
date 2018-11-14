using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// Code to compile and and Parameters to use when executing code. 
	/// </summary>
	public class RuntimeParameters
	{
		public RuntimeParameters(string scriptBody, double maxCpuTime, long maxMemory, string input)
		{
			ScriptBody = scriptBody;
			MaxCpuTime = maxCpuTime;
			MaxMemory = maxMemory;
			Input = input;
		}

		/// <summary>
		/// Code to compile.
		/// </summary>
		public string ScriptBody { get; }

		/// <summary>
		/// Maximum amount of time in ms that the code should be allowed to execute.
		/// </summary>
		public double MaxCpuTime { get; }

		/// <summary>
		/// Maximum amount of memory that the code should be allowed to allocate during execution. 
		/// </summary>
		public long MaxMemory { get; }

		/// <summary>
		/// Input to provide to stdin during program execution. 
		/// </summary>
		public string Input { get; set; }

	}
}
