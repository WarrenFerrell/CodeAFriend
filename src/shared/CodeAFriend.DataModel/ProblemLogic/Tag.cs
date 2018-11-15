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
		/// Text of this tag.
		/// </summary>
		public virtual string Text { get; private set; } 

		protected Tag() { }

		public Tag(string text)
		{
			Text = text;
		}

	}
}
