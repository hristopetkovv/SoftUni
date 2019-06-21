using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            for(int i=0;i<numbers.Count-1;i++)
            {
                int currentNumber = numbers[i];
                int nextNumber = numbers[i + 1];
                if(currentNumber==nextNumber)
                {
                    numbers[i] *= 2;
                    numbers.Remove(nextNumber);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
