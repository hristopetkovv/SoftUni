using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeList2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            while(true)
            {
                string Input = Console.ReadLine();

                if(Input=="end")
                {
                    break;
                }

                string[] tokens = Input.Split();

                string command = tokens[0];

                if(command=="Delete")
                {
                    int numberToDelete = int.Parse(tokens[1]);
                    numbers.RemoveAll(item => item== numberToDelete);

                }

                else if(command=="Insert")
                {
                    int numberToInsert = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, numberToInsert);
                }


            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
