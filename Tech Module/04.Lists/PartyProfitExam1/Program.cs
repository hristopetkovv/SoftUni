using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyProfitExam1
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double coins = 0;
            //coins = (50 * days);

            for (int i = 1; i <= days; i++)                         
            {

                coins += 50;
                if (i % 15 == 0)
                {
                    partySize = partySize + 5;
                    
                }
                if (i % 10 == 0)
                {
                    partySize = partySize - 2;
                    
                }
               


                if (i % 3 == 0)
                {
                    coins = coins - (3 * partySize);
                    
                }
                if (i % 5 == 0)
                {
                    coins -= 2 * partySize;
                    coins += 20 * partySize;
                    continue;

                }
                coins = coins - (2 * partySize);

            }
            


            coins = coins / partySize;
            Console.WriteLine($"{partySize} companions received {Math.Floor(coins)} coins each.");

        }
    }
}
