using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeAFriend.DataModel
{
	/// <summary>
	/// An operation to perform on the CodeAFriend backend.
	/// </summary>
	/// <typeparam name="TReturn">Type that will be returned by the execute.</typeparam>
	public interface ICommand<TReturn>
	{
		/// <summary>
		/// Asynchronously execute this command and return the resulting <typeparamref name="TReturn"/>.
		/// </summary>
		/// <returns></returns>
		Task<TReturn> ExecuteAsync(DbContext context);
	}
}
