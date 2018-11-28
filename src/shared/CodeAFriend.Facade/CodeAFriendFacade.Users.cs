using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAFriend.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodeAFriend.Facade
{
	public partial class CodeAFriendFacade
	{
		/// <inheritdoc />
		public async Task<User> CreateUser(User.CreateCommand user)
		{
			return await CreateAsync(new User(user.Name));
		}

		/// <inheritdoc />
		public async Task<User> GetUser(string username)
		{
			return await _dbContext.FindAsync<User>(username);
		}

		/// <inheritdoc />
		public async Task<Script> AddScriptForUser(string username, UserScript.CreateCommand script)
		{
			var user = await _dbContext.FindAsync<User>(username);
			var newScript = await user.AddAsync(script, _dbContext);
			return newScript;
		}

		/// <inheritdoc />
		public async Task<Script> GetScriptForUser(string username, Guid scriptId)
		{
			return await _dbContext.FindAsync<UserScript>(scriptId);
		}

		/// <inheritdoc />
		public async Task<ScriptEvaluation> ExecuteScriptForUser(string username, Guid scriptId, RuntimeParameters parameters)
		{
			throw new NotImplementedException();
		}
	}
}
