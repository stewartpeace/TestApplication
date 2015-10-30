using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
	public class PrimeNumbersHelper
	{
		/// <summary>
		/// Generates List of prime numbers for a specified amount.
		/// </summary>
		/// <param name="numberToGenerate"></param>
		/// <returns>List of prime numbers.</returns>
		public static List<int> Generate(int numberToGenerate)
		{
			var primeNumbers = new List<int>() { 2 } ;
			var nextPrimeNumber = 3;
			while (primeNumbers.Count < numberToGenerate)
			{
				int sqrt = (int)Math.Sqrt(nextPrimeNumber);
				bool isPrime = true;
				for (int i = 0; (int)primeNumbers[i] <= sqrt; i++)
				{
					if (nextPrimeNumber % primeNumbers[i] == 0)
					{
						isPrime = false;
						break;
					}
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
		/// <param name="primeNumbers"></param>
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

			//TODO: Can this be done in a one pass so that is calculates the values in the for loop above?
			for (var i = 0; i < primeNumbers.Count; i++)
			{
				for (int y = 0; y < arraySize; y++)
				{
					int? value = array[i, y];
					if (i > 0 & y > 0)
					{
						array[i, y] = array[i, 0] * array[y, 0];
					}
				};
			}

			return array;
		}
	}
}
