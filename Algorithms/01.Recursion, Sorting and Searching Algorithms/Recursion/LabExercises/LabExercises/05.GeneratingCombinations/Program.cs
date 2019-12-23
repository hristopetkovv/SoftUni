using System;

namespace _05.GeneratingCombinations
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static void GenCombs(int[] set, int[] vector, int index, int border)
        {
            if (index >= vector.Length)
            {
                //Print vector
            }
            else
            {
                for (int i = border + 1; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenCombs(set, vector, index + 1, i);
                }
            }
        }
    }
}
