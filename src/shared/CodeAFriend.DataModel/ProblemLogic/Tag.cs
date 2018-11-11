using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// Tag used to search for a <see cref="Problem"/>.
	/// </summary>
	public class Tag
	{
		/// <summary>
		/// Problem this <see cref="Tag"/> is for.
		/// </summary>
		public Problem Problem { get; }

		/// <summary>
		/// Text of this tag.
		/// </summary>
		public string Text { get; } 

	}
}
