using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix= int.Parse(Console.ReadLine());
            PrintMatirx(sizeMatrix);
        
        }
        static void PrintMatirx(int size)
        {
            for(int i=0;i<size;i++)
            {
                for(int j=0;j<size;j++)
                {
                    Console.Write(size+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}
