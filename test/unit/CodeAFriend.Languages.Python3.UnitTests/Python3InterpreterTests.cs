using CodeAFriend.DataModel;
using System;
using System.Threading.Tasks;
using Xunit;
using System.IO;
using System.Runtime.InteropServices;

namespace CodeAFriend.Languages.Python3.UnitTests
{
	public class Python3InterpreterTests
	{

		public static string HelloWorldOutput = @"Hello World";
		public static string HelloWorldScript = $"print(\"{HelloWorldOutput}\")";

		[Fact]
		public async Task Python3InterpreterRunsHelloWorld()
		{
			// Arrange
			var interpreter = new Python3Interpreter();
			RuntimeParameters parameters = new RuntimeParameters(HelloWorldScript, 10000, 10000, "");

			// Act
			ScriptEvaluation results = await interpreter.ExecuteAsync(parameters);

			// Assert
			Assert.Equal(HelloWorldOutput, results.Output.Trim());
		}

	}
}
