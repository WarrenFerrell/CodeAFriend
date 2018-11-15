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
		/// This user's unique name.
		/// </summary>
		public virtual string Username { get; private set; }

		/// <summary>
		/// <see cref="Script"/>s that this user has written.
		/// </summary>
		public virtual ICollection<Script> Scripts => _scripts;

		protected HashSet<Script> _scripts;

		private User() { }

		public User(string username)
		{
			if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
			Username = username;
			_scripts = new HashSet<Script>();
		}

		public virtual void AddScript(Script script)
		{
			if (_scripts != null)
			{
				_scripts.Add(script);
			}
		}
	}
}
