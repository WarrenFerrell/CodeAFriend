using CodeAFriend.LanguageStrategy;
using CodeAFriend.DataModel;
using System;
using System.Threading.Tasks;
using Xunit;
using System.IO;
using CodeAFriend.LanguageStrategy.Python;
using System.Runtime.InteropServices;

namespace CodeAFriend.Python.UnitTests
{
	public class InterpreterTests
	{

		public static string HelloWorldOutput = @"Hello World";
		public static string HelloWorldScript = $"print \"{HelloWorldOutput}\"";

		[Fact]
		public async Task PythonInterpreterRunsHelloWorld()
		{
			// Arrange
			PythonInterpreter interpreter = new PythonInterpreter();
			RuntimeParameters parameters = new RuntimeParameters(HelloWorldScript, 10000, 10000, "");

			// Act
			ScriptEvaluation results = await interpreter.ExecuteAsync(parameters);

			// Assert
			Assert.Equal(HelloWorldOutput, results.Output.Trim());
		}

		[Fact]
		public async Task StaticPythonInterpreterRunsHelloWorld()
		{
			// Arrange 
			string output;

			// Act
			output = await PythonInterpreter.RunEngineAsync(HelloWorldScript);

			// Assert
			Assert.Equal(HelloWorldOutput, output.Trim());
		}
	}
}
