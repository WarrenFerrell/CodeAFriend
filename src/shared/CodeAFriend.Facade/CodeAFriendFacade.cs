using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAFriend.DataModel;
using CodeAFriend.Languages.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodeAFriend.Facade
{
	/// <inheritdoc />
	public partial class CodeAFriendFacade : ICodeAFriendFacade
	{
		private readonly DbContext _dbContext;
		private readonly IInterpreterFactory _interpreterFactory;

		/// <summary>DI Constructor</summary>
		public CodeAFriendFacade(DbContext dbContext, IInterpreterFactory interpreterFactory)
		{
			_dbContext = dbContext;
			_interpreterFactory = interpreterFactory;
		}



		private async Task<TValue> CreateAsync<TValue>(TValue value) where TValue: class
		{
			var entity = _dbContext.Add<TValue>(value);
			await _dbContext.SaveChangesAsync();
			return entity.Entity;
		}




		/// <inheritdoc />
		public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
		{
			var result = await command.ExecuteAsync(_dbContext);
			return result;
		}
	}
}
