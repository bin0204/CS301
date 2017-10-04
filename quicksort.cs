using System;

namespace QuickSort
{
    class MainClass
    {
        static public int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                left++;
                
                while (numbers[right] > pivot)
                right--;
                
                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
                Console.WriteLine("QuickSort Steps: " + string.Join(" ", numbers));
            }
            
        }
        
        static public void QuickSort_Recursive(int[] arr, int left, int right)
        {
            // For Recusrion
            if (left < right)
            {
                int pivot = Partition(arr, left, right);
                
                if (pivot > 1)
                QuickSort_Recursive(arr, left, pivot - 1);
                
                if (pivot + 1 < right)
                QuickSort_Recursive(arr, pivot + 1, right);
            }
        }
        
        static void Main(string[] args)
        {
            //int[] numbers = { 1, 6, 4, 7, 9, 8, 3, 2, 5 };
            int[] numbers = { 3, 7, 9, 2, 4, 1, 3, 5, 2 };
            int len = numbers.Length;
            //Console.WriteLine("FIRSTLIST: { 1, 6, 4, 7, 9, 8, 3, 2, 5 }");
            Console.WriteLine("SECONDLIST: { 3, 7, 9, 2, 4, 1, 3, 5, 2 }");
            QuickSort_Recursive(numbers, 0, len - 1);
            //for (int i = 0; i < 9; i++)
            //	Console.WriteLine(numbers[i]);
            Console.WriteLine("QuickSort Steps: " + string.Join(" ", numbers));
            Console.ReadLine();
            
        }
        
    }
}
