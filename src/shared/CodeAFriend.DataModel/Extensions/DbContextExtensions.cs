using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
		/// Asynchronously update a new <typeparamref name="TValue"/> in a <see cref="DbContext"/> and return the result.
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="context">context to save to.</param>
		/// <param name="value">object to save.</param>
		/// <returns></returns>
		public static async Task<TValue> UpdateAsync<TValue>(this DbContext context, TValue value) where TValue : class
		{
			var entity = context.Update<TValue>(value);
			await context.SaveChangesAsync();
			return entity.Entity;
		}
	}
}
