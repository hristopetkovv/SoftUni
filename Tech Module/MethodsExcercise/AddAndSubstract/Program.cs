using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddAndSubstract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            SubstractResult(firstNumber, secondNumber, thirdNumber);
        }
        
        static void SubstractResult(int num1, int num2, int num3)
        {
            int sum = num1 + num2;
            int result = sum - num3;
            Console.WriteLine(result);
        }
    }
}
