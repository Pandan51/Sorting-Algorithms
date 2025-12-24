using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Selection_Sort
{
    static public class Selection_Sort
    {
        public static string[] SortWordSet(string[] data, DataHandler<string> wordHandler, Clock clock)
        {
            int lowestNumIndex;

            for (int swapIndex = 0; swapIndex < data.Length && !clock.IsElapsed(); swapIndex++)
            {
                lowestNumIndex = swapIndex;
                for (int comparedIndex = swapIndex + 1; comparedIndex < data.Length && !clock.IsElapsed(); comparedIndex++)
                {
                    if (wordHandler.WordIsBigger(data[comparedIndex], data[lowestNumIndex]))
                    {
                        lowestNumIndex = comparedIndex;
                    }

                }
                if (swapIndex != lowestNumIndex)
                {
                    string temp = data[lowestNumIndex];
                    data[lowestNumIndex] = data[swapIndex];
                    data[swapIndex] = temp;
                }
                //dataHandler.DisplayData(data);
                Console.Clear();
                clock.ShowTime();
                Console.WriteLine(clock.IsElapsed());
            }

            return data;
        }

        public static double[] SortNumSet(double[] data, DataHandler<double> wordHandler, Clock clock)
        {
            int lowestNumIndex;

            for (int swapIndex = 0; swapIndex < data.Length && !clock.IsElapsed(); swapIndex++)
            {
                lowestNumIndex = swapIndex;
                for (int comparedIndex = swapIndex + 1; comparedIndex < data.Length && !clock.IsElapsed(); comparedIndex++)
                {
                    if (wordHandler.NumIsBigger(data[comparedIndex], data[lowestNumIndex]))
                    {
                        lowestNumIndex = comparedIndex;
                    }

                }
                if (swapIndex != lowestNumIndex)
                {
                    double temp = data[lowestNumIndex];
                    data[lowestNumIndex] = data[swapIndex];
                    data[swapIndex] = temp;
                }
                //dataHandler.DisplayData(data);
                Console.Clear();
                clock.ShowTime();
                Console.WriteLine(clock.IsElapsed());
            }

            return data;
        }
    }
}
