using System;

namespace _01.ChristmasSpirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int daysLeft = int.Parse(Console.ReadLine());
            int ornamentSet = 0;
            int treeSkirts = 0;
            int treeGarlands = 0;
            int treeLights = 0;
            int spirit = 0;
            int lastDay = daysLeft;

            for (int i = 1; i <= daysLeft; i++)
            {
                if (i % 10 == 0)
                {
                    spirit -= 20;
                    treeSkirts += 1;
                    treeLights += 1;
                    treeGarlands += 1;
                }

                if (i % 11 == 0)
                {
                    quantity += 2;
                }
                if (i % 3 == 0)
                {
                    treeSkirts += quantity;
                    treeGarlands += quantity;
                    spirit += 13;
                }
                if (i % 5 == 0)
                {
                    treeLights += quantity;
                    spirit += 17;
                    if (i % 3 == 0)
                    {
                        spirit += 30;
                    }
                }

                if (i % 2 == 0)
                {
                    ornamentSet += quantity;
                    spirit += 5;
                }
            }
            if (lastDay % 10 == 0)
            {
                spirit -= 30;
            }
            int costOfOrnament = ornamentSet * 2;
            int CostOftreeSkirts = treeSkirts * 5;
            int costOftreeGarlands = treeGarlands * 3;
            int costOftreeLights = treeLights * 15;
            int totalCost = costOfOrnament + costOftreeGarlands + costOftreeLights + CostOftreeSkirts;
            Console.WriteLine($"Total cost: {totalCost}");
            Console.WriteLine($"Total spirit: {spirit}");
        }
    }
}
