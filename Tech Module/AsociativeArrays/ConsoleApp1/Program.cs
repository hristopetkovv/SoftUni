using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalWords = int.Parse(Console.ReadLine());

            var words = new Dictionary<string, List<string>>();

            for(int i=0;i<totalWords;i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if(!words.ContainsKey(word))
                {
                    words[word] = new List<string>();
                }

                words[word].Add(synonym);
            }

            foreach (var kvp in words)
            {
                string word = kvp.Key;
                List<string> synonyms = kvp.Value;
                Console.WriteLine($"{word} -> {string.Join(", ",synonyms)}");

            }


        }
    }
}
