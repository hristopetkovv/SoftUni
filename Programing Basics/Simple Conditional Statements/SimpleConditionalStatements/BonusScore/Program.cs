using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter score: ");
            int score = int.Parse(Console.ReadLine());
            double bonusScore = 0.0;

            if (score <= 100)
            {
                bonusScore = 5;
            }

            else
                if (score > 1000)
            {
                bonusScore = score * 0.10;



            }
            else
                if (score > 100)
            {
                bonusScore = score * 0.20;

            }

                if (score % 2 == 0)
                {
                    bonusScore = bonusScore + 1;
                }

                else if (score % 10 == 5)
                {
                    bonusScore = bonusScore + 2;

                }
                double totalscore = score + bonusScore;
                Console.WriteLine("Bonus Score: " + bonusScore);
                Console.WriteLine("Total Score: " + totalscore);
            



                
                




        }
    }
}
