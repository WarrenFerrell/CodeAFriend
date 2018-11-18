using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CodeAFriend.DataModel
{
	/// <summary>A script that ran and successfully passed all test cases for a <see cref="Problem"/>.</summary>
	public class ProblemSolution : Script
	{
		/// <summary>User who submitted this <see cref="ProblemSolution"/>.</summary>
		public User Submitter { get; private set; }

		/// <summary>All votes submitted for this solution.</summary>
		public IEnumerable<Vote> Votes => _votes?.ToList();

		// Field Collections for EF (Cannot be readonly)
		private HashSet<Vote> _votes;

		/// <summary>Parameterless Constructor required for EF.</summary>
		protected ProblemSolution() { }

		/// <summary>Constructor for creating new <see cref="ProblemSolution"/>.</summary>
		public ProblemSolution(User submitter, Script script) : base(script.Name, script.Body, script.Language)
		{
			Submitter = submitter;
			_votes = new HashSet<Vote>();
		}

		/// <summary>
		/// Add a <see cref="Vote"/> to this <see cref="ProblemSolution"/>.
		/// </summary>
		/// <param name="vote"><see cref="Vote"/> to add.</param>
		/// <param name="context">Database to save the updated state to. (When SaveChanges is called).</param>
		public void Add(Vote vote, DbContext context = null)
		{
			this.Add(_votes, vote, context);
		}
	}
}
