using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Selection_Sort
{
    internal class DataHandler<T>
    {
        private T[] _data;

        public DataHandler()
        {

        }
        public void DisplayData(T[]? data = null)
        {
            T[] temp = data != null ? data : _data;
            if (_data != null)
            {
                Console.WriteLine("Logging all data.:");
                foreach (T item in temp)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public T[] GetData()
        {
            //if (_data != null)
            //{
            //    return _data;
            //}
            return _data ?? [];
        }

        public void ParseData(string filename)
        {
            // Getting path towards data

            // Current dir
            string currentDir = Environment.CurrentDirectory;
            // Root of entire assignment
            string projectRoot = Directory.GetParent(currentDir).Parent.Parent.Parent.Parent.Parent.Parent.FullName;
            // Directory name of data folder
            string dataDir = "Data";
            // Path to text file
            string filePath = Path.Combine(projectRoot, dataDir, filename);

            //Console.WriteLine(root);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Could not find file at: {filePath}");
            }
            string content = File.ReadAllText(filePath);
            
            //Console.WriteLine(content);

            string[] resultArr = content.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            _data = ConvertStringsToGeneric(resultArr);

            

            //for (int i = 0; i < resultArr.Length; i++)
            //{
            //    Console.WriteLine($"{i} {resultArr[i]}");
            //}
        }

        // Convert text to generic type
        private T[] ConvertStringsToGeneric(string[] inputs)
        {
            T[] result = new T[inputs.Length];

            // Get the type converter for T (e.g., Int32Converter, DoubleConverter)
            var converter = TypeDescriptor.GetConverter(typeof(T));

            for (int i = 0; i < inputs.Length; i++)
            {
                try
                {
                    // Option 1: Handle if T is already a string
                    if (typeof(T) == typeof(string))
                    {
                        result[i] = (T)(object)inputs[i];
                    }
                    // Option 2: Use TypeConverter for primitives (int, double, bool, etc.)
                    else if (converter != null && converter.CanConvertFrom(typeof(string)))
                    {
                        result[i] = (T)converter.ConvertFromString(inputs[i]);
                    }
                    else
                    {
                        // Fallback: Default value if conversion is impossible
                        result[i] = default;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Warning: Could not convert '{inputs[i]}' to {typeof(T).Name}. {ex.Message}");
                    result[i] = default;
                }
            }

            return result;
        }

        public void CalculateAccuracy(string[] data)
        {
            // Count if 2 elements are sorted correctly
            double correctSortPoints = 0;
            //Resulting accuracy in %
            double accuracy = 0;

            // Check if sorted
            for(int index = 0; index < data.Length-2;index++)
            {
                if (this.WordIsBigger(data[index], data[index+1]))
                {
                    correctSortPoints++;
                    //Console.WriteLine("Word is bigger");
                }
            }
            //Console.WriteLine(correctSortPoints);
            //Console.WriteLine(data.Length);
            accuracy = correctSortPoints / (data.Length-2);
            Console.WriteLine($"Accuracy of this data set is {accuracy * 100} %\n" +
                $"{correctSortPoints}/{data.Length-2}  Sorted/All items");
        }

        public bool WordIsBigger(string word1, string word2)
        {
            for(int i = 0; i < word1.Length && i < word2.Length; i++)
            {
                if (word1[i] < word2[i])
                {
                    return true;
                }
                else if (word1[i] > word2[i])
                {
                    return false;
                }
            }
            if (word1.Length < word2.Length)
            {
                return true;
            }
            else {
                return false;
            }
            
        }

        public bool NumIsBigger(double num1, double num2)
        {
            return num1 < num2;
        }

        

        
        

        



    }
}
