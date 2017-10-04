using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 6, 4, 7, 9, 8, 3, 2 ,5 };
            HeapSort hs = new HeapSort();
            hs.PerformHeapSort(arr);
            Console.ReadLine();
        }
    }
    class HeapSort
    {
        private int heapSize;

        private void BuildHeap(int[] arr)
        {
            heapSize = arr.Length - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(arr, i);
            }
            Console.WriteLine(string.Join(" ", arr));
        }

        private void Swap(int[] arr, int x, int y)//function to swap elements
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
            Console.WriteLine(string.Join(" ", arr));
        }
        private void Heapify(int[] arr, int index)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int largest = index;

            if (left <= heapSize && arr[left] > arr[index])
            {
                largest = left;
                Console.WriteLine(string.Join(" ", arr));
            }

            if (right <= heapSize && arr[right] > arr[largest])
            {
                largest = right;
                Console.WriteLine(string.Join(" ", arr));
            }

            if (largest != index)
            {
                Swap(arr, index, largest);
                Heapify(arr, largest);
                Console.WriteLine(string.Join(" ", arr));
            }
        }
        public void PerformHeapSort(int[] arr)
        {
            BuildHeap(arr);
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                heapSize--;
                Heapify(arr, 0);
            }
            Console.WriteLine(string.Join(" ", arr));
            //DisplayArray(arr);
        }
        /*private void DisplayArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            { Console.Write("{0}", arr[i]); }
        }*/
        
    }
}
