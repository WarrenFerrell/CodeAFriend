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

		private async Task<TEntity> UpdateAsync<TEntity>(TEntity entity, IEnumerable<string> propertiesToUpdate = null) where TEntity : class
		{
			EntityEntry<TEntity> updateEntity;
			if (propertiesToUpdate == null) updateEntity =  _dbContext.Update(entity);
			else if (propertiesToUpdate.Count() == 0)  throw new InvalidOperationException("Must change at least one property");
			else
			{
				updateEntity = _dbContext.Attach(entity);
				updateEntity.State = EntityState.Modified;
				foreach (string propertyName in propertiesToUpdate)
				{
					PropertyEntry property = updateEntity.Properties.Single(p => p.Metadata.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
					property.IsModified = true;
				}
			}
			await _dbContext.SaveChangesAsync();
			return updateEntity.Entity;
		}
	}
}
