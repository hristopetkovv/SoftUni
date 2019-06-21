using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            int[] firstArr = new int[linesCount];
            int[] secondArr = new int[linesCount];
            for(int i=0;i<linesCount;i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                if(i%2==0)
                {
                    firstArr[i] = numbers[0];
                    secondArr[i] = numbers[1];
                }
                else
                {
                    firstArr[i] = numbers[1];
                    secondArr[i] = numbers[0];
                }
            }
            for(int i=0;i<linesCount;i++)
            {
                Console.Write("{0} ",firstArr[i]);
            }
            Console.WriteLine();
            for(int i=0;i<linesCount;i++)
            {
                Console.Write($"{secondArr[i]} ");
            }

        }
    }
}
