using CodeAFriend.DataModel;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CodeAFriend.Repository.UnitTests
{
	public class ProblemTests
	{
		public const string User1Name = nameof(User1Name);
		public const string Problem1Name = nameof(Problem1Name);
		public const string Problem1Description = nameof(Problem1Description);
		public const string TestCase1Input = nameof(TestCase1Input);
		public const string TestCase1Output = nameof(TestCase1Output);

		[Fact]
		public async Task AddProblemAddsSpecifiedProblem()
		{
			using (var database = new InMemoryCodeAFriendDatabase())
			{
				// CreateUser & Problem
				await database.CreateUser(User1Name);
				await database.CreateProblemForUser(User1Name, Problem1Name, Problem1Description);

				// Use a separate instance of the context to verify correct data was saved to database
				using (var context = database.NewContext())
				{
					var user = await context.Users.Include(u => u.Problems).SingleAsync(u => u.Name == User1Name);
					var problem = Assert.Single(user.Problems);
					Assert.Equal(Problem1Name, problem.Name);
					Assert.Equal(Problem1Description, problem.Description);
				}
			}
		}

		[Fact]
		public async Task AddTestCaseAddsTestCaseForProblem()
		{
			using (var database = new InMemoryCodeAFriendDatabase())
			{
				// Create user, problem, & testCase
				await database.CreateUser(User1Name);
				await database.CreateProblemForUser(User1Name, Problem1Name, Problem1Description);
				await database.CreateTestCaseForProblem(Problem1Name, 1, TestCase1Input, TestCase1Output);

				// Use a separate instance of the context to verify correct data was saved to database
				using (var context = database.NewContext())
				{
					var problem = await context.Problems.Include(p => p.TestCases).SingleAsync(u => u.Name == Problem1Name);
					var testCase = Assert.Single(problem.TestCases);
					Assert.Equal((uint) 1, testCase.Number);
					Assert.Equal(TestCase1Input, testCase.Input);
					Assert.Equal(TestCase1Output, testCase.ExpectedOutput);
				}
			}
		}

	}
}
