using System;

namespace DifferenceEquation
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//Read three parameters
			Console.Write("Please Enter a:");
			int a = Int32.Parse(Console.ReadLine());
			Console.Write("Please Enter b:");
			int b = Int32.Parse(Console.ReadLine());
			Console.Write("Please Enter c:");
			int c = Int32.Parse(Console.ReadLine());

			//Calculate b**c 
			//Math.Pow(value, power)
			double n = Math.Pow(b, c);
			Console.Write(n);

			//Calculate logb(n) = k
			double k = Math.Log(n, b);
			Console.Write(k);

			//Calculate m
			double m = n / (n - a);
			Console.Write(m);

			//a = b^c
			//T(n) = c1*(n^c) + (n^c)*(log(n)/log(b))
			if (c == 0)
			{
				if (a == n)
				{
					Console.WriteLine("T(n) = c1*log " + b + "(n)");
				}
				else
				{
					Console.WriteLine("T(n) = c1*n^" + "log" + b + "(" + a + ")" + m);
				}
			}
			else {
				if (a == n)
				{
					Console.WriteLine("T(n) = c1*n^" + c + " + n^" + c + "*log" + b + "(n)");
				}
				else 
				{
					Console.WriteLine("T(n) = c1*n^" + "log" + b + "(" + a + ")" + m + "*n");
				}
			
			}
		}
	}
}


