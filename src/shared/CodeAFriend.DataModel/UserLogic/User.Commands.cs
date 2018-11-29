using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CodeAFriend.DataModel.Constants;

namespace CodeAFriend.DataModel
{
	/// <summary>User in the CodeAFriend system.</summary>
	public partial class User
	{
		/// <summary>Properties someone can specify on user creation.</summary>
		public class CreateCommand : ICommand<User>
		{
			/// <summary>All properties constructor.</summary>
			public CreateCommand(string name)
			{
				Name = name;
			}

			/// <summary>Name to be used to create the user.</summary>
			public string Name { get; set; }

			/// <inheritdoc />
			public async Task<User> ExecuteAsync(DbContext context)
			{
				var value = new User(Name);
				var result = await context.AddAndReturnAsync(value);
				return result;
			}
		}

		/// <inheritdoc />
		/// <summary>Command being performed on behalf of a specific user.</summary>
		public abstract class ForUserCommand<TResult> : ICommand<TResult>
		{
			/// <summary>All properties constructor.</summary>
			protected ForUserCommand(string username)
			{
				Username = username;
			}

			/// <summary>Name of the user this operation is for.</summary>
			public string Username { get; set; }

			/// <inheritdoc />
			public abstract Task<TResult> ExecuteAsync(DbContext context);
		}
	}
}
