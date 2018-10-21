using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// 
	/// </summary>
	public class Script
	{
		/// <summary>
		/// 
		/// </summary>
		public string Body { get; }

		/// <summary>
		/// 
		/// </summary>
		public ILanguageStrategy Language { get; }

		/// <summary>
		/// 
		/// </summary>
		public Guid id { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <returns>Script</returns>
		public Script Clone()
		{
			throw new Exception("The method or operation is not implemented.");
		}

	}
}
