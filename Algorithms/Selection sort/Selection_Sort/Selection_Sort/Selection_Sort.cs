using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sorting_Algorithms
{
    static public class Selection_Sort<T> where T : IComparable<T>
    {
        public static T[] SortSet(T[] data, DataHandler<T> valueHandler, Clock clock)
        {
            // Index of lowest number
            int lowestNumIndex;

            // swapIndex is the current index which will be swapped with the smallest number
            for (int swapIndex = 0; swapIndex < data.Length && !clock.IsElapsed(); swapIndex++)
            {
                lowestNumIndex = swapIndex;
                for (int comparedIndex = swapIndex + 1; comparedIndex < data.Length && !clock.IsElapsed(); comparedIndex++)
                {
                    // Compare if next number is smaller than current index
                    if (valueHandler.CompareValue(data[comparedIndex], data[lowestNumIndex]))
                    {
                        // If true, the next index is now the smallest
                        lowestNumIndex = comparedIndex;
                    }

                }
                // If not the starting number, switch positions
                if (swapIndex != lowestNumIndex)
                {
                    T temp = data[lowestNumIndex];
                    data[lowestNumIndex] = data[swapIndex];
                    data[swapIndex] = temp;
                }
                //dataHandler.DisplayData(data);
                //Console.Clear();
                //clock.ShowTime();
                //Console.WriteLine(clock.IsElapsed());
                clock.RepeatedShowTime();
            }

            return data;
        }

        //public static string[] SortWordSet(string[] data, DataHandler<string> wordHandler, Clock clock)
        //{
        //    int lowestNumIndex;

        //    for (int swapIndex = 0; swapIndex < data.Length && !clock.IsElapsed(); swapIndex++)
        //    {
        //        lowestNumIndex = swapIndex;
        //        for (int comparedIndex = swapIndex + 1; comparedIndex < data.Length && !clock.IsElapsed(); comparedIndex++)
        //        {
        //            if (wordHandler.WordIsBigger(data[comparedIndex], data[lowestNumIndex]))
        //            {
        //                lowestNumIndex = comparedIndex;
        //            }

        //        }
        //        if (swapIndex != lowestNumIndex)
        //        {
        //            string temp = data[lowestNumIndex];
        //            data[lowestNumIndex] = data[swapIndex];
        //            data[swapIndex] = temp;
        //        }
        //        //dataHandler.DisplayData(data);
        //        Console.Clear();
        //        clock.ShowTime();
        //        Console.WriteLine(clock.IsElapsed());
        //    }

        //    return data;
        //}
        //public static double[] SortNumSet(double[] data, DataHandler<double> numHandler, Clock clock)
        //{
        //    int lowestNumIndex;

        //    for (int swapIndex = 0; swapIndex < data.Length && !clock.IsElapsed(); swapIndex++)
        //    {
        //        lowestNumIndex = swapIndex;
        //        for (int comparedIndex = swapIndex + 1; comparedIndex < data.Length && !clock.IsElapsed(); comparedIndex++)
        //        {
        //            if (numHandler.NumIsBigger(data[comparedIndex], data[lowestNumIndex]))
        //            {
        //                lowestNumIndex = comparedIndex;
        //            }

        //        }
        //        if (swapIndex != lowestNumIndex)
        //        {
        //            double temp = data[lowestNumIndex];
        //            data[lowestNumIndex] = data[swapIndex];
        //            data[swapIndex] = temp;
        //        }

        //        //dataHandler.DisplayData(data);
        //        Console.Clear();
        //        clock.ShowTime();
        //        Console.WriteLine(clock.IsElapsed());
        //    }

        //    return data;
        //}
    }
}
