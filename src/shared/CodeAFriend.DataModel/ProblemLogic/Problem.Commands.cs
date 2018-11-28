using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeAFriend.DataModel.Constants;
using Microsoft.EntityFrameworkCore;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// A problem with a set of <see cref="TestCase"/>s to determine if a <see cref="Script"/> solves the <see cref="Problem"/>.
	/// </summary>
	public partial class Problem
	{
		/// <summary>Properties someone can specify on <see cref="Problem"/> creation.</summary>
		public class CreateCommand
		{
			/// <summary>All properties constructor.</summary>
			public CreateCommand(string name, string description)
			{
				Name = name;
				Description = description;
			}

			/// <summary>Unique name.</summary>
			public string Name { get; set; }

			/// <summary>Description of the <see cref="Problem"/>.</summary>
			public string Description { get; set; }
		}
	}
}
