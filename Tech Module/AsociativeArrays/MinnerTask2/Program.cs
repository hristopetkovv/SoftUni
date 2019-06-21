using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinnerTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> mine = new Dictionary<string, decimal>();
            string userInput = Console.ReadLine();

            //loops till "stop" is entered as a resource value
            while (userInput != "stop")
            {
                decimal amount = decimal.Parse(Console.ReadLine());
                //if resource exists
                if (mine.ContainsKey(userInput))
                {
                    mine[userInput] += amount;
                }
                //if resource does not exists
                else
                {
                    mine[userInput] = amount;
                }

                //waits for the next loop
                userInput = Console.ReadLine();
            }

            //prints the result ( if any)
            foreach (string key in mine.Keys)
            {
                Console.WriteLine($"{key} -> {mine[key]}");
            }

        }
    }
}
