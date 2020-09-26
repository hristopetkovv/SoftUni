using System;
using System.Linq;

namespace Compare_the_Triplets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrA = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int[] arrB = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            
            int alicePoints = 0;
            int bobPoints = 0;


            for (int i = 0; i < arrA.Length; i++)
            {
                if (arrA[i] > arrB[i])
                {
                    alicePoints++;
                }
                else if (arrA[i] < arrB[i])
                {
                    bobPoints++;
                }
                else if (arrA[i] == arrB[i])
                {
                    continue;
                }
            }

            int[] result = new int[2];
            result[0] = alicePoints;
            result[1] = bobPoints;

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
