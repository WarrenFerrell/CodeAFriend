using CodeAFriend.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CodeAFriend.Core.Helpers;
using CodeAFriend.DataModel.Constants;
using CodeAFriend.Languages.Python2;
using CodeAFriend.Languages.Python3;
using Microsoft.Extensions.Caching.Memory;

namespace CodeAFriend.Languages.Core
{
	/// <inheritdoc />
	/// <remarks>Uses a cache where appropriate.</remarks>
	public class InterpreterFactory : IInterpreterFactory
	{
		private readonly IMemoryCache _cache;

		/// <summary>DI constructor.</summary>
		public InterpreterFactory(IMemoryCache cache)
		{
			_cache = cache;
		}

		/// <inheritdoc />
		public ILanguageInterpreter GetInterpreter(SupportedLanguage language)
		{
			var hash = ObjectHelpers.GetHash(language);
			switch (language) {
					case SupportedLanguage.Python27: return  new Python27Interpreter();
					case SupportedLanguage.Python37: return _cache.GetOrCreate<ILanguageInterpreter>(hash, _ => new Python37Interpreter());
					default: throw new InvalidEnumArgumentException(nameof(language));
			}
		}
	}
}
