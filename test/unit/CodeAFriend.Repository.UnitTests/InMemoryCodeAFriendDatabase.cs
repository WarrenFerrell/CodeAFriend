using CodeAFriend.DataModel;
using CodeAFriend.DataModel.Constants;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeAFriend.Repository.UnitTests
{
	public class InMemoryCodeAFriendDatabase : IDisposable
	{
		SqliteConnection Connection { get; } = new SqliteConnection("DataSource=:memory:");
		DbContextOptions<CodeAFriendContext> Options { get; }

		ConcurrentBag<CodeAFriendContext> _contexts = new ConcurrentBag<CodeAFriendContext>();

		public InMemoryCodeAFriendDatabase(bool ensureSchema = true)
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

		public async Task CreateUser(string userName)
		{
			using (var context = NewContext())
			{
				context.Add(new User(userName));
				await context.SaveChangesAsync();
			}
		}

		public async Task CreateScriptForUser(string userName, string scriptName, string scriptBody, SupportedLanguage language)
		{
			var newScript = new User.AddScriptCommand(userName, scriptName, scriptBody, language);
			using (var context = NewContext())
			{
				var user = await context.Users.FindAsync(userName);
				await user.AddAsync(newScript, context);
			}
		}

		public async Task CreateProblemForUser(string username, string problemName, string problemDescription)
		{
			using (var context = NewContext())
			{
				var user = await context.Users.FindAsync(username);
				var newProblem = new User.AddProblemCommand(username, problemName, problemDescription);
				await user.AddAsync(newProblem, context);
			}
		}

		public async Task CreateTestCaseForProblem(string problemName, uint problemNumber, string testCaseInput, string testCaseOutput)
		{
			using (var context = NewContext())
			{
				var problem = await context.Problems.FindAsync(problemName);
				var newTestCase = new TestCase(problemNumber, testCaseInput, testCaseOutput);
				problem.Add(newTestCase, context);
				await context.SaveChangesAsync();
			}
		}

		public void Dispose()
		{
			Connection.Close();
		}
	}
}
