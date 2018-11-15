using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// Results from executing a script using specified <see cref="RuntimeParameters"/>.
	/// </summary>
	public class ScriptEvaluation
	{
		public ScriptEvaluation(string output, double cpuTime, long memoryUsage, RuntimeParameters parameters)
		{
			Output = output;
			CpuTime = cpuTime;
			MemoryUsage = memoryUsage;
			Parameters = parameters;
		}

		/// <summary>
		/// Characters printed to stdout by the program during execution. 
		/// </summary>
		public string Output { get; set; }

		/// <summary>
		/// Amount of time that the program took to complete execution.
		/// </summary>
		public double CpuTime { get; set; }

		/// <summary>
		/// Peak memory usage, by the program, during execution.
		/// </summary>
		public long MemoryUsage { get; set; }

		/// <summary>
		/// Parameters used during program executions.
		/// </summary>
		public RuntimeParameters Parameters { get; set; }
	}
}
