using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTaskIfInside
{
    class Program
    {
        static void Main(string[] args)
        {
            int hp = 100;
            int coins = 0;
            int room = 1;
            var rooms = Console.ReadLine().Split('|');
            List<string> items = new List<string>();
            List<int> values = new List<int>();
            foreach (var a in rooms)
            {
                string[] things = a.Split();
                items.Add(things[0]);
                values.Add(int.Parse(things[1]));
            }
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == "potion")
                {
                    int bonus = values[i];
                    if (hp + bonus < 100)
                    {
                        Console.WriteLine($"You healed for {bonus} hp.");
                        hp += bonus;
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {100 - hp} hp.");
                        hp = 100;
                    }
                    Console.WriteLine($"Current health: {hp} hp.");
                    room++;
                }
                else if (items[i] == "chest")
                {
                    int bonus = values[i];
                    coins += bonus;
                    Console.WriteLine($"You found {bonus} coins.");
                    room++;
                }
                else
                {
                    int bonus = values[i];
                    hp -= bonus;
                    if (hp > 0)
                    {
                        Console.WriteLine($"You slayed {items[i]}.");
                        room++;
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {items[i]}.");
                        Console.WriteLine($"Best room: {room}");
                        break;
                    }
                }
            }
            if (hp > 0)
            {
                Console.WriteLine($"You've made it!\nCoins: {coins}\nHealth: {hp}");
            }
        }
    }
}