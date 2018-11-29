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
		/// <summary>Properties someone can specify on script creation.</summary>
		public class AddScriptCommand : ForUserCommand<Script>
		{
			/// <inheritdoc />
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

		/// <inheritdoc />
		public class UpdateScriptCommand : AddScriptCommand
		{
			/// <inheritdoc />
			public UpdateScriptCommand(Guid scriptId, string username, string name, string body, SupportedLanguage language) : base(username, name, body, language)
			{
				ScriptId = scriptId;
			}

			/// <summary>Id of the <see cref="Script"/> to operate on.</summary>
			public Guid ScriptId { get; set; }

			/// <inheritdoc />
			public override async Task<Script> ExecuteAsync(DbContext context)
			{
				var result = await context.UpdateAsync(new UserScript(ScriptId, Name, Body, Language));
				return result;
			}
		}

		/// <inheritdoc />
		public class DeleteScriptCommand : ForUserCommand<DeleteResult<UserScript>>
		{
			/// <inheritdoc />
			public DeleteScriptCommand(Guid scriptId, string username) : base(username)
			{
				ScriptId = scriptId;
			}

			/// <summary>Id of the <see cref="Script"/> to operate on.</summary>
			public Guid ScriptId { get; set; }

			/// <inheritdoc />
			public override async Task<DeleteResult<UserScript>> ExecuteAsync(DbContext context)
			{
				context.Remove(new UserScript(ScriptId));
				await context.SaveChangesAsync();
				return new DeleteResult<UserScript>();
			}
		}
	}
}
