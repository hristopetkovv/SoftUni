using System;
using System.Collections.Generic;
using System.Linq;


namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesValue = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>(clothesValue);
            int racks = 1;
            int sum = 0;

            while(clothes.Any())
            {
                if (sum + clothes.Peek() <= rackCapacity)
                {
                    sum += clothes.Pop();
                }
                else
                {
                    sum = 0;
                    racks++;
                }
            }
            Console.WriteLine(racks);
        }
    }
}
