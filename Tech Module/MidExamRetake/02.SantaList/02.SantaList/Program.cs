using System;
using System.Linq;

namespace _02.SantaList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split("&")
                .ToList();

            string input = Console.ReadLine();

            while (input != "Finished!")
            {
                string[] tokens = input.Split(" ");

                string command = tokens[0];

                string kidName = tokens[1];

                if (command == "Bad")
                {
                    if (!list.Contains(kidName))
                    {
                        list.Insert(0, kidName);
                    }
                }

                if (command == "Good")
                {
                    if (list.Contains(kidName))
                    {
                        list.Remove(kidName);
                    }
                }

                if (command == "Rename")
                {
                    string newKid = tokens[2];
                    if (list.Contains(kidName))
                    {
                        int index = list.IndexOf(kidName);
                        list.Remove(kidName);
                        list.Insert(index, newKid);
                    }

                }

                if (command == "Rearrange")
                {
                    if (list.Contains(kidName))
                    {
                        list.Remove(kidName);
                        list.Add(kidName);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
