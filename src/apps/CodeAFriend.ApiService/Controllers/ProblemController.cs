using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CodeAFriend.DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using CodeAFriend.Facade;

namespace CodeAFriend.ApiService.Controllers
{
	/// <summary>
	/// Api Methods dealing with <see cref="Problem"/>s.
	/// </summary>
	[Route("[controller]")]
	public class ProblemController : CodaAFriendController
	{
		/// <inheritdoc />
		public ProblemController(ICodeAFriendFacade facade) : base(facade)
		{
		}

		/// <summary>
		/// Create the specified <see cref="Problem"/>.
		/// </summary>
		/// <param name="command">Properties for the <see cref="Problem"/>.</param>
		/// <returns><see cref="HttpStatusCode.Created"/> and created <see cref="Problem"/>.</returns>
		[HttpPost]
		public async Task<IActionResult> AddProblemForUser(User.AddProblemCommand command)
		{
			var result = await Facade.ExecuteCommandAsync(command);
			return CreatedAtAction(nameof(GetProblem), result.Name, result);
		}

		/// <summary>
		/// Update the specified <see cref="Problem"/>.
		/// </summary>
		/// <param name="problemName">Name of problem to update.</param>
		/// <param name="problem">New Properties for problem.</param>
		/// <returns><see cref="HttpStatusCode.OK"/> and updated <see cref="Problem"/>.</returns>
		[HttpPut]
		public async Task<IActionResult> UpdateProblem(User.UpdateProblemCommand command)
		{
			var result = await Facade.ExecuteCommandAsync(command);
			return Ok(result);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="problemName">Name of problem to delete.</param>
		/// <returns>><see cref="HttpStatusCode.NoContent"/>.</returns>
		[HttpDelete]
		public async Task<IActionResult> DeleteProblem(User.DeleteProblemCommand command)
		{
			var result = await Facade.ExecuteCommandAsync(command);
			return NoContent();
		}

		/// <summary>
		/// Get a specified problem.
		/// </summary>
		/// <param name="problemName">Name of problem to retrieve.</param>
		/// <returns><see cref="HttpStatusCode.OK"/> and specified <see cref="Problem"/>.</returns>
		[HttpGet("{problemName}")]
		public async Task<IActionResult> GetProblem(string problemName)
		{
			var result = await Facade.GetProblem(problemName);
			return Ok(result);
		}

		/// <summary>
		/// Submit a <see cref="Script"/> to be considered a <see cref="ProblemSolution"/>.
		/// </summary>
		/// <param name="script"></param>
		/// <param name="problemName"></param>
		/// <returns>bool</returns>
		[HttpPost("{problemName}/TestScript/{scriptId:guid}")]
		public async Task<IActionResult> TestScript(string problemName, Guid scriptId)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vote"></param>
		/// <param name="solution"></param>
		/// <returns></returns>
		[HttpPost("{problemName}/vote")]
		public async Task<IActionResult> Vote(string problemName, Vote vote)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="problemName"></param>
		/// <returns>Solution[ * ]</returns>
		[HttpGet("{problemName}/solutions")]
		public IEnumerable<ProblemSolution> GetSolutions(string problemName)
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}
}
