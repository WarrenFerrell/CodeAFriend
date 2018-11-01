using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CodeAFriend.DataModel;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using CodeAFriend.DataModel.Constants;
using System.Text.RegularExpressions;
using CodeAFriend.Languages.Core;

namespace CodeAFriend.Languages.Python3
{
	/// <summary>
	/// 
	/// </summary>
	public class Python3Interpreter : InterpreterTemplate
	{
		public override string Name { get; } = nameof(Python3Interpreter);

		/// <remarks>run to create an alias  
		/// doskey python3="C:\Program Files\Python37\python.exe"
		/// </remarks>
		public override ProcessStartInfo GetProcessStartInfo(string scriptFilePath)
		{
			return new ProcessStartInfo(@"C:\Program Files\Python37\python.exe", scriptFilePath);
		}
	}
}
