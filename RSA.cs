using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace RSA
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int p = (int)PrimeNumbers();
			int q = (int)PrimeNumbers();
			//Console.Write("Type your first 3-digits prime number: ");
			//p = int.Parse(Console.ReadLine());
			//Console.Write("Type your second 3-digits prime number: ");
			//q = int.Parse(Console.ReadLine());
			int z = p * q;

			int phi = (p - 1) * (q - 1);
			int n = GenerateN(phi);
			int[] arr;
			if (n < phi)
			{
				arr = ExtendedEuclid(n, phi);
			}
			else
			{
				arr = ExtendedEuclid(phi, n);
			}

			Console.WriteLine("p = " + p);
			Console.WriteLine("q = " + q);
			Console.WriteLine("z = " + z);
			Console.WriteLine("phi = " + phi);
			Console.WriteLine("n = " + n);

			//find s
			int s = arr[0];

			if (s < 0)
			{
				s += phi;
			}

			Console.WriteLine(s);
			int a = 707;
			int c = expomod(a, n, z);
			Console.WriteLine(c);
			Console.WriteLine(s);
			Console.WriteLine(z);
			int m = expomod(c, s, z);

			Console.WriteLine("c = " + c);
			Console.WriteLine("m = " + m);


			StreamReader text = new StreamReader("/Users/seobin/Desktop/hp.txt");
			List<int> i = new List<int>();

			for (int aa = 0; aa < text.BaseStream.Length; aa++)
			{
				i.Add(text.Read());
			}

			//encrypt the text
			for (int b = 0; b < i.Count; b++)
			{
				i[b] = (int)expomod(i[b], n, z);
			}

			Console.WriteLine(String.Join(" ", i));


			//decrypt the text
			for (int b = 0; b < i.Count; b++)
			{
				i[b] = (int)expomod(i[b], s, z);
			}

			//ASCII TO TEXT
			List<string> answer = new List<string>();
			foreach(int j in i)
			{
				answer.Add(((char)j).ToString());
			}

			//print out the REAL MESSAGE
			String mess = String.Join("", answer);
			Console.WriteLine("MESSAGE: ");
			Console.WriteLine(mess);

			Console.ReadLine();
			//Console.WriteLine(Euclid(2, 3));
			//Console.WriteLine(ExtendedEuclid(2, 10)[0]); 


		}
		//Fermat's little Theorem 
		public static int expomod (int a, int n, int z) //a^n mod z
		{
			int i = n;
			int rrrr = 1;
			int x = a % z;

			while(i > 0)
			{
				if (i % 2 == 1) // if i is odd, then
				{
					rrrr = (rrrr * x)% z;

				}
				x = (int)Math.Pow(x,2) % z;
				i = i / 2;
			}
			return rrrr;
		}

		//Check whether the number are prime or not
		public static Boolean checkPrime(int a, int n)
		{
			if((expomod(a,n-1,n) == 1)) //
			{
				return true;
			}
			   else {
				return false;
			}
		}

		//Euclid Method
		public static int Euclid(int a, int b)
		{
			if (b == 0)
			{
				return a;
			}
			return Euclid(b, a % b);
		}

		//Extended-Euclid
		public static int[] ExtendedEuclid(int a, int b)
		{
			int[] xyd = new int[3]; 
			if (b == 0)
			{
				xyd = new int[] { 1, 0, a }; //return array with {}
				return xyd;
			}
			xyd = ExtendedEuclid(b, a % b);
			int x = xyd[0];
			int y = xyd[1];
			int d = xyd[2];
			xyd = new int[] { y, x - ((a/b) * y), d };
			//Console.WriteLine(String.Join(" ", xyd));
			return xyd;
		}

		//Generate Prime Numbers
		public static Random r = new Random();
		public static int PrimeNumbers()
		{
			while (true)
			{
				int p = r.Next(100,200);
				Console.WriteLine(p);
				int count = 0;
				for (int a = 2; a < p; a++)
				{
					if (!checkPrime(p, a))
					{
						count++;
						//Console.WriteLine(count);
					}else{
						return p;
					}
				}
				if (count == 0)
				{
					Console.WriteLine("hi");
					return p;
				}

			}
		}

		//Generate n 
		public static int GenerateN(int phi)
		{
			while (true)
			{
				int n = r.Next(2, phi);
				if(Euclid(n,phi) == 1)
				{
					return n;
				}
			}
		}


	}
}