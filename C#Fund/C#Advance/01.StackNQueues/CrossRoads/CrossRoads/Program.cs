using System;
using System.Collections.Generic;

namespace CrossRoads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queueOfCars = new Queue<string>();

            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            bool isHit = false;
            string hittedCarName = "";
            char hittedSymbol = '\0';

            int totalCars = 0;

            while(input != "END")
            {
                if(input != "green")
                {
                    queueOfCars.Enqueue(input);
                    input = Console.ReadLine();

                    continue;
                }

                int currentGreenLightDuration = greenLightDuration;

                while(currentGreenLightDuration > 0 && queueOfCars.Count > 0)
                {
                    string carName = queueOfCars.Dequeue();

                    int carLength = carName.Length;

                    if(currentGreenLightDuration - carLength >= 0)
                    {
                        currentGreenLightDuration -= carLength;
                        totalCars++;
                    }
                    else
                    {
                        currentGreenLightDuration += freeWindowDuration;

                        if(currentGreenLightDuration - carLength >= 0)
                        {
                            totalCars++;
                            break;
                        }
                        else
                        {
                            isHit = true;
                            hittedCarName = carName;
                            hittedSymbol = carName[currentGreenLightDuration];
                            break;
                        }
                    }
                }

                if(isHit)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if(isHit)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hittedCarName} was hit at {hittedSymbol}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCars} total cars passed the crossroads.");
            }
        }
    }
}
