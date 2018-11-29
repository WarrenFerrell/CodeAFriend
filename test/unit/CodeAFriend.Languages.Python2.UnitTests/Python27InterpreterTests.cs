using CodeAFriend.DataModel;
using System;
using System.Threading.Tasks;
using Xunit;
using System.IO;
using CodeAFriend.Languages.Python2;
using System.Runtime.InteropServices;

namespace CodeAFriend.Languages.Python2.UnitTests
{
	public class Python27InterpreterTests
	{

		public static string HelloWorldOutput = @"Hello World";
		public static string HelloWorldScript = $"print \"{HelloWorldOutput}\"";

		[Fact(Skip = "doesn't work yet")]
		public async Task Python2InterpreterRunsHelloWorld()
		{
			// Arrange
			Python27Interpreter interpreter = new Python27Interpreter();
			ExecutionParameters parameters = new ExecutionParameters(10000, 10000, "");

			// Act
			ScriptEvaluation results = await interpreter.ExecuteAsync(HelloWorldScript, parameters);

			// Assert
			Assert.Equal(HelloWorldOutput, results.Output.Trim());
		}

		[Fact]
		public async Task StaticPython2InterpreterRunsHelloWorld()
		{
			// Arrange 
			string output;

			// Act
			output = await Python27Interpreter.RunEngineAsync(HelloWorldScript);

			// Assert
			Assert.Equal(HelloWorldOutput, output.Trim());
		}
	}
}
