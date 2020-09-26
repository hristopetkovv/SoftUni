using System;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] arr = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] splitedInput = input.Split();
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = int.Parse(splitedInput[j]);
                }
            }

            int firstDiagSum = 0;
            int secondDiagSum = 0;

            for (int i = 0; i < n; i++)
            {
                firstDiagSum += Convert.ToInt32(arr[i, i]);
            }
            for (int i = 0; i < n; i++)
            {
                secondDiagSum += Convert.ToInt32(arr[((n - 1) - i), i]);
            }
            Console.WriteLine(Math.Abs(firstDiagSum-secondDiagSum));
        }
    }
}
