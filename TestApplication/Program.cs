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
				if (int.TryParse(lineValue, out maxPrimesToGenerate))
				{
					Console.WriteLine("You Entered:" + maxPrimesToGenerate);

					//TODO:  
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
						Console.WriteLine("Please specify a numceric value.");
						break;
                    }
				}
			}
			
			Console.WriteLine("Press return to close application.");
			Console.ReadLine();
		}
	}
}
