using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeAFriend.DataModel
{
	/// <summary>User in the CodeAFriend system.</summary>
	public partial class User
	{
		/// <summary>Properties someone can specify on <see cref="Problem"/> creation.</summary>
		public class AddProblemCommand : ForUserCommand<Problem>
		{
			/// <summary>All properties constructor.</summary>
			public AddProblemCommand(string username, string problemName, string description) : base(username)
			{
				ProblemName = problemName;
				Description = description;
			}

			/// <summary>Unique name.</summary>
			public string ProblemName { get; set; }

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

		/// <inheritdoc />
		public class UpdateProblemCommand : ForUserCommand<Problem>
		{
			/// <inheritdoc />
			public UpdateProblemCommand(string username, string problemName, string description) : base(username)
			{
				ProblemName = problemName;
				Description = description;
			}

			/// <summary>Unique name.</summary>
			public string ProblemName { get; set; }

			/// <summary>Description of the <see cref="Problem"/>.</summary>
			public string Description { get; set; }

			/// <inheritdoc />
			public override async Task<Problem> ExecuteAsync(DbContext context)
			{
				var result = await context.UpdateAsync(new Problem(ProblemName, Description), nameof(Problem.Description));
				return result;
			}
		}

		/// <inheritdoc />
		public class DeleteProblemCommand : ForUserCommand<DeleteResult<Problem>>
		{
			/// <inheritdoc />
			public DeleteProblemCommand(string problemName, string username) : base(username)
			{
				ProblemName = problemName;
			}

			/// <summary>Id of the <see cref="Problem"/> to operate on.</summary>
			public string ProblemName { get; set; }

			/// <inheritdoc />
			public override async Task<DeleteResult<Problem>> ExecuteAsync(DbContext context)
			{
				context.Remove(new Problem(ProblemName));
				await context.SaveChangesAsync();
				return new DeleteResult<Problem>();
			}
		}
	}
}
