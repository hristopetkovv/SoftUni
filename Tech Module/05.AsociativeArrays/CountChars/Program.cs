using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().Replace(" ", "");
            var counts = new Dictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (counts.ContainsKey(text[i]))
                {
                    counts[text[i]]++;
                }
                else
                {
                    counts.Add(text[i], 1);
                }
            }

            foreach (var count in counts)

            {
                Console.WriteLine($"{count.Key} -> {count.Value}");
            }


        }
    }
}
