using System.Timers;

namespace Selection_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Type of handler
            DataHandler<string> dataHandler = new DataHandler<string>();
            //DataHandler<string> dataHandler = new DataHandler<string>();

            // Filename of dataset
             string filename = "random_words_1M.txt";
            // string filename = "random_integers_10M.txt";
            // string filename = "number_10K.txt";
            // string filename = "number_200.txt";
            // string filename = "number_test.txt";

            // Parse Data
            dataHandler.ParseData(filename);
            // Timer - 1 hour
            // (Interval v ms, doba trvání sortování v ms)
            Clock clock = new Clock(1000,1000*60*60);
            //Console.WriteLine(clock.GetTime());


            string[] data = dataHandler.GetData();



            double beforeSortAccuracy = dataHandler.CalculateAccuracy(data);
            Console.WriteLine("Press to start");
            Console.ReadKey();
            // Selection sort
            // Timer
            clock.StartClock();

            //data = Selection_Sort.Sort(data, dataHandler, clock);
            //data = Heap_Sort<int>.SortSet(data, dataHandler, clock);
            //Merge_Sort<string>.mergeSort(data, 0, data.Length - 1);
            Quicksort_Sort<string>.quickSort(data, 0, data.Length - 1, clock);



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
