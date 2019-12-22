using System;

namespace _03.RecursiveDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintFigure(5);
        }

        private static void PrintFigure(int n)
        {
            if (n <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));
            PrintFigure(n - 1);
            Console.WriteLine(new string('#', n));
        }
    }
}
