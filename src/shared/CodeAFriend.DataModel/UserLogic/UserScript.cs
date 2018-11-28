using System;
using CodeAFriend.DataModel.Constants;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// A <see cref="Script"/> that belongs to a specific user.
	/// </summary>
	public class UserScript : Script
	{
		/// <summary>Parameterless Constructor required for EF.</summary>
		protected UserScript() { }

		/// <summary>Constructor for creating new <see cref="UserScript"/>.</summary>
		public UserScript(string name, string body, SupportedLanguage language) : base(name, body, language)
		{
		}

		/// <summary>Properties someone can specify on script creation.</summary>
		public class CreateCommand
		{
			/// <summary>All properties constructor.</summary>
			public CreateCommand(string name, string body, SupportedLanguage language)
			{
				Name = name;
				Body = body;
				Language = language;
			}

			/// <summary>Name to be used to create the script.</summary>
			public string Name { get; set; }

			/// <summary>Body of the new script.</summary>
			public string Body { get; set; }

			/// <summary>Language of the new script.</summary>
			public SupportedLanguage Language { get; set; }
		}
	}
}
