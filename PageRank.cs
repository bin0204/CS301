using System;
using System.Numerics;
using System.Collections.Generic;


namespace PageRank
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//TYPE ALPHA VALUE
			Console.Write("Alpha Value:");
			double a = double.Parse(Console.ReadLine());
			//Console.Write("Please Enter r(k) Value:");
			//double input = double.Parse(Console.ReadLine());

			//Construct matrices
			//An array with 7 rows and 7 columns
			//Console.WriteLine("----------S----------");
			double[,] S = new double[7, 7] {
				{0,0,0,0,0,1/7d,0},
				{1,0,0,0,0,1/7d,0},
				{0,1/3d,0,0,0,1/7d,0},
				{0,1/3d,0,0,0,1/7d,1},
				{0,1/3d,1,1,0,1/7d,0},
				{0,0,0,0,1,1/7d,0},
				{0,0,0,0,0,1/7d,0}
			};

			//Console.Write("\tA\tB\tC\tD\tE\tF\tG\n\n");

			//Outer loop for rows
			//for (int i = 0; i < S.GetLength(0); i++)
			//{
			//	//inner loop for columns
			//	for (int j = 0; j < S.GetLength(1); j++)
			//	{
			//		//Console.Write("\t\" + S[i, j]);
			//		Console.WriteLine("\t" + S[i,j]);
			//	}
			//	Console.WriteLine("\n===================================================================");

			//}

			//Console.WriteLine("----------1/7*e*eT----------");
			//Console.WriteLine("\n");
			//1/7*e*e^T

			double[,] eeT = new double[7, 7] {
				{1/7d,1/7d,1/7d,1/7d,1/7d,1/7d,1/7d},
				{1/7d,1/7d,1/7d,1/7d,1/7d,1/7d,1/7d},
				{1/7d,1/7d,1/7d,1/7d,1/7d,1/7d,1/7d},
				{1/7d,1/7d,1/7d,1/7d,1/7d,1/7d,1/7d},
				{1/7d,1/7d,1/7d,1/7d,1/7d,1/7d,1/7d},
				{1/7d,1/7d,1/7d,1/7d,1/7d,1/7d,1/7d},
				{1/7d,1/7d,1/7d,1/7d,1/7d,1/7d,1/7d}
			};

			double[] rZero = new double[7] { 1 / 7d, 1 / 7d, 1 / 7d, 1 / 7d, 1 / 7d, 1 / 7d, 1 / 7d };
			//Console.Write("\tA\tB\tC\tD\tE\tF\tG\n\n");
			//for (int i = 0; i < S.GetLength(0); i++)
			//{
			//	//inner loop for columns
			//	for (int j = 0; j < S.GetLength(1); j++)
			//	{
			//		//Console.Write("\t\" + eeT[i, j]);
			//		Console.WriteLine("\t" + eeT[i,j]);
			//	}
			//	Console.WriteLine("\n===================================================================");

			//}

			//Console.ReadLine();


			//Calculate G
			//G = a*S + (1 - a)*1/7*e*eT
			//left side

			//right side
			//Matrix multiplication

			//Console.WriteLine("RIGHT SIDE");
			double[,] rightSide = new double[7, 7];
			for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 7; j++)
				{

					rightSide[i, j] = (1 - a) * eeT[i, j];
					Console.Write(rightSide[i, j] + " ");
				}
				Console.WriteLine();
			}

			//Console.WriteLine("LEFT SIDE");
			double[,] leftSide = new double[7, 7];
			for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 7; j++)
				{

					leftSide[i, j] = a * S[i, j];
					Console.Write(leftSide[i, j] + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine("Alpha:" + a);
			Console.WriteLine("--------G---------");
			Console.WriteLine("\n");

			double[,] result = new double[7, 7];
			for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 7; j++)
				{

					result[i, j] = leftSide[i, j] + rightSide[i, j];
					Console.Write("\t" + Math.Round(result[i, j],3) + " ");
				}
				Console.WriteLine();
			}

			//r(k) = G^k*r(0) until 20
			//Console.WriteLine("--------r(k)---------");
			//Console.WriteLine("\n");
			//double[] val = matrixMultiplication(result,rZero);
			//computeR(val);
			//realRs(result, rZero);

		}


		//Matrix multipliation for r(k)
		public static double[] matrixMultiplication(double[,] result, double[] rZero)
		{
			double[] m = new double[7];
			double t = 0;
			for (int i = 0; i< result.GetLength(0); i++)
			{
				for (int j = 0; j < result.GetLength(1); j++)
				{
					t += result[i, j] * rZero[j];
				}
				m[i] = t;
				t = 0.0;
			}
			return m;
		}
		//r(1)
		public static void computeR(double[] m)
		{
			for (int i = 0; i < m.GetLength(0); i++)
			{
				
				Console.WriteLine(m[i]);
			}
		}

		//Calculate r^k

		public static void realRs(double[,] rR, double[] rZero)
		{
			List<double[]> arr = new List<double[]>();
			arr.Add(rZero);
			for (int i = 0; i < 40; i++)
			{
				arr.Add(matrixMultiplication(rR, arr[i]));
				//Console.Write("r" i + ": ");
				computeR(arr[i]);
				Console.WriteLine();


			}

		}
	}
}
