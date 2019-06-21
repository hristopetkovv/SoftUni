using System;
using System.Collections.Generic;

namespace P5CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> symbolCount = new SortedDictionary<char, int>();

            foreach (var @char in input)
            {
                if(symbolCount.ContainsKey(@char)== false)
                {
                    symbolCount[@char] = 0;
                }
                symbolCount[@char]++;
            }

            foreach (var kvp in symbolCount)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
