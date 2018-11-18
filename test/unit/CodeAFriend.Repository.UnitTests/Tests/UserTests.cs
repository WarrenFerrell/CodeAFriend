using CodeAFriend.DataModel;
using CodeAFriend.DataModel.Constants;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CodeAFriend.Repository.UnitTests
{
	public class UserTests
	{
		public const string User1Name = nameof(User1Name);
		public const string Script1Name = nameof(Script1Name);
		public const string Script1Body = nameof(Script1Body);
		public const SupportedLanguage Script1Language = SupportedLanguage.Python37;

		[Fact]
		public async Task CreateUserCreatesIntendedUser()
		{
			using (var database = new InMemoryCodeAFriendDatabase())
			{
				// Create user
				await database.CreateUser(User1Name);

				// Use a separate instance of the context to verify correct data was saved to database
				using (var context = database.NewContext())
				{
					var user = await context.Users.FindAsync(User1Name);
					Assert.Equal(1, context.Users.Count());
					Assert.Equal(User1Name, user.Name);
				}
			}
		}

		[Fact]
		public async Task AddScriptAddsScriptToNewUser()
		{
			using (var database = new InMemoryCodeAFriendDatabase())
			{
				// Create user and script
 				await database.CreateUser(User1Name);
				await database.CreateScriptForUser(User1Name, Script1Name, Script1Body, Script1Language);

				// Use a separate instance of the context to verify correct data was saved to database
				using (var context = database.NewContext())
				{
					var user = await context.Users.Include(u => u.Scripts).SingleAsync(u => u.Name == User1Name);
					var script = Assert.Single(user.Scripts);
					Assert.Equal(Script1Name, script.Name);
					Assert.Equal(Script1Body, script.Body);
					Assert.Equal(Script1Language, script.Language);
				}
			}
		}
	}
}
