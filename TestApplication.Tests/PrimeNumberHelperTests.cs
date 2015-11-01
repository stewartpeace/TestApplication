using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestApplication.Tests
{
	[TestClass]
	public class PrimeNumberHelperTests
	{
		/// <summary>
		/// Test generation of list of prime numbers.
		/// </summary>
		[TestMethod]
		public void Generate()
		{
			List<int> expected = new List<int> { 2, 3, 5, 7, 11 };
			List<int> actual = PrimeNumbersHelper.Generate(5);
			
			CollectionAssert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Test creation of 2D array from List of prime numbers.
		/// </summary>
		[TestMethod]
		public void CreateArrayForPrimeNumbers()
		{
			int?[,] expected = new int?[4, 4];
			expected[0, 0] = null;
			expected[0, 1] = 2;
			expected[0, 2] = 3;
			expected[0, 3] = 5;
			expected[1, 0] = 2;
			expected[1, 1] = 4;
			expected[1, 2] = 6;
			expected[1, 3] = 10;
			expected[2, 0] = 3;
			expected[2, 1] = 6;
			expected[2, 2] = 9;
			expected[2, 3] = 15;
			expected[3, 0] = 5;
			expected[3, 1] = 10;
			expected[3, 2] = 15;
			expected[3, 3] = 25;
			
			List<int> primeNumbers = new List<int> { 2, 3, 5 };
			int?[,] actual = PrimeNumbersHelper.CreateArrayForPrimeNumbers(primeNumbers);
			
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void MultiplyArrayValues()
		{
			int?[,] actual = new int?[4, 4];
			actual[0, 0] = null;
			actual[0, 1] = 2;
			actual[0, 2] = 3;
			actual[0, 3] = 5;
			actual[1, 0] = 2;
			actual[1, 1] = null;
			actual[1, 2] = null;
			actual[1, 3] = null;
			actual[2, 0] = 3;
			actual[2, 1] = null;
			actual[2, 2] = null;
			actual[2, 3] = null;
			actual[3, 0] = 5;
			actual[3, 1] = null;
			actual[3, 2] = null;
			actual[3, 3] = null;
			
			int?[,] expected = new int?[4, 4];
			expected[0, 0] = null;
			expected[0, 1] = 2;
			expected[0, 2] = 3;
			expected[0, 3] = 5;
			expected[1, 0] = 2;
			expected[1, 1] = 4;
			expected[1, 2] = 6;
			expected[1, 3] = 10;
			expected[2, 0] = 3;
			expected[2, 1] = 6;
			expected[2, 2] = 9;
			expected[2, 3] = 15;
			expected[3, 0] = 5;
			expected[3, 1] = 10;
			expected[3, 2] = 15;
			expected[3, 3] = 25;

			PrimeNumbersHelper.MultiplyArrayValues(actual, 4);

			CollectionAssert.AreEqual(expected, actual);

		}
			
	}
}
