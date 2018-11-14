using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		public virtual string Name { get; }

		/// <summary>
		/// Description of this <see cref="Problem"/>.
		/// </summary>
		public virtual string Description { get; }

		/// <summary>
		/// User who submitted this <see cref="Problem"/>.
		/// </summary>
		public virtual User User { get; }

		/// <summary>
		/// <see cref="TestCase"/>s for this problem.
		/// </summary>
		public virtual IEnumerable<TestCase> TestCases { get; }

		/// <summary>
		/// <see cref="Script"/>s that passed all <see cref="TestCases"/>.
		/// </summary>
		public virtual IEnumerable<ProblemSolution> Solutions { get; }

		/// <summary>
		/// Optional tags to use to search for this problem.
		/// </summary>
		public virtual IEnumerable<Tag> Tags { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns>bool</returns>
		public async Task<bool> TestScript(UserScript script)
		{
			var parameters = new RuntimeParameters(script.Body, 2000, 200000, null);
			var results = new List<ScriptEvaluation>();
			bool pass = true;
			foreach (var testCase in TestCases)
			{
				parameters.Input = testCase.Input;
				var result = await script.Language.ExecuteAsync(parameters);
				results.Add(result);
				pass = pass && result.Output.Trim() == testCase.ExpectedOutput;
			}
			return pass;
		}

	}
}
