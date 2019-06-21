using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseParty3
{
    class Program
    {
        static void Main(string[] args)
        {
            int commands = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < commands; i++)
            {
                string Input = Console.ReadLine();

                string[] tokens = Input.Split();

                string party = tokens[2];

                string name = tokens[0];

                if(party=="going!")
                {


                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                        continue;
                    }

                    guests.Add(name);

                }
                

                else if(party=="not")
                {    
                    
                   

                    if(!guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                    guests.Remove(name);
                }
                
                
            }
            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);

            }


        }
    }
}
