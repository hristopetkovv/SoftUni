using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharactersInrange
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol1 = char.Parse(Console.ReadLine());
            char symbol2 = char.Parse(Console.ReadLine());
            CharactersBetweenSymbols(symbol1, symbol2);
        }
        static void CharactersBetweenSymbols(char sym1,char sym2)
        {
            for(char i=sym1;i<sym2;i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
