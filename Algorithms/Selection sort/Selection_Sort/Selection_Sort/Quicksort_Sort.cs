using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection_Sort
{
    static internal class Quicksort_Sort<T> where T : IComparable<T>
    {
        // partition function
        static int partition(T[] arr, int low, int high)
        {
            int mid = low + (high - low) / 2;
            // choose the pivot

            swap(arr, mid, high);

            T pivot = arr[high];


            // index of smaller element and indicates 
            // the right position of pivot found so far
            int i = low - 1;

            // traverse arr[low..high] and move all smaller
            // elements to the left side. Elements from low to 
            // i are smaller after every iteration
            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    swap(arr, i, j);
                }
            }

            // move pivot after smaller elements and
            // return its position
            swap(arr, i + 1, high);
            return i + 1;
        }

        // swap function
        static void swap(T[] arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // The QuickSort function implementation
        public static void quickSort(T[] arr, int low, int high, Clock clock)
        {
            while (low < high && !clock.IsElapsed())
            {

                // pi is the partition return index of pivot
                int pi = partition(arr, low, high);

                // recursion calls for smaller elements
                // and greater or equals elements

                //quickSort(arr, low, pi - 1, clock);
                //quickSort(arr, pi + 1, high, clock);

                if (pi - low < high - pi)
                {
                    quickSort(arr, low, pi - 1, clock);
                    low = pi + 1; // Loop handles the right side
                }
                else
                {
                    quickSort(arr, pi + 1, high, clock);
                    high = pi - 1; // Loop handles the left side
                }
            }
        }

        //static void Main(string[] args)
        //{
        //    int[] arr = { 10, 7, 8, 9, 1, 5 };
        //    int n = arr.Length;

        //    quickSort(arr, 0, n - 1);
        //    foreach (int val in arr)
        //    {
        //        Console.Write(val + " ");
        //    }
        //}
    }
}
