using System;
using System.Collections.Generic;

namespace _05.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var newcomeres = new List<IIdentifiable>();

            while (true)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var name = input[0];

                if(name == "End")
                {
                    break;
                }

                if(input.Length == 2)
                {
                    var id = input[1];

                    var robot = new Robot(name, id);
                    newcomeres.Add(robot);
                }

                if(input.Length == 3)
                {
                    var age = int.Parse(input[1]);
                    var id = input[2];

                    var citizen = new Citizen(name, age, id);
                    newcomeres.Add(citizen);
                }
            }

            var fakeDigits = Console.ReadLine();

            foreach (var newcomer in newcomeres)
            {
                if(newcomer.Id.EndsWith(fakeDigits))
                {
                    Console.WriteLine(newcomer.Id);
                }
            }
        }
    }
}
