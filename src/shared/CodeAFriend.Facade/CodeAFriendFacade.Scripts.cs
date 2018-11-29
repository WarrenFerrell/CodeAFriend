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
		public async Task<ScriptEvaluation> ExecuteScript(Guid scriptId, ExecutionParameters parameters)
		{
			var script = await GetScriptAsync(scriptId);
			var interpreter = _interpreterFactory.GetInterpreter(script.Language);
			var result = await interpreter.ExecuteAsync(script.Body, parameters);
			return result;
		}
	}
}
