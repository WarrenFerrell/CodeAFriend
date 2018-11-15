using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeAFriend.DataModel.Constants;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// Exposes the ability to compile and execute a specific language.
	/// </summary>
	public interface ILanguageInterpreter
	{
		/// <summary>
		/// The language this <see cref="ILanguageInterpreter"/> interprets.
		/// </summary>
		SupportedLanguage Name { get; }

		/// <summary>
		/// Execute code written in <see cref="Name"/> language using the specified <see cref="RuntimeParameters"/>. 
		/// </summary>
		/// <param name="parameters">The <see cref="RuntimeParameters"/> to use for code compilation and execution.</param>
		/// <returns>ScriptEvaluation</returns>
		Task<ScriptEvaluation> ExecuteAsync(RuntimeParameters parameters);

	}
}
