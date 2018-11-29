using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CodeAFriend.DataModel;
using CodeAFriend.Facade;
using Microsoft.AspNetCore.Mvc;

namespace CodeAFriend.ApiService.Controllers
{
	/// <summary>
	/// Set of Api methods for manipulating CodAFriend objects.
	/// </summary>
	public abstract class CodaAFriendController : ControllerBase
	{
		/// <summary>
		/// DI constructor.
		/// </summary>
		protected CodaAFriendController(ICodeAFriendFacade facade)
		{
			Facade = facade;
		}

		/// <summary>
		/// <see cref="ICodeAFriendFacade"/> where all CodAFriend objects are stored.
		/// </summary>
		protected ICodeAFriendFacade Facade;

	}
}
