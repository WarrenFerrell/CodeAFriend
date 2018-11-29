using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAFriend.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodeAFriend.Facade
{
	public partial class CodeAFriendFacade
	{
		/// <inheritdoc />
		public async Task<Problem> GetProblem(string problemName)
		{
			var result = await _dbContext.FindAsync<Problem>(problemName);
			return result;
		}
	}
}
