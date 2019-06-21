using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string Input = Console.ReadLine();
                if (Input == "End")
                {
                    break;
                }

                string[] tokens = Input.Split();

                string command = tokens[0];

                if (command == "Add")
                {
                    int numberToAdd = int.Parse(tokens[1]);
                    numbers.Add(numberToAdd);

                }

                else if (command == "Insert")
                {
                    int number = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    if (index > numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.Insert(index, number);
                }

                else if (command == "Remove")
                {
                    int index = int.Parse(tokens[1]);
                    if (index > numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(index);
                }

                else if (command == "Shift")
                {
                    int rotation = int.Parse(tokens[2]);

                    string directions = tokens[1];

                    if (directions == "left")
                    {
                        for (int i = 0; i < rotation % numbers.Count; i++)
                        {
                            int firstNumber = numbers[0];
                            numbers.Add(firstNumber);
                            numbers.RemoveAt(0);
                            //int firstNumber = numbers[0];

                            //for (int j = 0; j < numbers.Count - 1; j++)
                           // {
                                //numbers[j] = numbers[j + 1];

                            //}

                            //numbers[numbers.Count - 1] = firstNumber;
                        }

                    }

                    else
                    {
                        for (int i = 0; i < rotation % numbers.Count; i++)
                        {
                            int lastNumber = numbers.Last();
                            numbers.Insert(0, lastNumber);
                            numbers.RemoveAt(numbers.Count - 1);
                            //int lastNumber = numbers[numbers.Count - 1];

                            //for (int j = numbers.Count - 1; j > 0 - 2; j--)
                            //{
                                //numbers[j] = numbers[j - 1];

                            //}

                           // numbers[0] = lastNumber;
                        }
                    }

                }
                
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

