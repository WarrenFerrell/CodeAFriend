using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeAFriend.DataModel;
using Microsoft.EntityFrameworkCore;

namespace CodeAFriend.Facade
{
	/// <summary>
	/// Exposes stored user objects for the CodeAFriend website.
	/// </summary>
	/// <remarks>Makes use of the facade design pattern.</remarks>
	public interface ICodeAFriendFacade
	{
		/// <summary>Get a user by their username.</summary>
		Task<User> GetUser(string username);

		/// <summary>Get all scripts for a user.</summary>
		Task<IEnumerable<Script>> GetScriptsForUser(string username);

		/// <summary>Get a user script.</summary>
		Task<Script> GetScriptAsync(Guid scriptId);

		/// <summary>Execute a user <see cref="Script"/> with the specified parameters.</summary>
		Task<ScriptEvaluation> ExecuteScriptAsync(Guid scriptId, ExecutionParameters parameters);

		/// <summary>Execute a <see cref="Script"/> several times with a specified set of inputs.</summary>
		Task<IEnumerable<ScriptEvaluation>> ExecuteScriptAsync(Guid scriptId, ExecutionParameters parameters, params string[] inputs);

		/// <summary>Execute <see cref="ICommand{TReturn}"/>.</summary>
		Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);


	}
}
