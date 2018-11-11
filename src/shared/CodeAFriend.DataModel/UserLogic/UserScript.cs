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
		/// Name the user assigned to the <see cref="Script"/>.
		/// </summary>
		public string ScriptName { get; }

		/// <summary>
		/// <see cref="User.Username"/> that created this <see cref="Script"/>.
		/// </summary>
		public string Username { get; }

	}
}
