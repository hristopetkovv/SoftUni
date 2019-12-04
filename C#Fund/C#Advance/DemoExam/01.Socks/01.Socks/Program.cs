using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rightArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var leftSocks = new Stack<int>(leftArr);

            var rightSocks = new Queue<int>(rightArr);

            var pairs = new Queue<int>();

            while(true)
            {
                if (leftSocks.Count < 1 || rightSocks.Count < 1)
                {
                    Console.WriteLine(pairs.Max());
                    Console.WriteLine(string.Join(' ', pairs));
                    return;
                }

                if (leftSocks.Peek() > rightSocks.Peek())
                {
                    var pair = leftSocks.Pop() + rightSocks.Dequeue();
                    pairs.Enqueue(pair);
                    continue;
                }
                if (leftSocks.Peek() < rightSocks.Peek())
                {
                    leftSocks.Pop();
                    continue;
                }
                if (leftSocks.Peek() == rightSocks.Peek())
                {
                    rightSocks.Dequeue();
                    leftSocks.Push(leftSocks.Pop() + 1);
                    continue;
                }
            }
        }
    }
}
