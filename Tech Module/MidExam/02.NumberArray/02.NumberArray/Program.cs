using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.NumberArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string command = input.Split(" ")[0];
                if (command == "Switch")
                {
                    int index = int.Parse(input.Split(" ")[1]);
                    if (index >= 0 && index < list.Count)
                    {
                        int number = list.ElementAt(index);
                        list.RemoveAt(index);
                        int newNumber = 0;
                        newNumber = number * -1;
                        list.Insert(index, newNumber);
                    }
                }

                else if (command == "Change")
                {
                    int index = int.Parse(input.Split(" ")[1]);
                    int value = int.Parse(input.Split(" ")[2]);

                    list.RemoveAt(index);
                    list.Insert(index, value);
                }

                else if (command == "Sum")
                {
                    string param = input.Split(" ")[1];
                    if (param == "Positive")
                    {
                        int sumOfPositive = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] >= 0)
                            {
                                sumOfPositive += list[i];
                            }
                        }
                        Console.WriteLine(sumOfPositive);
                    }
                    else if (param == "Negative")
                    {
                        int sumOfNegative = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] < 0)
                            {
                                sumOfNegative += list[i];
                            }
                        }
                        Console.WriteLine(sumOfNegative);
                    }
                    else if (param == "All")
                    {
                        int sum = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            sum += list[i];
                        }
                        Console.WriteLine(sum);
                    }
                }
                input = Console.ReadLine();
            }

            List<int> positiveNumbers = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] >= 0)
                {
                    positiveNumbers.Add(list[i]);
                }
            }

            Console.WriteLine(string.Join(" ", positiveNumbers));
        }
    }
}
