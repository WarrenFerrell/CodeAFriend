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
		/// <summary>Create a user.</summary>
		Task<User> CreateUser(User.CreateCommand user);

		/// <summary>Get a user by their username.</summary>
		Task<User> GetUser(string username);

		/// <summary>Add script for a user.</summary>
		Task<Script> AddScriptForUser(string username, UserScript.CreateCommand script);

		/// <summary>Get a user script.</summary>
		Task<Script> GetScriptForUser(string username, Guid scriptId);

		/// <summary>Get a user script.</summary>
		Task<ScriptEvaluation> ExecuteScriptForUser(string username, Guid scriptId, RuntimeParameters parameters);


	}
}
