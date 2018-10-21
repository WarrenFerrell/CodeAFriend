using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class Python : LanguageStrategy
{

	#region Aggregations


	#endregion

	#region Compositions


	#endregion

	#region Attributes

	/// <summary>
	/// 
	/// </summary>
	private IronPythonInterpreter Interpreter;



	#endregion


	#region undef members

	#endregion


	#region Public methods

	#endregion


	#region Protected methods

	#endregion


	#region Private methods

	#endregion


	#region LanguageStrategy members

	public override ScriptEvaluation Execute(string scriptBody, RuntimeParameters parameters)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	#endregion


}

