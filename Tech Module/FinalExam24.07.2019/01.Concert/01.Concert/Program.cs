using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> bands = new Dictionary<string, List<string>>();

            Dictionary<string, int> playTime = new Dictionary<string, int>();

            string input = Console.ReadLine();

            int totalTime = 0;

            while(input != "start of concert")
            {
                string[] tokens = input.Split("; ");

                string command = tokens[0];

                string name = tokens[1];

                if(command == "Add")
                {
                    List<string> members = tokens[2]
                            .Split(", ")
                            .ToList();

                    if (!bands.ContainsKey(name))
                    {
                        bands.Add(name, members);
                    }
                    else
                    {
                        foreach(var member in members)
                        {
                            if(!bands[name].Contains(member))
                            {
                                bands[name].Add(member);
                            }
                        }
                    }
                }
                else
                {
                    int time = int.Parse(tokens[2]);

                    totalTime += time;

                    if(!playTime.ContainsKey(name))
                    {
                        playTime.Add(name, time);
                    }
                    else
                    {
                        playTime[name] += time;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total time: {totalTime}");
            //Console.WriteLine($"Total time: {playTime.Values.Sum()}");

            foreach (var band in playTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            string bandName = Console.ReadLine();

            Console.WriteLine(bandName);

            foreach (var member in bands[bandName])
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
