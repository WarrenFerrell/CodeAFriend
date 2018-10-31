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

namespace CodeAFriend.Languages.Python3
{
	/// <summary>
	/// 
	/// </summary>
	public class Python3Interpreter : ILanguageInterpreter
	{
		public string Name { get; } = nameof(Python);

		/// <inheritdoc/>
		public async Task<ScriptEvaluation> ExecuteAsync(RuntimeParameters parameters)
		{
			return await RunProcessAsync(parameters);
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="parameter"></param>
		/// <param name="serviceid"></param>
		/// <remarks>run to create an alias  
		/// doskey python3="C:\Program Files\Python37\python.exe"
		/// </remarks>
		/// <returns></returns>
		private async Task<ScriptEvaluation> RunProcessAsync(RuntimeParameters parameters)
		{
			Directory.CreateDirectory(DirectoryPaths.Scripts);
			var scriptFilePath = $"{DirectoryPaths.Scripts}/{Guid.NewGuid()}.py3";
			var scriptFile = File.OpenWrite(scriptFilePath);
			await scriptFile.WriteAsync(Encoding.UTF8.GetBytes(parameters.ScriptBody));
			scriptFile.Close();

			ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\Program Files\Python37\python.exe", scriptFilePath); // todo: make this referenced by an alias
			startInfo.CreateNoWindow = true;
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;
			startInfo.RedirectStandardInput = true;
			startInfo.RedirectStandardError = true;

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
