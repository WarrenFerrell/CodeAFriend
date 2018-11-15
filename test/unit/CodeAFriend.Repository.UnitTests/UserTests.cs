using CodeAFriend.Repository.DbEntity;
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
		public const string User1Id = "user1";

		[Fact]
		public async Task CreateUserCreatesIntendedUser()
		{
			using (var database = new InMemorySqlDatabase())
			{
				// Run the test against one instance of the context
				using (var context = database.NewContext())
				{
					context.Add(new DbUser(User1Id));
					await context.SaveChangesAsync();
				}

				// Use a separate instance of the context to verify correct data was saved to database
				using (var context = database.NewContext())
				{
					var user = await context.Users.FindAsync(User1Id);
					Assert.Equal(1, context.Users.Count());
					Assert.Equal(User1Id, user.Username);
				}
			}
		}

		[Fact]
		public async Task AddScriptAddsScriptToNewUser()
		{
			var scriptBody = @"print(""Hello World"")";
			using (var database = new InMemorySqlDatabase())
			{
				// CreateUser
				await database.CreateUser(User1Id);

				// Create Script for User1
				using (var context = database.NewContext())
				{
					var user = await context.Users.FindAsync(User1Id);
					user.AddScript(new DataModel.Script(scriptBody, DataModel.Constants.SupportedLanguage.Python37, Guid.NewGuid()));
					await context.SaveChangesAsync();
				}

				// Use a separate instance of the context to verify correct data was saved to database
				using (var context = database.NewContext())
				{
					var user = await context.Users.Include(u => u.Scripts).SingleAsync(u => u.Username == User1Id);
					Assert.Single(user.Scripts);
					Assert.Equal(scriptBody, user.Scripts.Single().Body);
				}
			}
		}

		private class InMemorySqlDatabase : IDisposable
		{
			SqliteConnection Connection { get; } = new SqliteConnection("DataSource=:memory:");
			DbContextOptions<CodeAFriendContext> Options { get; }

			ConcurrentBag<CodeAFriendContext> _contexts = new ConcurrentBag<CodeAFriendContext>();

			public InMemorySqlDatabase(bool ensureSchema = true)
			{
				Connection.Open();
				Options = new DbContextOptionsBuilder<CodeAFriendContext>().UseSqlite(Connection).Options;
				
				// Create the schema in the database
				if (ensureSchema)
				{
					using (var context = new CodeAFriendContext(Options))
					{
						context.Database.EnsureCreated();
					}
				}
			}

			public CodeAFriendContext NewContext()
			{
				var context = new CodeAFriendContext(Options);
				_contexts.Add(context);
				return context;
			}

			public async Task CreateUser(string userId)
			{
				using (var context = NewContext())
				{
					context.Add(new DbUser(userId));
					await context.SaveChangesAsync();
				}
			}

			public void Dispose()
			{
				Connection.Close();
			}
		}
	}
}
