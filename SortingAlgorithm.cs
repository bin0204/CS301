using System;
using System.Linq;

namespace SortingAlgorithm
{
	class MainClass
	{
		static void blah()
		{
		}
		public static void Main(string[] args)
		{
			//Declare an array
			int[] arr = new int[] { 1, 6, 4, 7, 9, 8, 3, 2, 5 }; // 9 size array
			int[] arr2 = new int[] { 3, 7, 9, 2, 4, 1, 3, 5, 2 };


			//Read the file as an string
			String[] text = System.IO.File.ReadAllLines("/Users/bin/Desktop/C#/SortingAlgorithm/list.csv");
			int[] textArr = Array.ConvertAll(text, int.Parse);
			int[] sortedText = Array.ConvertAll(text, int.Parse);
			Array.Sort(sortedText);
		

			//do 
			//statement
			//while (expression)
			//if expression is true, the loop is executed again.
			//if expression is false, the loop is terminated

			bool swapped = false;

			//First Bubble Sort
			do
			{
				swapped = false;
				//arr.Length - total number of elements in arr
				for (int j = 1; j < arr.Length; j++)
				{
					for (int i = 1; i < arr.Length; i++)
					{
						if (arr[i - 1] > arr[i])
						{
							int temp = arr[i];
							arr[i] = arr[i - 1];
							arr[i - 1] = temp;
							swapped = true;
							Console.WriteLine("First Bubble Sort: " + string.Join(" ", arr));
							Console.Read();
						}
					}
				}
				Console.WriteLine("First Bubble Sort Answer: " + string.Join(" ", arr) + "\r\n");
			} while (swapped == false);


			//Second Bubble Sort
			do
			{
				swapped = false;
				//arr.Length - total number of elements in arr
				for (int j = 1; j < arr2.Length; j++)
				{
					for (int i = 1; i < arr2.Length; i++)
					{
						if (arr2[i - 1] > arr2[i])
						{
							int temp = arr2[i];
							arr2[i] = arr2[i - 1];
							arr2[i - 1] = temp;
							swapped = true;
							Console.WriteLine("Second Bubble Sort: " + string.Join(" ", arr2));
							Console.Read();
						}
					}
				}
				Console.WriteLine("Second Bubble Sort Answer: " + string.Join(" ", arr2) + "\r\n");
			} while (swapped == false);

			//Bubble Sort - Compare textfile with sorted textfile
			do
			{
				swapped = false;
				//arr.Length - total number of elements in arr
				for (int j = 1; j < textArr.Length; j++)
				{
					for (int i = 1; i < textArr.Length; i++)
					{
						if (textArr[i - 1] > textArr[i])
						{
							int temp = textArr[i];
							textArr[i] = textArr[i - 1];
							textArr[i - 1] = temp;
							swapped = true;
							//Console.WriteLine("First Bubble Sort: " + string.Join(" ", textArr));
							//Console.Read();
						}
					}
				}
				Console.WriteLine("TextFile Bubble Sort Answer: " + string.Join(" ", textArr) + "\r\n");
			} while (swapped == false);

			Console.WriteLine(textArr.SequenceEqual(sortedText));
			Console.Read();

			//Insertion Sort
			//Declare an array
			int[] inarr = new int[] { 1, 6, 4, 7, 9, 8, 3, 2, 5 }; // 9 size array
			int[] inarr2 = new int[] { 3, 7, 9, 2, 4, 1, 3, 5, 2 };


			for (int i = 1; i < inarr.Length + 1; i++)
			{
				int x = inarr[i - 1];
				int j = i - 1;

				while ((j > 0) && x < inarr[j - 1])
				{
					inarr[j] = inarr[j - 1];
					j = j - 1;
					Console.WriteLine("First Insertion Sort: " + string.Join(" ", inarr));
					Console.Read();
				}
				inarr[j] = x;
				Console.WriteLine("First Insertion Sort: " + string.Join(" ", inarr));
				Console.Read();
			}
			Console.WriteLine("First Insertion Sort Answer: " + string.Join(" ", inarr));
			Console.Read();


			for (int i = 1; i < inarr2.Length + 1; i++)
			{
				int x = inarr2[i - 1];
				int j = i - 1;

				while ((j > 0) && x < inarr2[j - 1])
				{
					inarr2[j] = inarr2[j - 1];
					j = j - 1;
					Console.WriteLine("Second Insertion Sort: " + string.Join(" ", inarr2));
					Console.Read();
				}
				inarr2[j] = x;
				Console.WriteLine("Second Insertion Sort: " + string.Join(" ", inarr2));
				Console.Read();
			}
			Console.WriteLine("Second Insertion Sort Answer: " + string.Join(" ", inarr2));
			Console.Read();

			//Insertion - Compare textfile with sorted textfile
			for (int i = 1; i < textArr.Length + 1; i++)
			{
				int x = textArr[i - 1];
				int j = i - 1;

				while ((j > 0) && x < textArr[j - 1])
				{
					textArr[j] = textArr[j - 1];
					j = j - 1;
					//Console.WriteLine("Second Insertion Sort: " + string.Join(" ", textArr));
					//Console.Read();
				}
				textArr[j] = x;
				//Console.WriteLine("Second Insertion Sort: " + string.Join(" ", textArr));
				//Console.Read();
			}
			Console.WriteLine("TextFile Insertion Sort Answer: " + string.Join(" ", textArr));
			Console.Read();

			Console.WriteLine(textArr.SequenceEqual(sortedText));
			Console.Read();

			//Selection Sort
			//Declare an array
			int[] selarr = new int[] { 1, 6, 4, 7, 9, 8, 3, 2, 5 }; // 9 size array
			int[] selarr2 = new int[] { 3, 7, 9, 2, 4, 1, 3, 5, 2 };

			for (int i = 0; i < selarr.Length - 1; i++) 
			{
				int minj = i;
				int minx = selarr[i];

				for (int j = i + 1; j < selarr.Length - 1; j++) 
				{
					if (selarr[j] < minx) 
					{
						minj = j;
						minx = selarr[j];
					}

				}
				selarr[minj] = selarr[i];
				selarr[i] = minx;
				Console.WriteLine("First Selection Sort: " + string.Join(" ", selarr));
				Console.Read();
			}
			Console.WriteLine("First Selection Sort Answer: " + string.Join(" ", selarr));
			Console.Read();

			for (int i = 0; i < selarr2.Length -1; i++)
			{
				int minj = i; 
				int minx = selarr2[i];

				for (int j = i + 1; j < selarr2.Length - 1; j++)
				{
					if (selarr2[j] < minx)
					{
						minj = j;
						minx = selarr2[j];
					}

				}
				selarr2[minj] = selarr2[i];
				selarr2[i] = minx;
				Console.WriteLine("Second Selection Sort Sort: " + string.Join(" ", selarr2));
				Console.Read();
			}
			Console.WriteLine("Second Selection Sort Answer: " + string.Join(" ", selarr2));
			Console.Read();

			//Selection - Compare textfile with sorted textfile
			for (int i = 0; i < textArr.Length - 1; i++)
			{
				int minj = i;
				int minx = textArr[i];

				for (int j = i + 1; j < textArr.Length - 1; j++)
				{
					if (textArr[j] < minx)
					{
						minj = j;
						minx = textArr[j];
					}

				}
				textArr[minj] = textArr[i];
				textArr[i] = minx;
				//Console.WriteLine("Second Selection Sort Sort: " + string.Join(" ", textArr));
				//Console.Read();
			}
			Console.WriteLine("TextFile Selection Sort Answer: " + string.Join(" ", textArr));
			Console.Read();

			Console.WriteLine(textArr.SequenceEqual(sortedText));
			Console.Read();

			//for (int i = 0; i <)
			//int[] arr1 = new int[] { 1, 2, 3 };
			//int[] arr2 = new int[] { 3, 2, 1 };

			//Console.WriteLine(arr1.SequenceEqual(arr2)); // false
			//Console.WriteLine(arr1.Reverse().SequenceEqual(arr2)); // true

		}
	}
}
