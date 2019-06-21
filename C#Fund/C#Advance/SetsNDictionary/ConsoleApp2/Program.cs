using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var continents = new Dictionary<string, List<string>>();

            var contries = new Dictionary<string, List<string>>();
        

            var totalComands = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalComands; i++)
            {
                var commandParts = Console.ReadLine().Split();

                var continent = commandParts[0];
                var country = commandParts[1];
                var city = commandParts[2];

                if(!continents.ContainsKey(continent))
                {
                    continents[continent] = new List<string>();

                }
                if (!continents[continent].Contains(country))
                {
                    continents[continent].Add(country);
                }
                if(!contries.ContainsKey(country))
                {
                    contries[country] = new List<string>();
                }
                if(!contries[country].Contains(city))
                {
                    contries[country].Add(city);
                }
            }
            foreach (var continentKvp in continents)
            {
                var continent = continentKvp.Key;
                var countries = continentKvp.Value;

                Console.WriteLine($"{continent}:");

                foreach (var country in countries)
                {
                    var cities = contries[country];

                    Console.WriteLine($"{country} -> {string.Join(", ",cities)}");
                }
            }
        }
    }
}
