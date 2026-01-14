using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    internal class Radix_Sort<T> where T : IComparable<T>
    {

        /// <summary>
        /// Main entry point that routes to the correct implementation based on type.
        /// </summary>
        public static void SortSet(T[] data, Clock clock)
        {
            if (data is int[] intData)
            {
                SortInt(intData, clock);
            }
            else if (data is string[] stringData)
            {
                SortString(stringData, clock);
            }
            else
            {
                throw new NotSupportedException($"Radix Sort is not specialized for {typeof(T).Name}.");
            }
        }

        private static void SortInt(int[] arr, Clock clock)
        {
            int n = arr.Length;
            if (n <= 1) return;

            // 1. Find Min and Max using long to prevent overflow during range calculation
            int min = arr[0];
            int max = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
            }

            // 2. Calculate the shifted maximum. 
            // We use long to handle the full spread (up to 4.2 billion)
            long minL = (long)min;
            long maxShifted = (long)max - minL;

            // If all numbers are the same, maxShifted is 0 and we are already sorted.
            if (maxShifted == 0) return;

            // 3. Counting Sort for each digit
            // Use long for 'exp' because 10^10 overflows a 32-bit integer.
            for (long exp = 1; (maxShifted / exp) > 0 && !clock.IsElapsed(); exp *= 10)
            {
                CountSortInt(arr, n, exp, minL);

            }
        }

        private static void CountSortInt(int[] arr, int n, long exp, long offset)
        {
            int[] output = new int[n];
            int[] count = new int[10];

            // Store count of occurrences
            for (int i = 0; i < n; i++)
            {
                // Shift the value to non-negative range using the offset
                long val = (long)arr[i] - offset;
                int digit = (int)((val / exp) % 10);
                count[digit]++;
            }

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build output array backwards to maintain stability
            for (int i = n - 1; i >= 0; i--)
            {
                long val = (long)arr[i] - offset;
                int digit = (int)((val / exp) % 10);
                output[count[digit] - 1] = arr[i];
                count[digit]--;
            }

            // Copy output array back to the original reference
            Array.Copy(output, 0, arr, 0, n);
        }

        private static void SortString(string[] arr, Clock clock)
        {
            int n = arr.Length;
            int maxLen = 0;
            foreach (var s in arr) if (s != null && s.Length > maxLen) maxLen = s.Length;

            for (int d = maxLen - 1; d >= 0 && !clock.IsElapsed(); d--)
            {
                CountSortString(arr, n, d);
                
            }
        }

        private static void CountSortString(string[] arr, int n, int d)
        {
            string[] output = new string[n];
            int[] count = new int[256];

            for (int i = 0; i < n; i++)
            {
                int c = (arr[i] != null && d < arr[i].Length) ? (int)arr[i][d] : 0;
                count[c]++;
            }

            for (int i = 1; i < 256; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                int c = (arr[i] != null && d < arr[i].Length) ? (int)arr[i][d] : 0;
                output[count[c] - 1] = arr[i];
                count[c]--;
            }

            Array.Copy(output, 0, arr, 0, n);
        }
    }

    }
