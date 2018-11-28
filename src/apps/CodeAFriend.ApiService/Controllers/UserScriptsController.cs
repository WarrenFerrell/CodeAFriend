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
	/// Apis that deal with a user's scripts
	/// </summary>
	[Route("api/User/{username}/Scripts")]
	public class UserScriptsController : CodaAFriendController
	{
		/// <inheritdoc />
		public UserScriptsController(ICodeAFriendFacade facade) : base(facade)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="username"></param>
		/// <param name="script"></param>
		/// <returns><see cref="UserScript"/></returns>
		[HttpPost]
		public async Task<IActionResult> AddNewScript(string username, UserScript.CreateCommand script)
		{
			var result = await Facade.AddScriptForUser(username, script);
			return CreatedAtRoute(nameof(GetScript), result.Id, result);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="username"></param>
		/// <param name="scriptId"></param>
		/// <returns><see cref="UserScript"/></returns>
		[HttpGet("{scriptId:guid}")]
		public async Task<IActionResult> GetScript(string username, Guid scriptId)
		{
			var result = await Facade.GetScriptForUser(username, scriptId);
			return Ok(result);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="scriptId"></param>
		/// <returns>Script</returns>
		[HttpGet]
		public async Task<IActionResult> ExecuteScript(string username, Guid scriptId, string input)
		{
			throw new Exception("The method or operation is not implemented.");
		}

	}
}
