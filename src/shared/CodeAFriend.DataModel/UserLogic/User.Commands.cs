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

		
	}
}
