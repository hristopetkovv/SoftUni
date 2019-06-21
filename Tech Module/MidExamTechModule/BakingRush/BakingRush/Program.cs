using System;
using System.Collections.Generic;

namespace BakingRush
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = 100;

            int coins = 100;

            List<string> items = new List<string>();

            List<int> values = new List<int>();

            string[] input = Console.ReadLine().Split("|");

            foreach (var item in input)
            {
                string[] splitted = item.Split("-");

                items.Add(splitted[0]);
                values.Add(int.Parse(splitted[1]));
            }

            for (int i = 0; i <items.Count; i++)
            {
                if(items[i]=="rest")
                {
                    
                    if(initialEnergy<100)
                    {
                        int bonusEnergy = values[i];
                        initialEnergy += bonusEnergy;
                        Console.WriteLine($"You gained {bonusEnergy} energy.");
                        
                            
                    }
                    else
                    {
                        int bonusEnergy = 0;
                        Console.WriteLine($"You gained {bonusEnergy} energy.");
                        initialEnergy = 100;
                    }
                    Console.WriteLine($"Current energy: {initialEnergy}.");
                }
                else if(items[i]=="order")
                {
                    
                    int bonusCoins = values[i];
                    coins += bonusCoins;
                    initialEnergy -= 30;
                    if (initialEnergy > 0)
                    {
                        Console.WriteLine($"You earned {bonusCoins} coins.");
                    }
                    else if (initialEnergy <= 0)
                    {
                        coins -= bonusCoins;
                        initialEnergy += 50;
                        Console.WriteLine($"You had to rest!");

                    }

                }
                else
                {
                    int bonusCoins = values[i];
                    
                    if(coins>bonusCoins )
                    {
                        Console.WriteLine($"You bought {items[i]}.");
                        coins -= bonusCoins;
                    }
                    else if(coins<=bonusCoins)
                    {
                        Console.WriteLine($"Closed! Cannot afford {items[i]}.");
                        return;
                    }

                }

            }
            Console.WriteLine($"Day completed!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Energy: {initialEnergy}");            
        }
    }
}
