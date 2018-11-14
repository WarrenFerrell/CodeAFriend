using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{

	public class ProblemSolution : Script
	{
		public ProblemSolution(IEnumerable<Vote> votes, User submitter, string body, ILanguageInterpreter language, Guid id) : base(body, language, id)
		{
			Votes = votes;
			Submitter = submitter;
		}

		public IEnumerable<Vote> Votes { get; }

		public User Submitter { get; }

	}
}
