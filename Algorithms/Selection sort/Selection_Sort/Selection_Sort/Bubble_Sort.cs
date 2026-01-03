using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Selection_Sort
{
    static internal class Bubble_Sort<T> where T : IComparable<T>
    {
        public static T[] SortSet(T[] data, DataHandler<T> valueHandler, Clock clock)
        {

            for(int i = 0; i < data.Length-1 && !clock.IsElapsed(); i++)
            {
                //bool notSwapped = true;
                for(int swappedNumberIndex = 0; swappedNumberIndex < data.Length-1; swappedNumberIndex++)
                {
                    if(valueHandler.CompareValue(data[swappedNumberIndex+1],data[swappedNumberIndex]))
                    {
                        T temp = data[swappedNumberIndex];
                        data[swappedNumberIndex] = data[swappedNumberIndex+1];
                        data[swappedNumberIndex+1] = temp;
                    }
                    //else
                    //{
                    //    notSwapped = false;
                    //}
                    
                }
                clock.RepeatedShowTime();
            }
            return data;
        }
    }
}
