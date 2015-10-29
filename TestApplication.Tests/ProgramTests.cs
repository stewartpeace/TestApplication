using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestApplication.Tests
{
	[TestClass]
	public class ProgramTests
	{

		const string PromptEnterMessage = "Enter a max number of primes:";
		const string PromptEnterMessageResponse = "You Entered:";
		const string PromptCloseMessage = "Press return to close application.";
		const string PromptInvalidNumberResponse = "Please specify a numceric value.";

		[TestMethod]
		public void TestMainMethodSucessfully()
		{
			using (StringWriter stringWriter = new StringWriter())
			{
				Console.SetOut(stringWriter);
				int numberToGenerate = 10;
				using (StringReader stringReader = new StringReader(string.Format("{0}{1}", numberToGenerate, Environment.NewLine)))
				{
					Console.SetIn(stringReader);
					Program.Main(new string[] { });
					string expectedResult = string.Format("{0}{4}{1}{3}{4}{2}{4}",
						PromptEnterMessage,
						PromptEnterMessageResponse,
						PromptCloseMessage,
						numberToGenerate,
                        Environment.NewLine);
					Assert.AreEqual<string>(expectedResult, stringWriter.ToString());
				}
			}
		}

		[TestMethod]
		public void TestMainMethodForInvalidNuber()
		{
			using (StringWriter stringWriter = new StringWriter())
			{
				Console.SetOut(stringWriter);
				using (StringReader stringReader = new StringReader(string.Format("ABC{0}", Environment.NewLine)))
				{
					Console.SetIn(stringReader);
					Program.Main(new string[] { });
					string expectedResult = string.Format("{0}{3}{1}{3}{2}{3}",
						PromptEnterMessage,
						PromptInvalidNumberResponse,
						PromptCloseMessage,
                        Environment.NewLine);
					Assert.AreEqual<string>(expectedResult, stringWriter.ToString());
				}
			}
		}

		[TestMethod]
		public void TestMainMethodForExit()
		{
			using (StringWriter stringWriter = new StringWriter())
			{
				Console.SetOut(stringWriter);
				using (StringReader stringReader = new StringReader(string.Format("exit{0}", Environment.NewLine)))
				{
					Console.SetIn(stringReader);
					Program.Main(new string[] { });
					string expectedResult = string.Format("{0}{2}{1}{2}",
						PromptEnterMessage,
						PromptCloseMessage,
                        Environment.NewLine);
					Assert.AreEqual<string>(expectedResult, stringWriter.ToString());
				}
			}
		}
	}
}
