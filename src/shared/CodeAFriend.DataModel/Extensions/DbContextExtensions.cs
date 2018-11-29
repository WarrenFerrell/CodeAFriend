using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// Extension methods for <see cref="DbContext"/>
	/// </summary>
	public static class DbContextExtensions
	{
		/// <summary>
		/// Asynchronously save a new <typeparamref name="TValue"/> to a context and return the result.
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="context">context to save to.</param>
		/// <param name="value">object to save.</param>
		/// <returns></returns>
		public static async Task<TValue> AddAndReturnAsync<TValue>(this DbContext context, TValue value) where TValue : class
		{
			var entity = context.Add<TValue>(value);
			await context.SaveChangesAsync();
			return entity.Entity;
		}

		/// <summary>
		/// Asynchronously update a <typeparamref name="TValue"/> in a <see cref="DbContext"/> and return the result.
		/// </summary>
		/// <typeparam name="TValue">Type of the stored entity.</typeparam>
		/// <param name="context">context to save to.</param>
		/// <param name="value">object to save.</param>
		/// <param name="propertiesToUpdate">Name of each property that should be updated. If none are provided then ALL PROPERTIES WILL BE UPDATED.</param>
		/// <returns></returns>
		public static async Task<TValue> UpdateAsync<TValue>(this DbContext context, TValue value, params string[] propertiesToUpdate ) where TValue : class
		{
			EntityEntry<TValue> updateEntity;
			if (propertiesToUpdate.Length == 0) updateEntity =  context.Update(value);
			else
			{
				updateEntity = context.Attach(value);
				updateEntity.State = EntityState.Modified;
				foreach (string propertyName in propertiesToUpdate)
				{
					PropertyEntry property = updateEntity.Properties.Single(p => p.Metadata.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
					property.IsModified = true;
				}
			}
			await context.SaveChangesAsync();
			return updateEntity.Entity;
		}
	}
}
