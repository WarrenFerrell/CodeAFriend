using CodeAFriend.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAFriend.Languages.Core
{

	public class InterpreterFactory
	{

		IEnumerable<ILanguageInterpreter> Languages { get; }

	}
}
