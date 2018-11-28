using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace CodeAFriend.Core.Helpers
{
	/// <summary>
	/// Helper methods for working with objects.
	/// </summary>
	public static class ObjectHelpers
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static byte[] GetBytes(object obj)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (var stream = new MemoryStream())
			{
				formatter.Serialize(stream, obj);
				return stream.ToArray();
			}
		}

		/// <summary>
		/// Get the hash of a serializable object using a SHA256 hash
		/// </summary>
		/// <param name="obj">object to hash.</param>
		/// <returns></returns>
		public static string GetHash(object obj)
		{
			using (var sha1 = System.Security.Cryptography.SHA256.Create()) {
				return GetHash(obj, sha1);
			}
		}

		/// <summary>
		/// Get the hash of a serializable object using a specified hash
		/// </summary>
		/// <param name="obj">object to hash.</param>
		/// <param name="hashAlgorithm">Hash algorithm to use.</param>
		/// <returns></returns>
		public static string GetHash(object obj, HashAlgorithm hashAlgorithm)
		{
			var bytes = GetBytes(obj);
			var hash = hashAlgorithm.ComputeHash(bytes);
			return BitConverter.ToString(hash);
		}
	}
}
