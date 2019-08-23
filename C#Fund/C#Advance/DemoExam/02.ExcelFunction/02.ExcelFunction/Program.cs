using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ExcelFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] table = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                string[] rowValues = Console.ReadLine().Split(", ");

                table[i] = rowValues;
            }

            string[] commandArgs = Console.ReadLine().Split();

            string command = commandArgs[0];
            string header = commandArgs[1];

            if (command == "hide")
            {
                int headerIndex = Array.IndexOf(table[0], header);

                for (int row = 0; row < table.Length; row++)
                {
                    List<string> lineToPrint = new List<string>();
                    lineToPrint.AddRange(table[row].Take(headerIndex).ToList());
                    lineToPrint.AddRange(table[row].Skip(headerIndex + 1));

                    Console.WriteLine(string.Join(" | ", lineToPrint));
                }
            }
        }
    }
}
