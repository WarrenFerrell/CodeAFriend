using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// A piece of code to be compiled in a specified language.
	/// </summary>
	public class Script
	{
		public Script(string body, ILanguageInterpreter language, Guid id)
		{
			Body = body;
			Language = language;
			Id = id;
		}

		/// <summary>
		/// Code.
		/// </summary>
		public virtual string Body { get;  }

		/// <summary>
		/// Language to compile code in.
		/// </summary>
		public virtual ILanguageInterpreter Language { get; }

		/// <summary>
		/// Unique Id assigned to the Script during creation.
		/// </summary>
		public virtual Guid Id { get; }

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
