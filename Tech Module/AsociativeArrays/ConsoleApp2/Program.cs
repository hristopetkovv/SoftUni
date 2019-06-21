using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine()
                .Split(' ')
                .Where(x => x.Length % 2 == 0)
                .ToList();

            foreach (var item in word)
            {
                Console.WriteLine(item);
            }
        }
    }
}
