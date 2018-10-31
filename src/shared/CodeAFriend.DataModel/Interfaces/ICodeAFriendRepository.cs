using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
/// <summary>
/// 
/// </summary>
public interface ICodeAFriendRepository
{
		/// <summary>
		/// 
		/// </summary>
		IEnumerable<Problem> Problems { get; }

		/// <summary>
		/// 
		/// </summary>
		IEnumerable<ILanguageInterpreter> Languages { get; }

		/// <summary>
		/// 
		/// </summary>
		IEnumerable<User> Users { get; }

		/// <summary>
		/// 
		/// </summary>
		IEnumerable<Script> Scripts { get; }
	}
}
