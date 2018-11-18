using JetBrains.Annotations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CodeAFriend.DataModel;
using CodeAFriend.DataModel.Constants;

namespace CodeAFriend.Repository
{
	/// <inheritdoc/>
	/// <summary>EF Core object used to configure and access stored business objects in the CodeAFriend system.</summary>
	public class CodeAFriendContext : DbContext
	{
		/// <summary>Name that should be given to any column that refers back to a Problem.</summary>
		private const string ProblemName = nameof(Problem) + nameof(Problem.Name);

		/// <summary>Name that should be given to any column that refers back to a User.</summary>
		private const string UserName = nameof(User) + nameof(User.Name);

		/// <summary>Name that should be given to any column that refers back to a User.</summary>
		private const string ProblemSolutionId = nameof(ProblemSolution) + nameof(ProblemSolution.Id);

		/// <inheritdoc/>
		/// <summary></summary>
		public CodeAFriendContext(){ }

		/// <inheritdoc/>
		public CodeAFriendContext(DbContextOptions<CodeAFriendContext> options) : base(options)
		{
		}

		/// <summary>Table that holds Problems.</summary>
		public DbSet<Problem> Problems { get; set; }

		/// <summary>Table that holds Problem Solutions.</summary>
		public DbSet<ProblemSolution> ProblemSolutions { get; set; }

		/// <summary>Table that holds Problem Solutions.</summary>
		public DbSet<Vote> ProblemSolutionVotes { get; set; }

		/// <summary>Table that holds Problem TestCases.</summary>
		public DbSet<TestCase> ProblemTestCases { get; set; }

		/// <summary>Table that holds Problem Tags.</summary>
		public DbSet<Tag> ProblemTags { get; set; }

		/// <summary>Table that holds Users.</summary>
		public DbSet<User> Users { get; set; }

		/// <summary>Table that holds User Scripts.</summary>
		public DbSet<UserScript> UserScripts { get; set; }

		/// <inheritdoc/>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var connection = new SqliteConnection("DataSource=:memory:");
				optionsBuilder.UseSqlite(connection);
			}
		}

		/// <inheritdoc/>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Problem>(entity =>
			{
				entity.HasKey(e => e.Name);

				entity.HasOne(e => e.User)
					.WithMany(d => d.Problems)
					.OnDelete(DeleteBehavior.SetNull)
					;

				entity.OwnsMany<ProblemSolution>(e => e.Solutions)
					.HasForeignKey(ProblemName)
					.HasKey(ProblemName, nameof(ProblemSolution.Id));

				entity.Metadata.FindNavigation(nameof(Problem.Solutions))
					.SetPropertyAccessMode(PropertyAccessMode.Field);

				entity.OwnsMany<Tag>(e => e.Tags)
					.HasForeignKey(ProblemName)
					.HasKey(ProblemName, nameof(Tag.Text));

				entity.Metadata.FindNavigation(nameof(Problem.Tags))
					.SetPropertyAccessMode(PropertyAccessMode.Field);

				entity.OwnsMany<TestCase>(e => e.TestCases)
					.HasForeignKey(ProblemName)
					.HasKey(ProblemName, nameof(TestCase.Number));

				entity.Metadata.FindNavigation(nameof(Problem.TestCases))
					.SetPropertyAccessMode(PropertyAccessMode.Field);
			});


			modelBuilder.Entity<ProblemSolution>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasOne(e => e.Submitter)
					.WithMany()
					.OnDelete(DeleteBehavior.SetNull);

				entity.OwnsMany<Vote>(e => e.Votes)
					.HasForeignKey(ProblemSolutionId)
					.HasForeignKey(UserName)
					.HasKey(ProblemSolutionId, UserName);

				entity.Metadata.FindNavigation(nameof(ProblemSolution.Votes))
					.SetPropertyAccessMode(PropertyAccessMode.Field);
			});

			modelBuilder.Entity<User>(entity =>
			{
				entity.HasKey(e => e.Name);

				entity.OwnsMany<UserScript>(e => e.Scripts)
					.HasForeignKey(UserName)
					.HasKey(UserName, nameof(Script.Name));

				entity.Metadata.FindNavigation(nameof(User.Scripts))
					.SetPropertyAccessMode(PropertyAccessMode.Field);

				entity.Metadata.FindNavigation(nameof(User.Problems))
					.SetPropertyAccessMode(PropertyAccessMode.Field);
			});

			modelBuilder.Entity<UserScript>(entity =>
			{
				entity.HasKey(e => e.Id);
			});
		}
	}
}
