using System;

namespace TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOFTown = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());
            Console.WriteLine($"Town {nameOFTown} has population of {population} and area {area} square km.");

        }
    }
}
