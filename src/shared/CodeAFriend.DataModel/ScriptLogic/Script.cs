using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CodeAFriend.DataModel.Constants;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// A piece of code to be compiled in a specified language.
	/// </summary>
	public class Script
	{
		/// <summary>Unique Id assigned to the Script during creation.</summary>
		public Guid Id { get; private set; }

		/// <summary>Name given to this script by the user who created it.</summary>
		public string Name { get; private set; }

		/// <summary>Code.</summary>
		public string Body { get; private set; }

		/// <summary>Language to compile code in.</summary>
		public SupportedLanguage Language { get; private set; }

		/// <summary>Parameterless Constructor required for EF.</summary>
		protected Script() { }

		/// <summary>Constructor for creating new <see cref="Script"/>.</summary>
		public Script(string name, string body, SupportedLanguage language)
		{
			Name = name;
			Body = body;
			Language = language;
			Id = Guid.NewGuid();
		}

		/// <summary>
		/// Create a deep copy of this <see cref="Script"/>. 
		/// </summary>
		/// <remarks>Employs the Prototype design pattern.</remarks>
		/// <returns><see cref="Script"/> object that is a deep copy of this <see cref="Script"/>.</returns>
		public Script Clone()
		{
			return new Script(Name, Body, Language);
		}

	}
}
