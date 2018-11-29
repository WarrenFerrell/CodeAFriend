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
