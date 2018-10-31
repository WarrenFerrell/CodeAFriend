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

namespace CodeAFriend.LanguageStrategy.Python
{
	/// <summary>
	/// 
	/// </summary>
	public class Python2Interpreter : ILanguageInterpreter
	{
		public string Name { get; } = nameof(Python);

		/// <inheritdoc/>
		public async Task<ScriptEvaluation> ExecuteAsync(RuntimeParameters parameters)
		{
			return await RunProcessAsync(parameters);
		}


		public static async Task Main(string[] args)
		{
			string scriptBody = Encoding.UTF8.GetString(Convert.FromBase64String(args[0]));
			Console.Write(await RunEngineAsync(scriptBody));

			Thread.Sleep( 555555555);
			return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parameter"></param>
		/// <param name="serviceid"></param>
		/// <remarks>from https://medium.com/emoney-engineering/running-python-script-from-c-and-working-with-the-results-843e68d230e5 </remarks>
		/// <returns></returns>
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

		public static string AssemblyDirectory
		{
			get
			{
				string codeBase = Assembly.GetExecutingAssembly().CodeBase;
				UriBuilder uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);
				return Path.GetDirectoryName(path);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parameter"></param>
		/// <param name="serviceid"></param>
		/// <remarks>from https://medium.com/emoney-engineering/running-python-script-from-c-and-working-with-the-results-843e68d230e5 .
		/// https://kimsereyblog.blogspot.com/2018/01/start-processes-from-c-in-dotnet-core.html </remarks>
		/// <returns></returns>
		private async Task<ScriptEvaluation> RunProcessAsync(RuntimeParameters parameters)
		{
			var thisAssembly = typeof(Python2Interpreter).Assembly;
			var arguments = $"{thisAssembly.ManifestModule.Name} {Convert.ToBase64String(Encoding.UTF8.GetBytes(parameters.ScriptBody))}";

			ProcessStartInfo startInfo = new ProcessStartInfo("dotnet", arguments);
			startInfo.CreateNoWindow = true;
			startInfo.UseShellExecute = false;
			startInfo.FileName = "dotnet";
			startInfo.Arguments = arguments;
			startInfo.RedirectStandardOutput = true;
			startInfo.RedirectStandardInput = true;
			startInfo.RedirectStandardError = true;

			var currentdir = Directory.GetCurrentDirectory();

			Directory.SetCurrentDirectory(AssemblyDirectory);
			var executingDir = AssemblyDirectory;
			var executingLoc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			using (var process = Process.Start(startInfo))
			{
				Debug.WriteLine(process.ProcessName);
				Debug.WriteLine(process.Id);
				string error = await process.StandardError.ReadToEndAsync();
				if (!string.IsNullOrWhiteSpace(error))
				{
					throw new Exception(error);
				}
				//process.StandardOutput.BaseStream.Seek(0, SeekOrigin.Begin);
				using (StreamReader reader = process.StandardOutput)
				{
					
					//reader.BaseStream.Seek(0, SeekOrigin.Begin);
					string result = await reader.ReadToEndAsync();
					return new ScriptEvaluation(
						output: result,
						cpuTime: process.UserProcessorTime.TotalMilliseconds,
						memoryUsage: process.PeakPagedMemorySize64 + process.PeakVirtualMemorySize64,
						parameters: parameters
				);
				}

					//process.Inpu

					//process.OutputDataReceived += (sender, data) => {
					//	Console.WriteLine(data.Data);
					//};

					////var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(parameters.Input));
					//process.S
					process.Start();
				
				await process.StandardInput.WriteAsync(parameters.Input.AsMemory());

				CancellationTokenSource source = new CancellationTokenSource();
				Task processTask = new Task(async () => await Task.Delay((int) 1000, source.Token));
				process.Exited += (sender, data) => {
					source.Cancel();
				};
				await processTask;
				process.WaitForExit(1000);
				process.StandardOutput.BaseStream.Seek(0, SeekOrigin.Begin);  
				return new ScriptEvaluation(
					output: await process.StandardOutput.ReadToEndAsync(),
					cpuTime: process.UserProcessorTime.TotalMilliseconds,
					memoryUsage: process.PeakPagedMemorySize64 + process.PeakVirtualMemorySize64,
					parameters: parameters
				);
			}
			
		}

		private void Process_Exited(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
