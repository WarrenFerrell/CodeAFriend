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
		public async Task<ScriptEvaluation> ExecuteScriptAsync(Guid scriptId, ExecutionParameters parameters)
		{
			var script = await GetScriptAsync(scriptId);
			var result = await ExecuteScriptAsync(script, parameters);
			return result;
		}

		/// <inheritdoc />
		public async Task<IEnumerable<ScriptEvaluation>> ExecuteScriptAsync(Guid scriptId, ExecutionParameters parameters, params string[] inputs)
		{
			var script = await GetScriptAsync(scriptId);
			var results = new List<ScriptEvaluation>(inputs.Length);
			foreach (var input in inputs) {
				parameters.Input = input;
				results.Add(await ExecuteScriptAsync(script, parameters));
			}
			return results;
		}

		private async Task<ScriptEvaluation> ExecuteScriptAsync(Script script, ExecutionParameters parameters)
		{
			var interpreter = _interpreterFactory.GetInterpreter(script.Language);
			var result = await interpreter.ExecuteAsync(script.Body, parameters);
			return result;
		} 
	}
}
