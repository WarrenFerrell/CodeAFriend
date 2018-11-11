using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// A single test case to see if a specific <see cref="Script"/> is a <see cref="ProblemSolution"/>.
	/// </summary>
	public class TestCase
	{
		/// <summary>
		/// Input for the test case.
		/// </summary>
		public string Input { get; }

		/// <summary>
		/// Expected output from the program during execution.
		/// </summary>
		public string ExpectedOutput { get; }

	}
}
