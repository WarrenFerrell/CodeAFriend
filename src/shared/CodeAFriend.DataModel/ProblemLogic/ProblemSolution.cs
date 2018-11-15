using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CodeAFriend.DataModel.Constants;
using System.Linq;

namespace CodeAFriend.DataModel
{

	public class ProblemSolution : Script
	{
		public User Submitter { get; private set; }

		public IEnumerable<Vote> Votes => _votes?.ToList();

		private HashSet<Vote> _votes;

		protected ProblemSolution() { }

		public ProblemSolution(User submitter, string body, SupportedLanguage language, Guid id) : base(body, language, id)
		{
			Submitter = submitter;
			_votes = new HashSet<Vote>();
		}

	}
}
