using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CodeAFriend.DataModel;

namespace CodeAFriend.ApiService.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class CodaAFriendController
	{

		/// <summary>
		/// 
		/// </summary>
		public ICodeAFriendRepository Repository { get; }

	}
}
