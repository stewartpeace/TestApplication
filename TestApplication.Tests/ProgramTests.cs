using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestApplication.Tests
{
	[TestClass]
	public class ProgramTests
	{
		#region Constants

		const string PromptEnterMessage = "Enter a max number of primes:";
		const string PromptEnterMessageResponse = "You Entered:";
		const string PromptCloseMessage = "Press return to close application.";
		const string PromptInvalidNumberResponse = "Please specify a numceric value which is greater or equal to 1.";

		#endregion

		[TestMethod]
		public void TestMainMethodSucessfully()
		{
			using (StringWriter stringWriter = new StringWriter())
			{
				Console.SetOut(stringWriter);
				int numberToGenerate = 10;
				var expectedOutput = "\t2\t3\t5\t7\t11\t13\t17\t19\t23\t" + Environment.NewLine + 
									"2\t4\t6\t10\t14\t22\t26\t34\t38\t46\t" + Environment.NewLine +
									"3\t6\t9\t15\t21\t33\t39\t51\t57\t69\t" + Environment.NewLine +
									"5\t10\t15\t25\t35\t55\t65\t85\t95\t115\t" + Environment.NewLine +
									"7\t14\t21\t35\t49\t77\t91\t119\t133\t161\t" + Environment.NewLine +
									"11\t22\t33\t55\t77\t121\t143\t187\t209\t253\t" + Environment.NewLine +
									"13\t26\t39\t65\t91\t143\t169\t221\t247\t299\t" + Environment.NewLine +
									"17\t34\t51\t85\t119\t187\t221\t289\t323\t391\t" + Environment.NewLine +
									"19\t38\t57\t95\t133\t209\t247\t323\t361\t437\t" + Environment.NewLine +
									"23\t46\t69\t115\t161\t253\t299\t391\t437\t529\t";

				using (StringReader stringReader = new StringReader(string.Format("{0}{1}", numberToGenerate, Environment.NewLine)))
				{
					Console.SetIn(stringReader);
					Program.Main(new string[] { });
					string expectedResult = string.Format("{0}{4}{1}{3}{4}{5}{4}{2}{4}",
						PromptEnterMessage,
						PromptEnterMessageResponse,
						PromptCloseMessage,
						numberToGenerate,
                        Environment.NewLine,
						expectedOutput);
					Assert.AreEqual<string>(expectedResult, stringWriter.ToString());
				}
			}
		}

		[TestMethod]
		public void TestMainMethodForInvalidNumbers()
		{
			/* Test for text */
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

			/* Test for 0 */
			using (StringWriter stringWriter = new StringWriter())
			{
				Console.SetOut(stringWriter);
				using (StringReader stringReader = new StringReader(string.Format("0{0}", Environment.NewLine)))
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
