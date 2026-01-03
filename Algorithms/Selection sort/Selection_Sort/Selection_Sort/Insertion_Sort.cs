using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    static internal class Insertion_Sort<T> where T : IComparable<T>
    {
        public static T[] SortSet(T[] data, DataHandler<T> valueHandler, Clock clock)
        {
            //  Start with the second element as the first element is assumed to be sorted.
            //  Compare the second element with the first if the second is smaller then swap them.
            //  Move to the third element, compare it with the first two, and put it in its correct position
            //  Repeat until the entire array is sorted.
            for(int currentIndex = 1; currentIndex < data.Length && !clock.IsElapsed(); currentIndex++)
            {
                for(int swappedIndex = currentIndex; swappedIndex > 0; swappedIndex--)
                {
                    if (valueHandler.CompareValue(data[swappedIndex], data[swappedIndex-1]))
                    {
                        T temp = data[swappedIndex];
                        data[swappedIndex] = data[swappedIndex - 1];
                        data[swappedIndex - 1] = temp;
                    }
                }
                clock.RepeatedShowTime();
            }
            

            return data;
        }
    }
}
