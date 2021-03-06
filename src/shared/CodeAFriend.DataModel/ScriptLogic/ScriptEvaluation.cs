using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// Results from executing a <see cref="Script"/> using specified <see cref="ExecutionParameters"/>.
	/// </summary>
	public class ScriptEvaluation
	{
		/// <summary>
		/// All Properties constructor.
		/// </summary>
		public ScriptEvaluation(string output, double cpuTime, long memoryUsage)
		{
			Output = output;
			CpuTime = cpuTime;
			MemoryUsage = memoryUsage;
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
	}
}
