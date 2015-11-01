using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApplication
{
	/// <summary>
	/// Prime Numbers Helper
	/// </summary>
	public class PrimeNumbersHelper
	{
		/// <summary>
		/// Generates List of prime numbers for a specified amount.
		/// </summary>
		/// <param name="numberToGenerate">number of primes to generate.</param>
		/// <returns>List of prime numbers.</returns>
		public static List<int> Generate(int numberToGenerate)
		{
			var primeNumbers = new List<int>() { 2 };
			var nextPrimeNumber = 3;
			while (primeNumbers.Count < numberToGenerate)
			{
				var sqrt = (int)Math.Sqrt(nextPrimeNumber);
				var isPrime = true;
				for (var i = 0; primeNumbers[i] <= sqrt; i++)
				{
					if (nextPrimeNumber % primeNumbers[i] != 0)
					{
						continue;
					}
					isPrime = false;
					break;
				}
				if (isPrime)
				{
					primeNumbers.Add(nextPrimeNumber);
				}
				nextPrimeNumber += 2;
			}
			return primeNumbers;
		}

		/// <summary>
		/// Create an 2D array for a given list of prime numbers.
		/// </summary>
		/// <param name="primeNumbers">list of prime numbers.</param>
		/// <returns>2D array for prime numbers.</returns>
		public static int?[,] CreateArrayForPrimeNumbers(List<int> primeNumbers)
		{
			var arraySize = primeNumbers.Count() + 1;

			int?[,] array = new int?[arraySize, arraySize];

			for (var i = 0; i < primeNumbers.Count; i++)
			{
				var primeNumber = primeNumbers[i];
				array[0, i + 1] = primeNumber;
				array[i + 1, 0] = primeNumber;
			}

			MultiplyArrayValues(array, arraySize);

			return array;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public static void MultiplyArrayValues(int?[,] array, int arraySize)
		{
			for (var x = 1; x < arraySize; x++)
			{
				for (int y = 1; y < arraySize; y++)
				{
					array[x, y] = array[x, 0].Value * array[y, 0].Value;
				};
			}
        }
	}
}
