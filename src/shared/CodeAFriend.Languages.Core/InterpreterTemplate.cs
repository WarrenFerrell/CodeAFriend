using CodeAFriend.DataModel;
using CodeAFriend.DataModel.Constants;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeAFriend.Languages.Core
{
	public abstract class InterpreterTemplate : ILanguageInterpreter
	{
		/// <inheritdoc/>
		public abstract string Name { get; }

		/// <inheritdoc/>
		public async Task<ScriptEvaluation> ExecuteAsync(RuntimeParameters parameters)
		{
			var scriptFilePath = await WriteScriptToFileAsync(parameters.ScriptBody);

			ProcessStartInfo startInfo = GetProcessStartInfo(scriptFilePath);

			return await RunProcessAsync(parameters, startInfo, scriptFilePath);
		}

		public virtual async Task<string> WriteScriptToFileAsync(string scriptBody)
		{
			Directory.CreateDirectory(DirectoryPaths.Scripts);
			var scriptFilePath = Path.Join(Directory.GetCurrentDirectory(), DirectoryPaths.Scripts, $"{Guid.NewGuid()}.{Name}");
			var scriptFile = File.OpenWrite(scriptFilePath);
			await scriptFile.WriteAsync(Encoding.UTF8.GetBytes(scriptBody));
			scriptFile.Close();
			return scriptFilePath;
		}

		public abstract ProcessStartInfo GetProcessStartInfo(string scriptFilePath);

		public virtual async Task<ScriptEvaluation> RunProcessAsync(RuntimeParameters parameters, ProcessStartInfo startInfo, string scriptFilePath)
		{
			startInfo.CreateNoWindow = true;
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;
			startInfo.RedirectStandardInput = true;
			startInfo.RedirectStandardError = true;

			using (var process = Process.Start(startInfo))
			{
				Debug.WriteLine(process.ProcessName);
				Debug.WriteLine(process.Id);
				try
				{
					using (StreamWriter input = process.StandardInput)
					{
						await input.WriteAsync(parameters.Input.AsMemory());
					}

					using (StreamReader reader = process.StandardOutput)
					{
						string result = await reader.ReadToEndAsync();
						return new ScriptEvaluation(
							output: result,
							cpuTime: process.UserProcessorTime.TotalMilliseconds,
							memoryUsage: process.PeakPagedMemorySize64 + process.PeakVirtualMemorySize64,
							parameters: parameters
						);
					}
				}
				finally
				{
					string error = await process.StandardError.ReadToEndAsync();
					if (!string.IsNullOrWhiteSpace(error))
					{
						throw new Exception(error);
					}
				}

				throw new NotImplementedException();
				//CancellationTokenSource source = new CancellationTokenSource();
				//Task processTask = new Task(async () => await Task.Delay((int)1000, source.Token));
				//process.Exited += (sender, data) =>
				//{
				//	source.Cancel();
				//};
				//await processTask;
				//process.WaitForExit(1000);
				//process.StandardOutput.BaseStream.Seek(0, SeekOrigin.Begin);
				//return new ScriptEvaluation(
				//	output: await process.StandardOutput.ReadToEndAsync(),
				//	cpuTime: process.UserProcessorTime.TotalMilliseconds,
				//	memoryUsage: process.PeakPagedMemorySize64 + process.PeakVirtualMemorySize64,
				//	parameters: parameters
				//);
			}
		}
	}
}
