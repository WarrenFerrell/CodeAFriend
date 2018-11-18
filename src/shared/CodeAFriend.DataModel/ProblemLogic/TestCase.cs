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
		/// <summary>Order in which test case should be run.</summary>
		public int Number { get; private set; }

		/// <summary>Input for the test case.</summary>
		public string Input { get; private set; }

		/// <summary>Expected output from the program during execution.</summary>
		public string ExpectedOutput { get; private set; }

		/// <summary>Parameterless Constructor required for EF.</summary>
		private TestCase() { }

		/// <summary>Constructor for creating new test case.</summary>
		public TestCase(int number, string input, string expectedOutput)
		{
			Number = number;
			Input = input;
			ExpectedOutput = expectedOutput;
		}

	}
}
