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
using CodeAFriend.Languages.Core;
using CodeAFriend.DataModel.Constants;

namespace CodeAFriend.Languages.Python2
{
	/// <summary>
	/// 
	/// </summary>
	public class Python27Interpreter : InterpreterTemplate
	{
		/// <inheritdoc/>
		public override SupportedLanguage Name { get; } = SupportedLanguage.Python27;

		/// <remarks>from 
		/// https://medium.com/emoney-engineering/running-python-script-from-c-and-working-with-the-results-843e68d230e5 .
		/// https://kimsereyblog.blogspot.com/2018/01/start-processes-from-c-in-dotnet-core.html 
		/// </remarks>
		/// <inheritdoc/>
		public override ProcessStartInfo GetProcessStartInfo(string scriptFilePath)
		{
			var thisAssembly = typeof(Python27Interpreter).Assembly;
			var arguments = $"{thisAssembly.ManifestModule.Name} {scriptFilePath}";

			return new ProcessStartInfo("dotnet", arguments);
		}

		public static async Task Main(string[] args)
		{
			string scriptFilePath = args[0];
			Console.Write(await RunEngineAsync(await File.ReadAllTextAsync(scriptFilePath)));

			return;
		}

		/// <remarks>from https://medium.com/emoney-engineering/running-python-script-from-c-and-working-with-the-results-843e68d230e5 </remarks>
		public static async Task<string> RunEngineAsync(string scriptBody)
		{
			ScriptEngine engine = IronPython.Hosting.Python.CreateEngine(); // Extract Python language engine from their grasp
			ScriptScope scope = engine.CreateScope(); // Introduce Python namespace (scope)

			//var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(parameters.Input));
			scope.Engine.Runtime.IO.SetInput(Console.OpenStandardInput(), Encoding.UTF8);

			var outputStream = new MemoryStream();
			scope.Engine.Runtime.IO.SetOutput(outputStream, Encoding.UTF8);

			ScriptSource source = engine.CreateScriptSourceFromString(scriptBody);
			source.Execute(scope);

			outputStream.Seek(0, SeekOrigin.Begin);
			using (var s = new StreamReader(outputStream))
			{
				return await s.ReadToEndAsync();
			}
		}



	}
}
