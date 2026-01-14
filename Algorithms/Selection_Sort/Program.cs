using System.Timers;

// Change to assign type to handlers and algorithms
using DataType = System.Int32; // Change this to System.String when needed

namespace Sorting_Algorithms
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Type of handler
            DataHandler<DataType> dataHandler = new DataHandler<DataType>();
            //DataHandler<string> dataHandler = new DataHandler<string>();

            // Filename of dataset
            // string filename = "random_words_10M.txt";
             string filename = "random_integers_10M.txt";
            // string filename = "number_10K.txt";
            // string filename = "number_200.txt";
            // string filename = "number_test.txt";

            // Parse Data
            dataHandler.ParseData(filename);
            // Timer - 1 hour
            // (Interval v ms, doba trvání sortování v ms)
            Clock clock = new Clock(1000,1000*60*60);
            //Console.WriteLine(clock.GetTime());


            DataType[] data = dataHandler.GetData();



            double beforeSortAccuracy = dataHandler.CalculateAccuracy(data);
            Console.WriteLine("Press to start");
            Console.ReadKey();
            // Selection sort
            // Timer
            clock.StartClock();


            //Algoritmy

            // data = Selection_Sort<DataType>.SortSet(data, dataHandler, clock);
            // data = Bubble_Sort<DataType>.SortSet(data, dataHandler, clock);
            // data = Insertion_Sort<DataType>.SortSet(data, dataHandler, clock);
            // data = Heap_Sort<DataType>.SortSet(data, dataHandler, clock);
            // Merge_Sort<DataType>.SortSet(data, 0, data.Length - 1);
            // Quicksort_Sort<DataType>.SortSet(data, 0, data.Length - 1, clock);
            // Radix_Sort<DataType>.SortSet(data, clock);
            



            Console.WriteLine("End of sorting");
            Console.WriteLine("\nTime:");
            clock.ShowTime();
            double afterSortAccuracy = dataHandler.CalculateAccuracy(data);
            Console.WriteLine($"Results of sorting is {beforeSortAccuracy} % before sorting to {afterSortAccuracy} % after.");
            Console.WriteLine("Would you like to see the data? (yes)");
            string input = Console.ReadLine();
            if (input == "yes".ToLower())
            {
                dataHandler.DisplayData(data);
            }

        }


    }
}
