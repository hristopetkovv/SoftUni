using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.MaximumAndMinimumElement
{
    public class Program
    {
        public static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            var elements = new Stack<int>();
            var maxElements = new Stack<int>();
            maxElements.Push(int.MinValue);

            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (command[0] == 1)
                {
                    if (maxElements.Peek() < command[1])
                    {
                        maxElements.Push(command[1]);
                    }
                    elements.Push(command[1]);
                }
                else if (command[0] == 2)
                {
                    if (elements.Count == 0)
                    {
                        continue;
                    }
                    elements.Pop();
                    maxElements.Pop();
                }
                else if (command[0] == 3)
                {
                    Console.WriteLine(maxElements.Peek());
                }
                else if (command[0] == 4)
                {
                    Console.WriteLine(elements.Min());
                }
            }

            if (elements.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(string.Join(", ", elements));
            }
        }
    }
}