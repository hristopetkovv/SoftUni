using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());

            }
            for (int i =0; i <n; i++)
            {
                Console.Write(numbers[i] + " ");
                sum += numbers[i];
                
            }
            Console.WriteLine();
            Console.WriteLine(sum);
            Console.WriteLine();




        }
    }
}
