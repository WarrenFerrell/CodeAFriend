using System;
using System.Collections.Generic;
using System.Text;
using CodeAFriend.DataModel;

namespace CodeAFriend.Repository.DbEntity
{
	public class DbUser : DataModel.User
	{
		public DbUser(string username) : base(username)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <param name="context"></param>
		/// <remarks>some code from https://github.com/JonPSmith/EfCore.GenericBizRunner/blob/master/DataLayer/EfClasses/Book.cs</remarks>
		public void AddScript(Script script, CodeAFriendContext context = null)
		{
			//base.AddScript(script);
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
