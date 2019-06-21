using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());
            bool isUpper = char.IsUpper(letter);
            if (isUpper)
            {
                Console.WriteLine("upper-case");
            }
            else
                Console.WriteLine("lower-case");
            
        }
    }
}
