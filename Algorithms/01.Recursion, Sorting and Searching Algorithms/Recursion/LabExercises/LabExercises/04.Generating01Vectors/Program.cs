using System;

namespace _04.Generating01Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vector = new int[8];
            Gen01(0, vector);
        }

        private static void Gen01(int index, int[] vector)
        {
            if (index > vector.Length - 1)
            {
                Console.WriteLine(vector);
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    Gen01(index + 1, vector);
                }
            }
        }
    }
}
