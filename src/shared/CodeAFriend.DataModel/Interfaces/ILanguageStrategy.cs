using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILanguageStrategy
	{
		/// <summary>
		/// 
		/// </summary>
		string Name { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="scriptBody"></param>
		/// <param name="parameters"></param>
		/// <returns>ScriptEvaluation</returns>
		Task<ScriptEvaluation> ExecuteAsync(RuntimeParameters parameters);

	}
}
