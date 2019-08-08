﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine()
                .Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int santaIndex = 0;

            while(true)
            {
                string inputArgs = Console.ReadLine();

                if(inputArgs == "Merry Xmas!")
                {
                    break;
                }

                string[] commandArgs = inputArgs
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if(commandArgs[0] == "Jump")
                {
                    int timesToJump = int.Parse(commandArgs[1]);

                    if(santaIndex + timesToJump >=houses.Count)
                    {
                        santaIndex = (santaIndex + timesToJump) % houses.Count;
                    }

                    else
                    {
                        santaIndex += timesToJump;
                    }

                    if(houses[santaIndex] == 0)
                    {
                        Console.WriteLine($"House {santaIndex} will have a Merry Christmas.");
                    }

                    else
                    {
                        houses[santaIndex] -= 2;
                    }
                }
            }

            int failedHouses = houses.Where(x => x != 0).Count();

            Console.WriteLine($"Santa's last position was {santaIndex}.");

            if(failedHouses > 0)
            {
                Console.WriteLine($"Santa has failed {failedHouses} houses.");
            }
            else
            {
                Console.WriteLine("Mission was successful.");

            }


        }
    }
}
