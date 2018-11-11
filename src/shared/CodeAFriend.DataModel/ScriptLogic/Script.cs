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
		/// <summary>
		/// Code.
		/// </summary>
		public string Body { get; }

		/// <summary>
		/// Language to compile code in.
		/// </summary>
		public ILanguageInterpreter Language { get; }

		/// <summary>
		/// Unique Id assigned to the Script during creation.
		/// </summary>
		public Guid Id { get; }

		/// <summary>
		/// Create a deep copy of this <see cref="Script"/>.
		/// </summary>
		/// <returns><see cref="Script"/> object that is a deep copy of this <see cref="Script"/>.</returns>
		public Script Clone()
		{
			throw new Exception("The method or operation is not implemented.");
		}

	}
}
