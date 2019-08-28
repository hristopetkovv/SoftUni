using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split("|");
            List<string> loot = new List<string>(data);

            string input = Console.ReadLine();
            while(input != "Yohoho!")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if(command == "Loot")
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        if(!loot.Contains(tokens[i]))
                        {
                            loot.Insert(0, tokens[i]);
                        }
                    }
                }
                else if(command == "Drop")
                {
                    int index = int.Parse(tokens[1]);
                    if(index > loot.Count - 1 || index < 0)
                    {
                        
                    }
                    else
                    {
                    string removedLoot = loot[index];
                    loot.RemoveAt(index);
                    loot.Add(removedLoot);
                    }
                }
                else if(command == "Steal")
                {
                    int count = int.Parse(tokens[1]);
                    var stolenItems = loot.GetRange(loot.Count - count, count);
                    loot.RemoveRange(loot.Count - count, count);

                    Console.WriteLine(string.Join(", ", stolenItems));
                }

                input = Console.ReadLine();
            }

            double totalLength = 0;

            foreach (var treasure in loot)
            {
                totalLength += treasure.Length;
            }

            double countOfTreasures = loot.Count;

            double averageTreasure = totalLength / countOfTreasures;

            if(loot.Any())
            {
                Console.WriteLine($"Average treasure gain: {averageTreasure:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
