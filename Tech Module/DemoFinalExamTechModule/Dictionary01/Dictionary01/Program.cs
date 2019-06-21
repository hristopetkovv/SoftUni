using System;
using System.Collections.Generic;
using System.Linq;


namespace Dictionary01
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();

            var words = new Dictionary<string, List<string>>();

            foreach(string wordDefinitionPair in inputText.Split(" | "))
            {
                string[] splitted = wordDefinitionPair.Split(": ");

                string word = splitted[0];

                string definition = splitted[1];

                if(!words.ContainsKey(word))
                {
                    words.Add(word, new List<string>());
                }

                words[word].Add(definition);
            }

            string[] wordsToPrint = Console.ReadLine().Split(" | ");

            foreach (string word in wordsToPrint.OrderBy(w => w)) 
            {
                if(words.ContainsKey(word))
                {
                    Console.WriteLine(word);

                    foreach (var definition in words[word].OrderByDescending(d=>d.Length))
                    {
                        Console.WriteLine($"-{definition}");
                    }
                }
            }

            string command = Console.ReadLine();

            if (command == "List")
            {
                Console.WriteLine(string.Join(' ', words.Keys.OrderBy(w => w)));
            }

            else
            {
                return;
            }
        }
    }
}
