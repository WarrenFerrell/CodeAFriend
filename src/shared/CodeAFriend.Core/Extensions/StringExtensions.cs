using System;

namespace CodeAFriend.Core
{
	public static class StringExtensions
	{
		public static string UpToFirst(this string str, char c)
		{
			return str.Substring(0, str.IndexOf(','));
		}
	}
}
