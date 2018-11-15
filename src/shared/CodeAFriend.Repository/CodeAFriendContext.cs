using JetBrains.Annotations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAFriend.Repository
{
	public class CodeAFriendContext : DbContext
	{
		public CodeAFriendContext() { }

		public CodeAFriendContext(DbContextOptions<CodeAFriendContext> options) : base(options)
		{
		}

		public DbSet<DataModel.Problem> Problems { get; set; }
		public DbSet<DataModel.ProblemSolution> ProblemSolutions { get; set; }
		public DbSet<DataModel.Script> Scripts { get; set; }
		public DbSet<DataModel.Tag> Tags { get; set; }
		public DbSet<DataModel.TestCase> TestCases { get; set; }
		public DbSet<DbEntity.DbUser> Users { get; set; }
		public DbSet<DataModel.Vote> Votes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var connection = new SqliteConnection("DataSource=:memory:");
				optionsBuilder.UseSqlite(connection);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DataModel.Problem>(entity =>
			{
				entity.HasKey(e => e.Name);

				entity.HasMany(e => e.Solutions)
					.WithOne();

				entity.Metadata.FindNavigation(nameof(DataModel.Problem.Solutions))
					.SetPropertyAccessMode(PropertyAccessMode.Field);

				entity.HasMany(e => e.Tags)
					.WithOne();

				entity.Metadata.FindNavigation(nameof(DataModel.Problem.Tags))
					.SetPropertyAccessMode(PropertyAccessMode.Field);

				entity.HasMany(e => e.TestCases)
					.WithOne();

				entity.Metadata.FindNavigation(nameof(DataModel.Problem.TestCases))
					.SetPropertyAccessMode(PropertyAccessMode.Field);
			});

			modelBuilder.Entity<DataModel.ProblemSolution>(entity =>
			{
				entity.HasMany(e => e.Votes)
					.WithOne();

				entity.Metadata.FindNavigation(nameof(DataModel.ProblemSolution.Votes))
					.SetPropertyAccessMode(PropertyAccessMode.Field);
			});

			modelBuilder.Entity<DataModel.Script>(entity =>
			{
				entity.HasKey(e => e.Id);
			});

			modelBuilder.Ignore<DataModel.Tag>();

			modelBuilder.Ignore<DataModel.TestCase>();

			modelBuilder.Entity<DataModel.User>(entity =>
			{
				entity.HasKey(e => e.Username);
			});
			modelBuilder.Entity<DbEntity.DbUser>(entity =>
			{
				entity.HasMany(e => e.Scripts)
					.WithOne();

				entity.Metadata.FindNavigation(nameof(DataModel.User.Scripts))
					.SetPropertyAccessMode(PropertyAccessMode.Field);
			});

			modelBuilder.Ignore<DataModel.Vote>();


		}
	}
}
