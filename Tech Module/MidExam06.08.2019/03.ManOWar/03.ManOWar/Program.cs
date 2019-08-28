using System;
using System.Linq;

namespace _03.ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToArray();
            int[] warship = Console.ReadLine().Split(">").Select(int.Parse).ToArray();
            int maximumHealth = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while(input != "Retire")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if(command == "Fire")
                {
                    int index = int.Parse(tokens[1]);
                    int damage = int.Parse(tokens[2]);
                    if(index >= 0 && index < warship.Length)
                    {
                        warship[index] -= damage;
                        if(warship[index] <= 0 )
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if(command == "Defend")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    int damage = int.Parse(tokens[3]);

                    if(startIndex >= 0 && startIndex <= pirateShip.Length)
                    {
                        if (endIndex >= startIndex && endIndex < pirateShip.Length)
                        {
                            for(int i = startIndex; i <= endIndex; i++)
                            {
                                pirateShip[i] -= damage;
                                if(pirateShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        }
                    }
                }
                else if(command == "Repair")
                {
                    int index = int.Parse(tokens[1]);
                    int health = int.Parse(tokens[2]);

                    if(index >= 0 && index < pirateShip.Length)
                    {
                        pirateShip[index] += health;
                        if(pirateShip[index] > maximumHealth)
                        {
                            pirateShip[index] = maximumHealth;
                        }
                    }
                }
                else if(command == "Status")
                {
                    int counter = 0;
                    for (int i = 0; i < pirateShip.Length; i++)
                    {
                        if(pirateShip[i] < maximumHealth * 0.2)
                        {
                            counter++;
                        }
                    }

                    Console.WriteLine($"{counter} sections need repair.");
                }

                input = Console.ReadLine();
            }

            int pirateShipSum = pirateShip.Sum();
            int warShipSum = warship.Sum();
            Console.WriteLine($"Pirate ship status: {pirateShipSum}");
            Console.WriteLine($"Warship status: {warShipSum}");
        }
    }
}
