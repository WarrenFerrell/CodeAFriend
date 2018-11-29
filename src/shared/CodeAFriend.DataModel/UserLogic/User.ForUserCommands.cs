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
		/// <inheritdoc />
		/// <summary>Command being performed on behalf of a specific user.</summary>
		public abstract class ForUserCommand<TResult> : ICommand<TResult>
		{
			/// <summary>Name of the user this operation is for.</summary>
			protected ForUserCommand(string username)
			{
				Username = username;
			}

			/// <summary>Name of the user this operation is for.</summary>
			public string Username { get; set; }

			/// <inheritdoc />
			public abstract Task<TResult> ExecuteAsync(DbContext context);
		}

		/// <summary>Properties someone can specify on script creation.</summary>
		public class AddScriptCommand : ForUserCommand<Script>
		{
			/// <summary>All properties constructor.</summary>
			public AddScriptCommand(string username, string name, string body, SupportedLanguage language) : base(username)
			{
				Name = name;
				Body = body;
				Language = language;
			}

			/// <summary>Name to be used to create the <see cref="Script"/>.</summary>
			public string Name { get; set; }

			/// <summary>Body of the new <see cref="Script"/>.</summary>
			public string Body { get; set; }

			/// <summary>Language of the new <see cref="Script"/>.</summary>
			public SupportedLanguage Language { get; set; }

			/// <inheritdoc />
			public override async Task<Script> ExecuteAsync(DbContext context)
			{
				var user = await context.FindAsync<User>(Username);
				var newScript = await user.AddAsync(this, context);
				return newScript;
			}
		}

		/// <summary>Properties someone can specify on <see cref="Problem"/> creation.</summary>
		public class AddProblemCommand : ForUserCommand<Problem>
		{
			/// <summary>All properties constructor.</summary>
			public AddProblemCommand(string username, string name, string description) : base(username)
			{
				Name = name;
				Description = description;
			}

			/// <summary>Unique name.</summary>
			public string Name { get; set; }

			/// <summary>Description of the <see cref="Problem"/>.</summary>
			public string Description { get; set; }

			/// <inheritdoc />
			public override async Task<Problem> ExecuteAsync(DbContext context)
			{
				var user = await context.FindAsync<User>(Username);
				var newScript = await user.AddAsync(this, context);
				return newScript;
			}
		}
	}
}
