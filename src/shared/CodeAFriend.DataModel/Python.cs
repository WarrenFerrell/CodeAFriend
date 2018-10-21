using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// 
	/// </summary>
	public class Python : LanguageStrategy
	{

		#region Aggregations

		/// <summary>
		/// 
		/// </summary>
		public IronPythonInterpreter Interpreter { get; }

		#endregion


		public override ScriptEvaluation Execute(string scriptBody, RuntimeParameters parameters)
		{
			throw new Exception("The method or operation is not implemented.");
		}

	}
}
