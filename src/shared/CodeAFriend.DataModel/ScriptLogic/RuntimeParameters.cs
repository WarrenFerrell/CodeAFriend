using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// 
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
		/// 
		/// </summary>
		public string ScriptBody { get; }

		/// <summary>
		/// 
		/// </summary>
		public double MaxCpuTime { get; }

		/// <summary>
		/// 
		/// </summary>
		public long MaxMemory { get; }

		/// <summary>
		/// 
		/// </summary>
		public string Input { get; }

	}
}
