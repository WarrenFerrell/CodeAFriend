using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// 
	/// </summary>
	public class ProblemSolution : Script
	{
		/// <summary>
		/// 
		/// </summary>
		public IEnumerable<Vote> Votes { get; }

		/// <summary>
		/// 
		/// </summary>
		public User Submitter { get; }

	}
}
