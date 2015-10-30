using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Enter a max number of primes:");

			while (true)
			{
				string lineValue = Console.ReadLine();
				int maxPrimesToGenerate;
				if (int.TryParse(lineValue, out maxPrimesToGenerate) && isValidNumber(maxPrimesToGenerate))
				{
					Console.WriteLine("You Entered:" + maxPrimesToGenerate);

					var primeNumbers = PrimeNumbersHelper.Generate(maxPrimesToGenerate);
                    TablePrinter.Print(primeNumbers);
					break;
				}
				else
				{
					if (lineValue == "exit")
					{
						break;
					}
					else
					{
						Console.WriteLine("Please specify a numceric value which is greater or equal to 1.");
						break;
                    }
				}
			}
			
			Console.WriteLine("Press return to close application.");
			Console.ReadLine();
		}

		/// <summary>
		/// Checks number is valid.
		/// </summary>
		/// <param name="number">a number.</param>
		/// <returns>true or false</returns>
		static bool isValidNumber(int number)
		{
			var isValid = true;

			isValid = (number >= 1);

			return isValid;
		}
	}
}
