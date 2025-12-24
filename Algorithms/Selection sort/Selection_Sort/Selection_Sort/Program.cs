using System.Timers;

namespace Selection_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Type of handler
            //DataHandler<int> numHandler = new DataHandler<int>();
            DataHandler<string> wordHandler = new DataHandler<string>();

            // Filename of dataset
            string filename = "word_20.txt";
            // Parse Data
            wordHandler.ParseData(filename);
            // Timer - 1 hour
            // (Interval v ms, doba trvání sortování v ms)
            Clock clock = new Clock(1000,10000);
            Console.WriteLine(clock.GetTime());

            // dataHandler.DisplayData();

             



            string[] data = wordHandler.GetData();
            wordHandler.CalculateAccuracy(data);
            Console.WriteLine("Press to start");
            Console.ReadKey();
            // Selection sort
            int lowestNumIndex;
            // Timer
            clock.StartClock();

            data = Selection_Sort.SortWordSet(data, wordHandler, clock);

            //for (int swapIndex = 0; swapIndex < data.Length && !clock.IsElapsed(); swapIndex++)
            //{
            //    lowestNumIndex = swapIndex;
            //    for (int comparedIndex = swapIndex + 1; comparedIndex < data.Length && !clock.IsElapsed(); comparedIndex++)
            //    {
            //        if (wordHandler.WordIsBigger(data[comparedIndex], data[lowestNumIndex]))
            //        {
            //            lowestNumIndex = comparedIndex;
            //        }
                    
            //    }
            //    if (swapIndex != lowestNumIndex)
            //    {
            //        string temp = data[lowestNumIndex];
            //        data[lowestNumIndex] = data[swapIndex];
            //        data[swapIndex] = temp;
            //    }
            //    //dataHandler.DisplayData(data);
            //    Console.Clear();
            //    clock.ShowTime();
            //    Console.WriteLine(clock.IsElapsed());
            //}

            Console.WriteLine("End of sorting");
            Console.WriteLine("\nTime:");
            clock.ShowTime();
            wordHandler.CalculateAccuracy(data);
            Console.WriteLine("Would you like to see the data? (yes)");
            string input = Console.ReadLine();
            if (input == "yes".ToLower())
            {
                wordHandler.DisplayData(data);
            }


            //wordHandler.ParseData("word_20-94%.txt");
            //wordHandler.CalculateAccuracy(wordHandler.GetData());

            //int[] data = numHandler.GetData();

            ////Selection sort
            //int lowestNumIndex;
            //clock.StartClock();
            //for (int swapIndex = 0; swapIndex < data.Length; swapIndex++)
            //{
            //    lowestNumIndex = swapIndex;
            //    for(int comparedIndex = swapIndex+1; comparedIndex < data.Length; comparedIndex++)
            //    {
            //        if (numHandler.NumIsBigger(data[comparedIndex],data[lowestNumIndex]))
            //        {
            //            lowestNumIndex = comparedIndex;
            //        }
            //    }
            //    if (swapIndex != lowestNumIndex)
            //    {
            //        int temp = data[lowestNumIndex];
            //        data[lowestNumIndex] = data[swapIndex];
            //        data[swapIndex] = temp;
            //    }
            //    //dataHandler.DisplayData(data);
            //}

            //numHandler.DisplayData(data);
            //Console.WriteLine("\nTime:");
            //clock.ShowTime();

            //Console.WriteLine("Nums:");
            //Console.WriteLine(numHandler.NumIsBigger(5,5));
            //Console.WriteLine("Words:");
            //Console.WriteLine(wordHandler.WordIsBigger("ok","ok"));
            //Console.WriteLine(wordHandler.WordIsBigger("abc", "def"));
            //Console.WriteLine(wordHandler.WordIsBigger("abc", "abd"));
            //Console.WriteLine(wordHandler.WordIsBigger("oke", "ok"));
            //Console.WriteLine(wordHandler.WordIsBigger("1", "2"));
            //while(true)
            //{

            //}

            //string currentDir = Environment.CurrentDirectory;
            //string root = Directory.GetParent(currentDir).Parent.Parent.Parent.Parent.Parent.Parent.FullName;
            //string dataDir = "Data";


            //Console.WriteLine(root);
            //string content = File.ReadAllText($"{root}/{dataDir}/{filename}");
            //Console.WriteLine(content);

            //string[] resultArr = content.Split('\n');

            //for(int i = 0; i < resultArr.Length; i++)
            //{
            //    Console.WriteLine($"{i} {resultArr[i]}");
            //}

        }
    }
}
