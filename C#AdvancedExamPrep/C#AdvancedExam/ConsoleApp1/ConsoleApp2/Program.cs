using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            var plates = new Queue<int>();

            var trojanWariors = new Queue<int>();

            int[] spartanPlates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            foreach (var plate in spartanPlates)
            {
                plates.Enqueue(plate);
            }   

            for (int i = 0; i < numberOfWaves; i++)
            {

                int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                //if (numberOfWaves % 3 == 0)
                //{
                //    int additionalPlate = int.Parse(Console.ReadLine());
                //    plates.Enqueue(additionalPlate);
                //}

                foreach (var warior in input)
                {
                    trojanWariors.Enqueue(warior);
                }
            }

            while (plates.Any() && trojanWariors.Any())
            {
                int spartansDefence = plates.Dequeue(); // 10
                int trojanAttackers = trojanWariors.Dequeue(); // 1

                while(spartansDefence > trojanAttackers)
                {
                    spartansDefence -= trojanAttackers; //9
                    trojanAttackers = trojanWariors.Dequeue(); //5

                }
            }
            var platesLeft = new List<int>();
            var attackersLeft = new List<int>();

            foreach (var plate in plates)
            {
                
                platesLeft.Add(plate);
            }
            if(plates.Any())
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine("Plates left: ");
                Console.Write(string.Join(", ", platesLeft));
            }

            foreach (var attacker in trojanWariors)
            {

                attackersLeft.Add(attacker);
            }
            if (trojanWariors.Any())
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine("Warriors left: ");
                Console.Write(string.Join(", ", attackersLeft));
            }
        }
    }
}
