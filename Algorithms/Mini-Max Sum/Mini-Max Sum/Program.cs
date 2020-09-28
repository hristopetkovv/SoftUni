using System;
using System.Collections.Generic;
using System.Linq;

namespace Mini_Max_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            long max = arr.Sum();
            long min = arr.Sum();

            max -= arr.Min();
            min -= arr.Max();
            Console.WriteLine(min + " " + max);
        }
    }
}
