using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositiveNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> positiveNumber = new List<int>();
                
            for(int i=0;i<numbers.Count;i++)
            {
                if (numbers[i]<0)
                {
                    positiveNumber.Add(numbers[i]);
                }
            }

            if (positiveNumber.Count > 0)
            {
                positiveNumber.Reverse();
                Console.WriteLine(string.Join(" ", positiveNumber));
            }
            else
                Console.WriteLine("empty");
        }
    }
}
