using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CodeAFriend.DataModel
{
	/// <summary>User in the CodeAFriend system.</summary>
	public partial class User
	{
		/// <summary>Properties someone can specify on user creation.</summary>
		public class CreateCommand
		{
			/// <summary>All properties constructor.</summary>
			public CreateCommand(string name)
			{
				Name = name;
			}


			/// <summary>Name to be used to create the user.</summary>
			public string Name { get; set; }
		}
	}
}
