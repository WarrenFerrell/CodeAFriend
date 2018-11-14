using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CodeAFriend.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace CodeAFriend.ApiService.Controllers
{
	/// <summary>
	/// Set of Api methods for manipulating CodAFriend objects.
	/// </summary>
	public abstract class CodaAFriendController : ControllerBase
	{

		/// <summary>
		/// <see cref="ICodeAFriendRepository"/> where all CodAFriend objects are stored.
		/// </summary>
		public ICodeAFriendRepository Repository { get; }

	}
}
