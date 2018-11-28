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
	public class ScriptController : CodaAFriendController
	{

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



		/// <inheritdoc />
		public ScriptController(ICodeAFriendFacade facade) : base(facade)
		{
		}
	}
}
