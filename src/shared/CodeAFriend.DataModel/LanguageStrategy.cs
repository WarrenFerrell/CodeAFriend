using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class LanguageStrategy
	{
		/// <summary>
		/// 
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="scriptBody"></param>
		/// <param name="parameters"></param>
		/// <returns>ScriptEvaluation</returns>
		abstract public ScriptEvaluation Execute(string scriptBody, RuntimeParameters parameters);

	}
}
