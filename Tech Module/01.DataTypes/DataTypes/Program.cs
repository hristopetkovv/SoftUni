using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine()); //54
            int sum = 0;
            for(int i=1;i<=number;i++) 
            {
                
                while(number!=0)//54
                {
                    int lastDigit = number % 10;//4
                    number /= 10;
                    sum += lastDigit;
                }
            
            }
            Console.WriteLine(sum);
        }
    }
}
