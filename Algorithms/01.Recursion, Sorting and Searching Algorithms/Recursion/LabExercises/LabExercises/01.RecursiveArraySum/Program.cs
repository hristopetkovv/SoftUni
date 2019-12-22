using System;

namespace _01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3, 4 };

            Console.WriteLine(Sum(arr, 0));
        }

        private static int Sum(int[] array, int index)
        {
            if (index == array.Length - 1)
            {
                return array[index];
            }

            return array[index] + Sum(array, index + 1);
        }
    }
}
