using System;
using System.Collections.Generic;

namespace MeanMode
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static bool MeanMode(int[] array)
        {
            return computeMode(array) == computeAverage(array);
        }

        // TODO
        private static double computeAverage(int[] array)
        {
            double total = 0;

            foreach (var item in array)
            {
                total += item;
            }

            double average = total / array.Length;

            return average;
        }

        // TODO
        private static double? computeMode(int[] array)
        {
            Dictionary<int, int> Dict = new Dictionary<int, int>();

            foreach (var item in array)
            {
                if (!Dict.ContainsKey(item))
                {
                    Dict[item] = 1;
                }
                else
                {
                    Dict[item]++;
                }
            }

            double maxVal = 0;

            List<int> Modes = new List<int>();

            foreach (var key in Dict.Keys)
            {
                if (Dict[key] > maxVal)
                {
                    Modes.Clear();
                    Modes.Add(key);
                    maxVal = Dict[key];
                }
                else if (Dict[key] == maxVal)
                {
                    Modes.Add(key);
                }
            }

            if (Modes.Count > 1)
            {
                return null;
            }
            else
            {
                return Modes[0];
            }
        }
    }
}
