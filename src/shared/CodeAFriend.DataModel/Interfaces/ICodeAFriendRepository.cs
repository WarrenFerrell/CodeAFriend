using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CodeAFriend.DataModel
{
/// <summary>
/// Exposes stored user objects for the CodeAFriend website.
/// </summary>
public interface ICodeAFriendRepository
{
		/// <summary>
		/// Submitted <see cref="Problem"/>s.
		/// </summary>
		IEnumerable<Problem> Problems { get; }

		/// <summary>
		/// Submitted <see cref="User"/>s.
		/// </summary>
		IEnumerable<User> Users { get; }

		/// <summary>
		/// Submitted <see cref="Script"/>s.
		/// </summary>
		IEnumerable<Script> Scripts { get; }
	}
}
