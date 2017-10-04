using System;
using System.Collections.Generic;
using System.Text;
namespace prog
{
    class Program
    {
        static public void mergemethod(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }
            Console.WriteLine("MergeSort steps: " + string.Join(" ", numbers));
            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];
            Console.WriteLine("MergeSort steps: " + string.Join(" ", numbers));
            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];
            Console.WriteLine("MergeSort steps: " + string.Join(" ", numbers));
            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
            Console.WriteLine("MergeSort steps: " + string.Join(" ", numbers));
        }
        static public void sortmethod(int[] numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                sortmethod(numbers, left, mid);
                sortmethod(numbers, (mid + 1), right);
                mergemethod(numbers, left, (mid + 1), right);
            }
            Console.WriteLine("MergeSort steps: " + string.Join(" ", numbers));
        }
        static void Main(string[] args)
        {
            int[] numbers = { 1, 6, 4, 7, 9, 8, 3, 2, 5 };
            int len = numbers.Length;
            Console.WriteLine("List1: { 1, 6, 4, 7, 9, 8, 3, 2, 5 }");
            sortmethod(numbers, 0, len - 1);
            //for (int i = 0; i < 9; i++)
             //   Console.WriteLine(numbers[i]);
            Console.WriteLine("MergeSort steps: " + string.Join(" ", numbers));
            Console.ReadLine();
        }
    }
}