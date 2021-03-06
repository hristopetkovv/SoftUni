﻿using System;

namespace _01.BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                totalPlunder += dailyPlunder;
                if(i % 3 == 0)
                {
                    double additionalPlunder = dailyPlunder / 2;
                    totalPlunder += additionalPlunder;
                }
                if(i % 5 == 0)
                {
                    totalPlunder -= totalPlunder * 0.3;
                }
            }

            if(totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double leftPercentage = totalPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {leftPercentage:f2}% of the plunder.");
            }

        }
    }
}
