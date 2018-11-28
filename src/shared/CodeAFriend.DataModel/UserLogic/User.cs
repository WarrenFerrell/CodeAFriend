using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAFriend.DataModel
{
	/// <summary>User in the CodeAFriend system.</summary>
	public partial class User
	{
		/// <summary>This user's unique name.</summary>
		public string Name { get; private set; }

		/// <summary><see cref="UserScript"/>s that this user has written.</summary>
		public IEnumerable<UserScript> Scripts => _scripts?.ToList();

		/// <summary><see cref="Problem"/>s that this user has written.</summary>
		public IEnumerable<Problem> Problems => _problems?.ToList();

		// Field Collections for EF (Cannot be readonly)
		private HashSet<UserScript> _scripts;
		private HashSet<Problem> _problems;

		/// <summary>Parameterless Constructor required for EF.</summary>
		private User() { }

		/// <summary>Constructor for creating new <see cref="User"/>.</summary>
		public User(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
			Name = name;
			_scripts = new HashSet<UserScript>();
			_problems = new HashSet<Problem>();
		}

		/// <summary>
		/// Add a <see cref="UserScript"/> to this <see cref="User"/>.
		/// </summary>
		/// <param name="script"><see cref="UserScript"/> to add.</param>
		/// <param name="context">Database to save the updated state to. (When SaveChanges is called).</param>
		public async Task<UserScript> AddAsync(UserScript.CreateCommand script, DbContext context = null)
		{
			var entity = new UserScript(script.Name, script.Body, script.Language);
			this.Add(_scripts, entity, context);
			if (context != null) await context.SaveChangesAsync();
			return entity;
		}


		/// <summary>
		/// Add a <see cref="Problem"/> to this <see cref="User"/>.
		/// </summary>
		/// <param name="problem"><see cref="Problem"/> to add.</param>
		/// <param name="context">Database to save the updated state to. (When SaveChanges is called).</param>
		public async Task<Problem> AddAsync(Problem.CreateCommand problem, DbContext context = null)
		{
			var entity = new Problem(problem.Name, problem.Description, this);
			this.Add(_problems, entity, context);
			if (context != null) await context.SaveChangesAsync();
			return entity;
		}
	}
}
