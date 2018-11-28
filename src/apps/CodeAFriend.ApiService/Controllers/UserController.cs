using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeAFriend.DataModel;
using CodeAFriend.Facade;
using Microsoft.AspNetCore.Mvc;

namespace CodeAFriend.ApiService.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	public class UserController : CodaAFriendController
	{
		/// <inheritdoc />
		public UserController(ICodeAFriendFacade facade) : base(facade)
		{
		}


		/// <summary>
		/// Create a new user.
		/// </summary>
		/// <param name="user"></param>
		/// <returns>Created User and the uri where it now resides.</returns>
		[HttpPost]
		[Produces(typeof(User))]
		public async Task<IActionResult> CreateUser(User.CreateCommand user)
		{
			var result = await Facade.CreateUser(user);
			return CreatedAtRoute(nameof(GetUser), result.Name, result);
		}

		/// <summary>
		/// Get a user by username.
		/// </summary>
		/// <param name="username">user's username</param>
		/// <returns>User</returns>
		[HttpGet("{username}")]
		[Produces(typeof(User))]
		public async Task<IActionResult> GetUser(string username)
		{
			var result = await Facade.GetUser(username);
			return Ok(result);
		}

	}
}
