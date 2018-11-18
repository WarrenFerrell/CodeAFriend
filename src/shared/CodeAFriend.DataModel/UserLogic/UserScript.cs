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
	}
}
