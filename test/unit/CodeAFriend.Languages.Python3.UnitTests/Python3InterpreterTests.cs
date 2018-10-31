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

		public static string HelloGorillaInput = @"
Hello World!
Goodnight World!".Trim();
		public static string HelloGorillaOutput = @"
Hello Gorilla!
Goodnight Gorilla!".Trim();
		public static string HelloGorillaScript = $@"
import sys
for line in sys.stdin:
	print(line.replace(""World"", ""Gorilla""), end='')".Trim();

	[Fact]
		public async Task Python3InterpreterRunsHelloGorilla()
		{
			// Arrange
			var interpreter = new Python3Interpreter();
			RuntimeParameters parameters = new RuntimeParameters(HelloGorillaScript, 10000, 10000, HelloGorillaInput);

			// Act
			ScriptEvaluation results = await interpreter.ExecuteAsync(parameters);

			// Assert
			Assert.Equal(HelloGorillaOutput, results.Output.Trim());
		}

	}
}
