using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// 
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
		/// 
		/// </summary>
		public string Output { get; }

		/// <summary>
		/// 
		/// </summary>
		public double CpuTime { get; }

		/// <summary>
		/// 
		/// </summary>
		public long MemoryUsage { get; }

		/// <summary>
		/// 
		/// </summary>
		public RuntimeParameters Parameters { get; }
	}
}
