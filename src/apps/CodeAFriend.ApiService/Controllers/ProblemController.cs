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
	public class ProblemController : CodaAFriendController
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="problem"></param>
		/// <returns>Problem</returns>
		public Problem CreateProblem(Problem problem)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="problem"></param>
		/// <returns>Problem</returns>
		public Problem UpdateProblem(Problem problem)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns>Problem</returns>
		public Problem GetProblem(string name)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public void DeleteProblem(string name)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="script"></param>
		/// <param name="problemName"></param>
		/// <returns>bool</returns>
		public bool TestScript(UserScript script, string problemName)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="vote"></param>
		/// <param name="solution"></param>
		/// <returns></returns>
		public void Vote(Vote vote, Solution solution)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="problemName"></param>
		/// <returns>Solution[ * ]</returns>
		public IEnumerable<Solution> GetSolutions(string problemName)
		{
			throw new Exception("The method or operation is not implemented.");
		}

	}
}
