using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CodeAFriend.DataModel;

namespace CodeAFriend.LanguageStrategy
{
	/// <summary>
	/// 
	/// </summary>
	public class Python : ILanguageStrategy
	{
		// Aggregations

		/// <summary>
		/// 
		/// </summary>
		private IronPythonInterpreter _interpreter;

		public Python(IronPythonInterpreter interpreter)
		{
			_interpreter = interpreter;
		}

		public string Name { get; } = nameof(Python);

		public ScriptEvaluation Execute(string scriptBody, RuntimeParameters parameters)
		{
			throw new Exception("The method or operation is not implemented.");
		}

	}
}
