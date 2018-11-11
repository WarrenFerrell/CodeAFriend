using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// A problem with a set of <see cref="TestCase"/>s to determine if a <see cref="Script"/> solves the <see cref="Problem"/>.
	/// </summary>
	public class Problem
	{
		/// <summary>
		/// Unique name of the Problem.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Description of this <see cref="Problem"/>.
		/// </summary>
		public string Description { get; }

		/// <summary>
		/// User who submitted this <see cref="Problem"/>.
		/// </summary>
		public User User { get; }

		/// <summary>
		/// <see cref="TestCase"/>s for this problem.
		/// </summary>
		public IEnumerable<TestCase> TestCases { get; }

		/// <summary>
		/// <see cref="Script"/>s that passed all <see cref="TestCases"/>.
		/// </summary>
		public IEnumerable<ProblemSolution> Solutions { get; }

		/// <summary>
		/// Optional tags to use to search for this problem.
		/// </summary>
		public IEnumerable<Tag> Tags { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns>bool</returns>
		public bool TestScript(UserScript script)
		{
			throw new Exception("The method or operation is not implemented.");
		}

	}
}
