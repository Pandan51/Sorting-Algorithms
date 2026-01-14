using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    static internal class Quicksort_Sort<T> where T : IComparable<T>
    {
        // partition function
        /// <summary>
        /// Optimized QuickSort using Hoare Partitioning and Tail Recursion.
        /// Specifically designed to handle 10M+ items and duplicate values.
        /// </summary>
        public static void SortSet(T[] arr, int low, int high, Clock clock)
        {
            while (low < high && !clock.IsElapsed())
            {
                // Median-of-Three: Selects a better pivot and sorts low/mid/high
                int p = PartitionHoare(arr, low, high);

                // Update UI for large partitions
                if ((high - low) > 100000)
                {
                    // ProgressUI.Update(low, arr.Length, clock);
                }

                // Tail Recursion: Always recurse into the smaller side first
                // to keep the stack depth at O(log n).
                if (p - low < high - p)
                {
                    SortSet(arr, low, p, clock);
                    low = p + 1;
                }
                else
                {
                    SortSet(arr, p + 1, high, clock);
                    high = p;
                }
            }
        }

        /// <summary>
        /// Hoare Partitioning is faster and more robust than Lomuto.
        /// It handles duplicate values much more efficiently.
        /// </summary>
        private static int PartitionHoare(T[] arr, int low, int high)
        {
            // 1. True Median-of-Three pivot selection
            int mid = low + (high - low) / 2;
            SortThree(arr, low, mid, high);

            // After SortThree, the middle element is a very safe pivot
            T pivot = arr[mid];

            int i = low - 1;
            int j = high + 1;

            while (true)
            {
                // Move i right as long as elements are smaller than pivot
                do { i++; } while (arr[i].CompareTo(pivot) < 0);

                // Move j left as long as elements are larger than pivot
                do { j--; } while (arr[j].CompareTo(pivot) > 0);

                // If pointers cross, the partition is complete
                if (i >= j) return j;

                swap(arr, i, j);
            }
        }

        /// <summary>
        /// Sorts the first, middle, and last elements.
        /// This creates a pivot that resists "pathological" datasets.
        /// </summary>
        /// 
        private static void SortThree(T[] arr, int a, int b, int c)
        {
            if (arr[a].CompareTo(arr[b]) > 0) swap(arr, a, b);
            if (arr[a].CompareTo(arr[c]) > 0) swap(arr, a, c);
            if (arr[b].CompareTo(arr[c]) > 0) swap(arr, b, c);
        }

        private static void swap(T[] arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
