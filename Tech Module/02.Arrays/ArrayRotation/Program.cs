using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            //string[] numberAsString= Console.ReadLine().Split();
            //int[] numbers=new int[numbersAsString.Length;
            //for(int i=0;i<numberAsString.Length;i++)
            // numbers[i]=int.Parse(numberAsString[i]);
            int rotations = int.Parse(Console.ReadLine());
            for(int i=0;i<rotations;i++)
            {
                int firstNumber = numbers[0];
                for(int j=0;j<numbers.Length-1;j++)
                {
                    numbers[j] = numbers[j + 1];
                }
                numbers[numbers.Length - 1] = firstNumber;
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
