using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CodeAFriend.DataModel.Constants;
using System.Linq;

namespace CodeAFriend.DataModel
{
	/// <summary>A script that ran and successfully passed all test cases for a <see cref="Problem"/>.</summary>
	public class ProblemSolution : Script
	{
		/// <summary>User who submitted this <see cref="ProblemSolution"/>.</summary>
		public User Submitter { get; private set; }

		/// <summary>All votes submitted for this solution.</summary>
		public IEnumerable<Vote> Votes => _votes?.ToList();

		private HashSet<Vote> _votes;

		/// <summary>Parameterless Constructor required for EF.</summary>
		protected ProblemSolution() { }

		/// <summary>Constructor for creating new <see cref="ProblemSolution"/>.</summary>
		public ProblemSolution(User submitter, Script script) : base(script.Name, script.Body, script.Language)
		{
			Submitter = submitter;
			_votes = new HashSet<Vote>();
		}

	}
}
