using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// Vote for the value for a specific <see cref="ProblemSolution"/>.
	/// </summary>
	public class Vote
	{
		/// <summary>
		/// Value of this vote.
		/// </summary>
		public virtual short Value { get; }

		/// <summary>
		/// <see cref="User"/> who submitted this vote.
		/// </summary>
		public virtual User Submitter { get; }

		/// <summary>
		/// Optional comment that the submitter included with his vote. 
		/// </summary>
		public virtual string Comment { get; }

	}
}
