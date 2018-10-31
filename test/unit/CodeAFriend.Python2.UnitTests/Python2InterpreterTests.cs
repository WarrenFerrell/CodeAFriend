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
	public class Python2InterpreterTests
	{

		public static string HelloWorldOutput = @"Hello World";
		public static string HelloWorldScript = $"print \"{HelloWorldOutput}\"";

		[Fact(Skip = "doesn't work yet")]
		public async Task Python2InterpreterRunsHelloWorld()
		{
			// Arrange
			Python2Interpreter interpreter = new Python2Interpreter();
			RuntimeParameters parameters = new RuntimeParameters(HelloWorldScript, 10000, 10000, "");

			// Act
			ScriptEvaluation results = await interpreter.ExecuteAsync(parameters);

			// Assert
			Assert.Equal(HelloWorldOutput, results.Output.Trim());
		}

		[Fact]
		public async Task StaticPython2InterpreterRunsHelloWorld()
		{
			// Arrange 
			string output;

			// Act
			output = await Python2Interpreter.RunEngineAsync(HelloWorldScript);

			// Assert
			Assert.Equal(HelloWorldOutput, output.Trim());
		}
	}
}
