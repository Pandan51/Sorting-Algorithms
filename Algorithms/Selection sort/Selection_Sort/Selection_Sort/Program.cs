using System.Timers;

namespace Selection_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataHandler<int> numHandler = new DataHandler<int>();
            DataHandler<string> wordHandler = new DataHandler<string>();
            string filename = "number_200.txt";
            numHandler.ParseData(filename);
            Clock clock = new Clock();

            //dataHandler.DisplayData();


            int[] data = numHandler.GetData();

            //Selection sort
            int lowestNumIndex;
            clock.StartClock();
            for (int swapIndex = 0; swapIndex < data.Length; swapIndex++)
            {
                lowestNumIndex = swapIndex;
                for(int comparedIndex = swapIndex+1; comparedIndex < data.Length; comparedIndex++)
                {
                    if (numHandler.NumIsBigger(data[comparedIndex],data[lowestNumIndex]))
                    {
                        lowestNumIndex = comparedIndex;
                    }
                }
                if (swapIndex != lowestNumIndex)
                {
                    int temp = data[lowestNumIndex];
                    data[lowestNumIndex] = data[swapIndex];
                    data[swapIndex] = temp;
                }
                //dataHandler.DisplayData(data);
            }
            Console.WriteLine("\nTime:");
            clock.StartClock();
            numHandler.DisplayData(data);
            clock.ShowTime();

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
