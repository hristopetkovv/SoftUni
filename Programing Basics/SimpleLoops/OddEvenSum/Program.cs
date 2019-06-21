using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int oddSum = 0, evenSum = 0;
            for(int i=0;i<n;i++)
            {
                int element = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                    evenSum += element;
                else
                    oddSum += element;
            }
            if (oddSum == evenSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum= " + oddSum);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + +Math.Abs(oddSum - evenSum));
            }

        }
    }
}
