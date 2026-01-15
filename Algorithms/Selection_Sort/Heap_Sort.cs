using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Sorting_Algorithms
{
    static internal class Heap_Sort<T> where T : IComparable<T>
    {
        public static T[] SortSet(T[] data, DataHandler<T> valueHandler, Clock clock)
        {
            //  It is an optimized version of selection sort.
            //  The algorithm repeatedly finds the maximum(or minimum) element and swaps it with the last(or first) element.
            //  Using a binary heap allows efficient access to the max(or min) element in O(log n) time instead of O(n).
            //  The process is repeated for the remaining elements until the array is sorted.
            //  Overall, Heap Sort achieves a time complexity of O(n log n).

            int n = data.Length;

            // Build heap (rearrange vector)
            for (int i = n / 2 - 1; i >= 0 && !clock.IsElapsed(); i--)
            {
                Heapify(data, n, i, clock);
                //clock.RepeatedShowTime();
            }

            // One by one extract an element from heap
            for (int i = n - 1; i > 0 && !clock.IsElapsed(); i--)
            {
                //clock.RepeatedShowTime();
                // Move current root to end
                T temp = data[0];
                data[0] = data[i];
                data[i] = temp;

                // Call max heapify on the reduced heap
                Heapify(data, i, 0, clock);
            }


            return data;
        }

        static void Heapify(T[] data, int n,int i, Clock clock)
        {

            // Initialize largest as root
            int largest = i;

            // left index = 2*i + 1
            int l = 2 * i + 1;

            // right index = 2*i + 2
            int r = 2 * i + 2;

            // If left child is larger than root
            if (l < n && data[l].CompareTo(data[largest]) > 0)
                largest = l;

            // If right child is larger than largest so far
            if (r < n && data[r].CompareTo(data[largest]) > 0)
                largest = r;

            // If largest is not root
            if (largest != i)
            {
                T temp = data[i];
                data[i] = data[largest];
                data[largest] = temp;

                // Recursively heapify the affected sub-tree
                if (!clock.IsElapsed())
                {
                    Heapify(data, n, largest, clock);
                }
                //Heapify(data, n, largest, valueHandler);
            }
        }
    }
}
