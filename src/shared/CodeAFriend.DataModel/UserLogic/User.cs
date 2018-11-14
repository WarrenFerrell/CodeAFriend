using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// User in the CodeAFriend system.
	/// </summary>
	public class User
	{
		/// <summary>
		/// <see cref="Script"/>s that this user has written.
		/// </summary>
		public virtual IEnumerable<UserScript> Scripts { get; }

		/// <summary>
		/// This user's unique name.
		/// </summary>
		public virtual string Username { get; }

	}
}
