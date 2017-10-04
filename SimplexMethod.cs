using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Simplex
{
	class Program
	{
		static void Main(string[] args)
		{
			int row = 0;
			string line;
            //using feasible_mu0_1.csv file
			double[,] info = new double[25, 55];
			using (StreamReader file = new StreamReader(@"/Users/seobin/Desktop/ComputationalFinanceData/feasible_mu0_1.csv"))
			{
				while ((line = file.ReadLine()) != null)
				{
                    //split "line" by commas and cast to an int, put them into array
					double[] nums = line.Split(',').Select(double.Parse).ToArray();
					for (int i = 0; i < nums.Length; i++)
					{
                        //add values to 2Dimentional array one row
						info[row, i] = nums[i];
					}
					row++;
				}
				file.Close();
				Console.ReadLine();
			}
            //**********************
			printOutMatrix(info);

            //**********************
			int count = 1;
			List<int> rowValues = new List<int>();
			List<int> colValues = new List<int>();

            //when it has a negative number on the bottom row of matrix, then do following operations
			while (checkBottom(info))
			{
				int maxColIndexValue = getPivotColumn(info);
				Console.WriteLine("Initial matrix" + count);
				Console.WriteLine("Pivot Column: " + maxColIndexValue);//biggest column value

				int minRowIndexValue = getPivotRow(info, maxColIndexValue);
				Console.WriteLine("Pivot Row: " + minRowIndexValue);//smallest row value

				info = rowOperations(info, minRowIndexValue, maxColIndexValue);
				printOutMatrix(info);
				Console.WriteLine();
				count++;
				if (maxColIndexValue >= 7)
				{
					rowValues.Add(minRowIndexValue);                  //to get x vals or something
					colValues.Add(maxColIndexValue);
				}
			}
			convertMatrix(info);

			List<double> xVal = xVals(info, rowValues, colValues);
			Console.Write("x values: ");
			for (int i = 0; i < xVal.Count - 1; i++)
			{
				Console.Write(xVal[i]);
			}
			Console.WriteLine("");
		}


		public static List<double> xVals(double[,] matrix, List<int> row, List<int> col)
		{
			List<double> values = new List<double>();
			for (int i = 0; i < 7; i++)
			{
				if (col.Contains(i))
				{
					int index = col.IndexOf(i);
					int colIndex = col[index];
					int rowIndex = row[index];
					double value = matrix[rowIndex, matrix.GetLength(1) - 1];
					values.Add(value);
				}
				else
				{
					values.Add(0);
				}
			}
			return values;
		}

		//METHODS

        //check all bottom row is negative or not
		public static bool checkBottom(double[,] matrix)
		{
			bool bottom = false;
			for (int i = 0; i < matrix.GetLength(1); i++)
			{
				if (matrix[matrix.GetLength(0) - 1, i] > 0)
				{
					bottom = true;
				}
			}
			return bottom;
		}

		public static double[,] rowOperations(double[,] matrix, int pivotRow, int pivotCol)
		{
			matrix = div(matrix, pivotRow, matrix[pivotRow, pivotCol]);
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				if (i != pivotRow)
				{
					matrix = sub(matrix, i, pivotRow, matrix[i, pivotCol]);
				}
			}
			return matrix;
		}
		//subtract Product Of Pivot RowValue And Current Pivot Column Value From Current Row Index
		public static double[,] sub(double[,] matrix, int row, int pivotRow, double pivotValue)
		{
			for (int i = 0; i < matrix.GetLength(1); i++)
			{
				matrix[row, i] = matrix[row, i] - (matrix[pivotRow, i] * pivotValue);
			}
			return matrix;
		}
		//divide row by pivot
		public static double[,] div(double[,] matrix, int row, double pivotValue)
		{
			for (int i = 0; i < matrix.GetLength(1); i++)
			{
				matrix[row, i] = matrix[row, i] / pivotValue;
			}
			return matrix;
		}
		public static int getPivotRow(double[,] matrix, int col)
		{
			//Console.WriteLine(col);
			int pivotRow = 0;
			//double min = matrix[0, col] / matrix[0, matrix.GetLength(1) - 1]; //in terms of the ratio.  number in column / last number in row
			//first row, max column  / first row, last column
			double min = int.MaxValue;

			for (int i = 0; i < matrix.GetLength(0) - 1; i++)
			{
				double rhs = matrix[i, matrix.GetLength(1) - 1];            //furthest "right hand side" value
				double next = rhs / matrix[i, col];                         //set first number as next initially
				if (i == 0 && next >= 0)
				{
					min = next;
					//Console.WriteLine("min = " + min);
				}
				else if (next <= min && next >= 0)
				{                                                           //if the "next" number is less than the min value (a temp variable)
					min = next;                                             //the next value is the new min value
					pivotRow = i;                                           //the row index is set
																			//Console.WriteLine("actual min = " + min);
				}
			}
			return pivotRow;
		}

		public static int getPivotColumn(double[,] matrix)
		{
			double max = matrix[matrix.GetLength(0) - 1, 0];                   //set initial maximum pivot column index as the second to last. don't do -1 because you don't want to include the last column value(RHS)
			int pivotColumn = 0;
			for (int i = 0; i < matrix.GetLength(1) - 1; i++)//don't include last value in row since it's the RHS so subtract 1.
			{                                                               //for each column
				if (matrix[matrix.GetLength(0) - 1, i] > max)                  //if the value of the last row of a certain column is greater than the "max" value (arbitrarily set to the first row value)
				{
					max = matrix[matrix.GetLength(0) - 1, i];                 //then set the max value to the last row, current column value
					pivotColumn = i;                                                //set index
				}
			}
			return pivotColumn;

		}
		//****************************************************************************************************************************************************************************************
		public static void printOutMatrix(double[,] c)
		{
			for (int i = 0; i < c.GetLength(0); i++)
			{
				for (int j = 0; j < c.GetLength(1); j++)
				{
					Console.Write(Math.Round(c[i, j], 3) + " ");                 //round the numbers
				}
				Console.WriteLine("");
			}
		}
		//write matrix to file
		public static void convertMatrix(double[,] matrix)
		{
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"/Users/seobin/Desktop/ComputationalFinanceData/result.csv"))
			{
				for (int i = 0; i < matrix.GetLength(0); i++)
				{
					for (int j = 0; j < matrix.GetLength(1); j++)
					{
						//file.Write(Math.Round(matrix[i, j], 15) + " ");                 //round the numbers
						file.Write(matrix[i, j] + ",");
					}
					file.WriteLine();
				}
			}
		}
	}
}
