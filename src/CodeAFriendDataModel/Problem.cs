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

	/// <summary>
	/// 
	/// </summary>
	public string Description { get; }

	/// <summary>
	/// 
	/// </summary>
	public IEnumerable<TestCase> TestCases { get; }

	/// <summary>
	/// 
	/// </summary>
	public string Name { get; }

	/// <summary>
	/// 
	/// </summary>
	public IEnumerable<Solution> Solutions { get; }

	/// <summary>
	/// 
	/// </summary>
	public IEnumerable<string> Tags { get; }

	/// <summary>
	/// 
	/// </summary>
	/// <param name="script"></param>
	/// <returns>bool</returns>
	public bool TestScript(UserScript script)
	{
		throw new Exception("The method or operation is not implemented.");
	}

}
