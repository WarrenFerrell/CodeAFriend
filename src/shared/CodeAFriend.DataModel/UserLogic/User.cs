using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CodeAFriend.DataModel
{
	/// <summary>User in the CodeAFriend system.</summary>
	public class User
	{
		/// <summary>This user's unique name.</summary>
		public virtual string Name { get; private set; }

		/// <summary><see cref="UserScript"/>s that this user has written.</summary>
		public virtual IEnumerable<UserScript> Scripts => _scripts;

		protected HashSet<UserScript> _scripts;

		private User() { }

		public User(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
			Name = name;
			_scripts = new HashSet<UserScript>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <param name="context"></param>
		/// <remarks>some code from https://github.com/JonPSmith/EfCore.GenericBizRunner/blob/master/DataLayer/EfClasses/Book.cs </remarks>
		public void AddScript(UserScript script, DbContext context = null)
		{
			if (_scripts != null)
			{
				_scripts.Add(script);
			}
			else if (context == null)
			{
				throw new ArgumentNullException(nameof(context),
					"You must provide a context if the Scripts collection isn't valid.");
			}
			else if (context.Entry(this).IsKeySet)
			{
				context.Add(script);
			}
			else
			{
				throw new InvalidOperationException("Unable to save script for user.");
			}
		}
	}
}
