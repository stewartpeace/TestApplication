using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
	internal class TablePrinter
	{
		/// <summary>
		/// Print Prime Numbers to Console
		/// </summary>
		/// <param name="primeNumbers"></param>
		internal static void Print(List<int> primeNumbers)
		{
			var array = PrimeNumbersHelper.CreateArrayForPrimeNumbers(primeNumbers);
			PrintTable(array);
		}
		
		/// <summary>
		/// Writes out to console the 2D array of values.
		/// </summary>
		/// <param name="array"></param>
		static void PrintTable(int?[,] array)
		{
			var arraySize = array.GetUpperBound(0);
			for (int x = 0; x < arraySize; x++)
			{
				for (int y = 0; y < arraySize; y++)
				{
					Console.Write(array[x, y] +"\t");
				}
				Console.WriteLine();
			}
		}
	}
}

