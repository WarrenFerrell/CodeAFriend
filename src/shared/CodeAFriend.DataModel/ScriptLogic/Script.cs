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
		/// <summary>
		/// Code.
		/// </summary>
		public virtual string Body { get; private set; }

		/// <summary>
		/// Language to compile code in.
		/// </summary>
		public virtual SupportedLanguage Language { get; private set; }

		/// <summary>
		/// Unique Id assigned to the Script during creation.
		/// </summary>
		public virtual Guid Id { get; private set; }

		protected Script() { }

		public Script(string body, SupportedLanguage language, Guid id)
		{
			Body = body;
			Language = language;
			Id = id;
		}

		/// <summary>
		/// Create a deep copy of this <see cref="Script"/>. 
		/// </summary>
		/// <remarks>Employs the Prototype design pattern.</remarks>
		/// <returns><see cref="Script"/> object that is a deep copy of this <see cref="Script"/>.</returns>
		public Script Clone()
		{
			return new Script(Body, Language, Id);
		}

	}
}
