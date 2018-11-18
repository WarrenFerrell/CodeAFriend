using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// A problem with a set of <see cref="TestCase"/>s to determine if a <see cref="Script"/> solves the <see cref="Problem"/>.
	/// </summary>
	public class Problem
	{
		/// <summary>Unique name of the Problem.</summary>
		public virtual string Name { get; private set; }

		/// <summary>Description of this <see cref="Problem"/>.</summary>
		public virtual string Description { get; private set; }

		/// <summary>User who submitted this <see cref="Problem"/>.</summary>
		public virtual User User { get; private set; }

		/// <summary><see cref="TestCase"/>s for this problem.</summary>
		public virtual IEnumerable<TestCase> TestCases => _testCases?.ToList();

		/// <summary><see cref="Script"/>s that passed all <see cref="TestCases"/>.</summary>
		public virtual IEnumerable<ProblemSolution> Solutions => _solutions?.ToList();

		/// <summary>Optional tags to use to search for this problem.</summary>
		public virtual IEnumerable<Tag> Tags => _tags?.ToList();

		// Field Collections for EF (Cannot be readonly)
		private HashSet<TestCase> _testCases;
		private HashSet<ProblemSolution> _solutions;
		private HashSet<Tag> _tags;

		/// <summary>Parameterless Constructor required for EF.</summary>
		private Problem() { }

		/// <summary>Constructor for creating new <see cref="Problem"/>.</summary>
		public Problem(string name, string description, User user)
		{
			Name = name;
			Description = description;
			User = user;
			_testCases = new HashSet<TestCase>();
			_solutions = new HashSet<ProblemSolution>();
			_tags = new HashSet<Tag>();
		}

		/// <summary>
		/// Test if a script is a <see cref="ProblemSolution"/>.
		/// </summary>
		/// <param name="script"><see cref="Script"/> to run.</param>
		/// <param name="interpreter"></param>
		/// <returns>bool</returns>
		public async Task<bool> TestScript(Script script, ILanguageInterpreter interpreter)
		{
			var parameters = new RuntimeParameters(script.Body, 2000, 200000, null);
			var results = new List<ScriptEvaluation>();
			bool pass = true;
			foreach (var testCase in TestCases)
			{
				parameters.Input = testCase.Input;
				var result = await interpreter.ExecuteAsync(parameters);
				results.Add(result);
				pass = pass && result.Output.Trim() == testCase.ExpectedOutput;
			}
			return pass;
		}

		/// <summary>
		/// Add a <see cref="TestCase"/> to this <see cref="Problem"/>.
		/// </summary>
		/// <param name="testCase"><see cref="TestCase"/> to add.</param>
		/// <param name="context">Database to save the updated state to. (When SaveChanges is called).</param>
		public void Add(TestCase testCase, DbContext context = null)
		{
			this.Add(_testCases, testCase, context);
		}

		/// <summary>
		/// Add a <see cref="ProblemSolution"/> to this <see cref="Problem"/>.
		/// </summary>
		/// <param name="solution"><see cref="ProblemSolution"/> to add.</param>
		/// <param name="context">Database to save the updated state to. (When SaveChanges is called).</param>
		public void Add(ProblemSolution solution, DbContext context = null)
		{
			this.Add(_solutions, solution, context);
		}

		/// <summary>
		/// Add a <see cref="Tag"/> to this <see cref="Problem"/>.
		/// </summary>
		/// <param name="tag"><see cref="Tag"/> to add.</param>
		/// <param name="context">Database to save the updated state to. (When SaveChanges is called).</param>
		public void Add(Tag tag, DbContext context = null)
		{
			this.Add(_tags, tag, context);
		}
	}
}
