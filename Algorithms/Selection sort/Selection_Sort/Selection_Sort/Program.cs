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
            // Timer
            Clock clock = new Clock();
            Console.WriteLine(clock.GetTime());

            //dataHandler.DisplayData();

            string[] data = wordHandler.GetData();

            //Selection sort
            int lowestNumIndex;
            clock.StartClock();
            for (int swapIndex = 0; swapIndex < data.Length; swapIndex++)
            {
                lowestNumIndex = swapIndex;
                for (int comparedIndex = swapIndex + 1; comparedIndex < data.Length; comparedIndex++)
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
            }

            wordHandler.DisplayData(data);
            Console.WriteLine("\nTime:");
            clock.ShowTime();
            wordHandler.CalculateAccuracy(data);

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
