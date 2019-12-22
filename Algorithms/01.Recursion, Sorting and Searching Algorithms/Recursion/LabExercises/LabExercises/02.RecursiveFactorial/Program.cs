using System;

namespace _02.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5));
        }

        private static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
