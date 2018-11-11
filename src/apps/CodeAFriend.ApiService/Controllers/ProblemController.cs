using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CodeAFriend.DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CodeAFriend.ApiService.Controllers
{
	/// <summary>
	/// Api Methods dealing with <see cref="Problem"/>s.
	/// </summary>
	[Route("[controller]")]
	public class ProblemController : CodaAFriendController
	{
		/// <summary>
		/// Create the specifed <see cref="Problem"/>.
		/// </summary>
		/// <param name="problem">Properties for the <see cref="Problem"/>.</param>
		/// <returns><see cref="HttpStatusCode.Created"/> and created <see cref="Problem"/>.</returns>
		[HttpPost]
		public Problem CreateProblem(Problem problem)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// Update the specifed <see cref="Problem"/>.
		/// </summary>
		/// <param name="problemName">Name of problem to update.</param>
		/// <param name="problem">New Properties for problem.</param>
		/// <returns><see cref="HttpStatusCode.OK"/> and updated <see cref="Problem"/>.</returns>
		[HttpPut("{problemName}")]
		public Problem UpdateProblem(string problemName, Problem problem)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// Get a specified problem.
		/// </summary>
		/// <param name="problemName">Name of problem to retrieve.</param>
		/// <returns><see cref="HttpStatusCode.OK"/> and specified <see cref="Problem"/>.</returns>
		[HttpGet("{problemName}")]
		public Problem GetProblem(string problemName)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="problemName">Name of problem to delete.</param>
		/// <returns>><see cref="HttpStatusCode.NoContent"/>.</returns>
		[HttpDelete("{problemName}")]
		public void DeleteProblem(string problemName)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// Submit a <see cref="Script"/> to be considered a <see cref="ProblemSolution"/>.
		/// </summary>
		/// <param name="script"></param>
		/// <param name="problemName"></param>
		/// <returns>bool</returns>
		[HttpPost("{problemName}")]
		public bool TestScript(string problemName, UserScript script)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vote"></param>
		/// <param name="solution"></param>
		/// <returns></returns>
		public void Vote(Vote vote, ProblemSolution solution)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="problemName"></param>
		/// <returns>Solution[ * ]</returns>
		public IEnumerable<ProblemSolution> GetSolutions(string problemName)
		{
			throw new Exception("The method or operation is not implemented.");
		}

	}
}
