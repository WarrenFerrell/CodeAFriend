using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeAFriend.DataModel;
using CodeAFriend.DataModel.Constants;
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
		/// <param name="command">Operation to perform</param>
		/// <returns><see cref="Script"/>.</returns>
		[HttpPut]
		public async Task<IActionResult> UpdateUserScript(User.UpdateScriptCommand command)
		{
			var result = await Facade.ExecuteCommandAsync(command);
			return Ok(result);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command">Operation to perform</param>
		/// <returns></returns>
		[HttpDelete]
		public async Task<IActionResult> DeleteScript(User.DeleteScriptCommand command)
		{
			var result = await Facade.ExecuteCommandAsync(command);
			return NoContent();
		}

		/// <summary>
		/// Execute a script and see its outputs for a set of specified inputs.
		/// </summary>
		/// <param name="scriptId">Id of the script to use for execution.</param>
		/// <param name="inputs">set of inputs to run the script with.</param>
		/// <returns><see cref="IEnumerable{ScriptEvaluation}"/></returns>
		[HttpPost]
		public async Task<IActionResult> ExecuteScript(Guid scriptId, [FromBody] string[] inputs)
		{
			var result = await Facade.ExecuteScriptAsync(scriptId, new DefaultExecutionParameters(), inputs);
			return Ok(result);
		}

		/// <inheritdoc />
		public ScriptsController(ICodeAFriendFacade facade) : base(facade)
		{
		}
	}
}
