using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string[] cars = Console.ReadLine().Split();

        Queue<string> carsForService = new Queue<string>(cars);
        Stack<string> servedCars = new Stack<string>();


        string[] input = Console.ReadLine().Split('-');

        while (input[0] != "End")
        {
            if (input[0] == "Service")
            {
                if (carsForService.Count > 0)
                {
                    string currentServedCar = carsForService.Dequeue();

                    Console.WriteLine($"Vehicle {currentServedCar} got served.");
                    servedCars.Push(currentServedCar);

                }
            }

            else if (input[0] == "CarInfo")
            {
                string checkCar = input[1];

                if (servedCars.Contains(checkCar))
                {
                    Console.WriteLine("Served.");
                }

                else
                {
                    Console.WriteLine("Still waiting for service.");
                }
            }

            else if (input[0] == "History")
            {
                if (servedCars.Count > 0)
                {
                    Console.WriteLine($"{string.Join(", ", servedCars.ToList())}");
                }
            }

            input = Console.ReadLine().Split('-');
        }

        if (carsForService.Count > 0)
        {
            Console.WriteLine($"Vehicles for service: {string.Join(", ", carsForService.ToList())}");
        }

        if (servedCars.Count > 0)
        {
            Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars.ToList())}");

        }
    }
}