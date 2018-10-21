using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 
/// </summary>
public class Problem
{

	#region Aggregations
	#endregion

	#region Compositions
	#endregion

	#region Attributes

	/// <summary>
	/// 
	/// </summary>
	private string Description;


	/// <summary>
	/// 
	/// </summary>
	public IEnumerable<TestCase> TestCases { get; }


	/// <summary>
	/// 
	/// </summary>
	private string Name;


	/// <summary>
	/// 
	/// </summary>
	public IEnumerable<Solution> Solutions { get; }


	/// <summary>
	/// 
	/// </summary>
	public IEnumerable<string> Tags { get; }



	#endregion


	#region Public methods

	/// <summary>
	/// 
	/// </summary>
	/// <param name="script"></param>
	/// <returns>bool</returns>
	public bool TestScript(UserScript script)
	{
		throw new Exception("The method or operation is not implemented.");
	}

	#endregion


	#region Protected methods

	#endregion


	#region Private methods

	#endregion


}

