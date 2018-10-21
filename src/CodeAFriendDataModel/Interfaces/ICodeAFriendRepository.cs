using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public interface ICodeAFriendRepository
{

	#region Aggregations

	/// <summary>
	/// 
	/// </summary>
	IEnumerable<Problem> Problems { get; }


	/// <summary>
	/// 
	/// </summary>
	IEnumerable<LanguageStrategy> Languages { get; }


	/// <summary>
	/// 
	/// </summary>
	IEnumerable<User> Users { get; }


	/// <summary>
	/// 
	/// </summary>
	IEnumerable<Script> Scripts { get; }

	#endregion

}
