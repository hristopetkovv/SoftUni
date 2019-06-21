using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            PrintWord(word);

        }
        private static void PrintWord(string text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (symbol == 'a' || symbol == 'o' || symbol == 'u' || symbol == 'e' || symbol == 'i' || symbol == 'y')
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }


    }
    
}
