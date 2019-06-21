using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int smallerNumber = SmallerNumber(firstNumber, secondNumber);
            int result = SmallerNumber(smallerNumber, thirdNumber);
            Console.WriteLine(result);

        }
        static int SmallerNumber(int number1,int number2)
            // return number1 <= number2 ? number1 : number2;
        {
            if(number1<=number2)
            {
                return number1;
            }
            else
            {
                return number2;
            }

        }
    }
}
