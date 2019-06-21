using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonestDark
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int coins = 0;
            

            List<string> dungeonsRooms = Console.ReadLine()
                .Split('|')
                .ToList();

            //Console.WriteLine(string.Join(" ",dungeonsRooms[0]));
            for(int i=0;i<dungeonsRooms.Count;i++)
            {
                List<int> Room = new List<string>(dungeonsRooms)
                    .Select(int.Parse)
                    .ToList();
                if(dungeonsRooms[i]=="potion")
                {
                    health += Room[1];
                    if(health>100)
                    {
                        health = 100;
                        Console.WriteLine("$Your current health: {health} hp.");
                    }

                }
                else if(dungeonsRooms[i]=="chest")
                {
                    int foundedCoins = Room[1];
                    Console.WriteLine("You found {foundedCoins} coins.");
                }
                else
                {
                    string monster = dungeonsRooms[i];
                    int attackOfMonster = Room[1];
                    health = health - attackOfMonster;
                    if(health<=0)
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                    }
                    else if(health>0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                        Console.WriteLine($"Best room: {i}");
                    }


                }

            }

            string Input = Console.ReadLine();
            if(string.IsNullOrEmpty(Input))
            {
                if(health>0)
                {
                    Console.WriteLine($"You've made it!");
                    Console.WriteLine($"Coins: {coins}");
                    Console.WriteLine($"Health: {health}");
                }
            }

          

         
        }
    }
}
