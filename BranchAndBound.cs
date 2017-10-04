using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// source
// http://www.geeksforgeeks.org/branch-and-bound-set-4-n-queen-problem/
// C# program to solve N Queen problem using Branch and Bound
//n-queens
namespace BranchBound
{
	class Program
	{

		static int n = 15;

		static void Main(String[] args)
		{
			Console.WriteLine("n = " + n);
			Console.WriteLine("*************************8");
			solveNumQueens(n);
			Console.ReadLine();
		}

		static void printOutput(int[,] table)
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
					Console.Write(" " + table[i, j] + " ");
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		static bool notCheckMate(int[,] table, int row, int col)
		{
			for (int i = 0; i < col; i++)
				if (table[row, i] == 1)
					return false;

			for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
				if (table[i, j] == 1)
					return false;

			for (int i = row, j = col; j >= 0 && i < n; i++, j--)
				if (table[i, j] == 1)
					return false;
			return true;
		}

		static bool solveNumQueensUtil(int[,] table, int col)
		{
			if (col == n)
			{
				printOutput(table);
				return true;
			}

			for (int i = 0; i < n; i++)
			{
				if (notCheckMate(table, i, col))
				{
					table[i, col] = 1;
					solveNumQueensUtil(table, col + 1);
					table[i, col] = 0;
				}
			}
			return false;
		}

		static void solveNumQueens(int k)
		{
			int[,] table = new int[k, k];
			for (int i = 0; i < k; i++)
			{
				for (int j = 0; j < k; j++)
				{
					table[i, j] = 0;

				}
			}

			if (solveNumQueensUtil(table, 0))
			{
				Console.WriteLine("There is no solution");
			}
		}
	}
}