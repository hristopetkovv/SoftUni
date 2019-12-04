using System;
using System.Collections.Generic;

namespace _02.ExcelFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var table = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                table[row] = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var keyWord = command[0];
            var header = command[1];

            if (keyWord == "hide")
            {
                var headerArr = table[0];
                var index = 0;

                for (int i = 0; i < headerArr.Length; i++)
                {
                    if (headerArr[i] == header)
                    {
                        index = i;
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < table[row].Length; col++)
                    {
                        if (col + 1 == index && col + 1 == table[row].Length - 1)
                        {
                            Console.WriteLine(table[row][col]);
                            break;
                        }
                        if (col == index)
                        {
                            continue;
                        }
                        if (col == table[row].Length - 1)
                        {
                            Console.WriteLine(table[row][col]);
                        }
                        else
                        {
                            Console.WriteLine(table[row][col] + " | ");
                        }
                    }
                    Console.WriteLine();
                }
            }

            if (keyWord == "sort")
            {
                var elementsToSort = new List<string>();

                var headerArr = table[0];
                var index = 0;

                for (int i = 0; i < headerArr.Length; i++)
                {
                    if (headerArr[i] == header)
                    {
                        index = i;
                    }
                }

                for (int row = 1; row < rows; row++)
                {
                    for (int col = 0; col < table[row].Length; col++)
                    {
                        if (col == index)
                        {
                            elementsToSort.Add(table[row][col]);
                        }
                    }
                }

                elementsToSort.Sort();

                Console.WriteLine(string.Join(" | ", headerArr));

                for (int row = 0; row < rows; row++)
                {
                    if (elementsToSort.Count == 0)
                    {
                        break;
                    }
                    if (table[row][index] == elementsToSort[0])
                    {
                        Console.WriteLine(string.Join(" | ", table[row]));
                        elementsToSort.RemoveAt(0);
                        row = -1;
                    }
                }
            }

            if (keyWord == "filter")
            {
                var value = command[2];
                var headerArr = table[0];
                var index = 0;

                for (int i = 0; i < headerArr.Length; i++)
                {
                    if (headerArr[i] == header)
                    {
                        index = i;
                    }
                }

                Console.WriteLine(string.Join(" | ", headerArr));

                for (int row = 0; row < rows; row++)
                {
                    if (table[row][index] == value)
                    {
                        Console.WriteLine(string.Join(" | ", table[row]));
                    }
                }
            }
        }
    }
}
