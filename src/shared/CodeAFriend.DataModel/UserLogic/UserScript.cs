using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// <see cref="Script"/>s that have been written by a specific user.
	/// </summary>
	public class UserScript : Script
	{
		/// <summary>
		/// All properties constructor
		/// </summary>
		/// <param name="scriptName"></param>
		/// <param name="username"></param>
		/// <param name="body"></param>
		/// <param name="language"></param>
		/// <param name="id"></param>
		public UserScript(string scriptName, string username, string body, ILanguageInterpreter language, Guid id) : base(body, language, id)
		{
			ScriptName = scriptName;
			Username = username;
		}

		/// <summary>
		/// Name the user assigned to the <see cref="Script"/>.
		/// </summary>
		public virtual string ScriptName { get; }

		/// <summary>
		/// <see cref="User.Username"/> that created this <see cref="Script"/>.
		/// </summary>
		public virtual string Username { get; }

	}
}
