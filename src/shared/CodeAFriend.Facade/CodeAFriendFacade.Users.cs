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
		public async Task<User> GetUser(string username)
		{
			return await _dbContext.FindAsync<User>(username);
		}

		

		/// <inheritdoc />
		public async Task<IEnumerable<Script>> GetScriptsForUser(string username)
		{
			var result = await _dbContext.Query<User>().Where(u => u.Name == username).Select(u => u.Scripts).SingleOrDefaultAsync();
			return result;
		}

		/// <inheritdoc />
		public async Task<Script> GetScriptAsync(Guid scriptId)
		{
			Script result = await _dbContext.FindAsync<UserScript>(scriptId) ?? 
			                (Script) await _dbContext.FindAsync<ProblemSolution>(scriptId);
			if (result == null) throw new Exception("");
			return result;
		}

		/// <inheritdoc />
		public async Task<ScriptEvaluation> ExecuteScript(string username, Guid scriptId, ExecutionParameters parameters)
		{
			throw new NotImplementedException();
		}
	}
}
