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
		public virtual string Input { get; private set; }

		/// <summary>
		/// Expected output from the program during execution.
		/// </summary>
		public virtual string ExpectedOutput { get; private set; }

		protected TestCase() { }

		public TestCase(string input, string expectedOutput)
		{
			Input = input;
			ExpectedOutput = expectedOutput;
		}

	}
}
