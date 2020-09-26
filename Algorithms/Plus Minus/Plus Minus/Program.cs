using System;
using System.Linq;

namespace Plus_Minus
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int positiveCount = 0;
            int negativeCount = 0;
            int zeroCount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];
                if (num > 0)
                {
                    positiveCount++;
                }
                else if (num < 0)
                {
                    negativeCount++;
                }
                else
                {
                    zeroCount++;
                }
            }

            Console.WriteLine(String.Format("{0:0.000000}", (double)positiveCount / arr.Length));
            Console.WriteLine(String.Format("{0:0.000000}", (double)negativeCount / arr.Length));
            Console.WriteLine(String.Format("{0:0.000000}", (double)zeroCount / arr.Length));
        }
    }
}
