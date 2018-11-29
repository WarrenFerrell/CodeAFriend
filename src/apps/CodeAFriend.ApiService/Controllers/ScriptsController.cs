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
	[Route("[controller]")]
	public class ScriptsController : CodaAFriendController
	{

		/// <summary>
		/// Add a script for a particular user
		/// </summary>
		/// <returns><see cref="UserScript"/></returns>
		[HttpPost]
		public async Task<IActionResult> AddUserScript(User.AddScriptCommand command)
		{
			var result = await Facade.ExecuteCommandAsync(command);
			return CreatedAtRoute(nameof(GetScript), result.Id, result);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="scriptId"></param>
		/// <returns><see cref="Script"/></returns>
		[HttpGet("{scriptId:guid}")]
		public async Task<IActionResult> GetScript(Guid scriptId)
		{
			var result = await Facade.GetScriptAsync(scriptId);
			// todo: authorization logic.
			return Ok(result);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <returns>UserScript</returns>
		[HttpPut]
		public async Task<IActionResult> UpdateScript(Script script)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete]
		public async Task<IActionResult> DeleteScript(Guid id)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="scriptId"></param>
		/// <returns><see cref="ScriptEvaluation"/></returns>
		[HttpPost]
		public async Task<IActionResult> ExecuteScript(Guid scriptId, [FromBody] TestCase[] testCases)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <inheritdoc />
		public ScriptsController(ICodeAFriendFacade facade) : base(facade)
		{
		}
	}
}
