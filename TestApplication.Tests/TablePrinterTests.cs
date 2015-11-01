using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace TestApplication.Tests
{
	[TestClass]
	public class TablePrinterTests
	{
		[TestMethod]
		public void Print()
		{			
			/* Test for table output to console */
			using (StringWriter stringWriter = new StringWriter())
			{
				Console.SetOut(stringWriter);
				using (StringReader stringReader = new StringReader(string.Empty))
				{
					Console.SetIn(stringReader);

					List<int> primeNumbers = new List<int> { 2, 3, 5 };
					TablePrinter.Print(primeNumbers);

					var expectedOutput = "\t2\t3\t5\t" + Environment.NewLine +
										"2\t4\t6\t10\t" + Environment.NewLine +
										"3\t6\t9\t15\t" + Environment.NewLine +
										"5\t10\t15\t25\t" + Environment.NewLine;	

					Assert.AreEqual<string>(expectedOutput, stringWriter.ToString());
				}
			}
		}
	}
}
