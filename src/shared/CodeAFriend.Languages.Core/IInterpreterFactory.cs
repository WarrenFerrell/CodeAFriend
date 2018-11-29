using System;
using System.Collections.Generic;
using System.Text;
using CodeAFriend.DataModel;
using CodeAFriend.DataModel.Constants;

namespace CodeAFriend.Languages.Core
{
	/// <summary>
	/// Factory to get the proper interpreter given a supplied language
	/// </summary>
	public interface IInterpreterFactory
	{
		/// <summary>
		/// Get an appropriate <see cref="ILanguageInterpreter"/>.
		/// </summary>
		/// <param name="language">Language to grab <see cref="ILanguageInterpreter"/> for.</param>
		/// <returns>Appropriate <see cref="ILanguageInterpreter"/>.</returns>
		ILanguageInterpreter GetInterpreter(SupportedLanguage language);
	}
}
