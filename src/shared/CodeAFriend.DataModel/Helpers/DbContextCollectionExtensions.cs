using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// Set of methods for helping implement DDD-style design
	/// </summary>
	/// <remarks>some code from https://github.com/JonPSmith/EfCore.GenericBizRunner/blob/master/DataLayer/EfClasses/Book.cs </remarks>
	public static class DbContextCollectionExtensions
	{
		/// <summary>
		/// Add a new entity, <paramref name="newChild"/>, to a <paramref name="parent"/> entity <paramref name="collection"/> of <see cref="TChild"/>.
		/// </summary>
		/// <typeparam name="TParent">Type of the parent entity.</typeparam>
		/// <typeparam name="TChild">Type of the child entity</typeparam>
		/// <param name="parent">Parent entity instance.</param>
		/// <param name="collection">Collection of dependent entities.</param>
		/// <param name="newChild">New dependent entity.</param>
		/// <param name="context">Database to save the updated state to. (When SaveChanges is called).</param>
		public static void Add<TParent, TChild>(this TParent parent, ICollection<TChild> collection, TChild newChild, DbContext context = null) 
			where TParent : class 
			where TChild : class
		{
			if (parent == null) throw new ArgumentNullException(nameof(parent));

			if (collection != null)
			{
				collection.Add(newChild);
			}
			else if (context == null)
			{
				throw new ArgumentNullException(nameof(context),
					$"You must provide a context if the {typeof(TChild).Name} collection isn't valid.");
			}
			else if (context.Entry(parent).IsKeySet)
			{
				context.Add(newChild);
			}
			else
			{
				throw new InvalidOperationException($"Unable to save {typeof(TChild).Name} for {typeof(TParent).Name}.");
			}
		}
	}
}
