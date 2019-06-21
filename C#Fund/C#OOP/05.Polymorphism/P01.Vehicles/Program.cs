using P01.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehilcles = new List<Vehicle>();

            for (int i = 0; i <= 3; i++)
            {
                string[] vehileArgs = Console.ReadLine().Split();

                double fuelQuantity = double.Parse(vehileArgs[1]);
                double fuelConsupmtion = double.Parse(vehileArgs[2]);
                int tankCapacity = int.Parse(vehileArgs[3]);

                Vehicle vehicle = null;

                if (i == 1)
                {
                    vehicle = new Car(fuelQuantity, fuelConsupmtion, tankCapacity);
                }
                else if (i == 2)
                {
                    vehicle = new Truck(fuelQuantity, fuelConsupmtion, tankCapacity);
                }
                else
                {
                    vehicle = new Bus(fuelQuantity, fuelConsupmtion, tankCapacity);
                }

                vehilcles.Add(vehicle);
            }

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                string command = commandArgs[0];
                string commandType = commandArgs[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(commandArgs[2]);

                    if (commandType == "Car")
                    {
                        Vehicle currentVehicles = vehilcles
                            .FirstOrDefault(x => x.GetType().Name == commandType);
                        Console.WriteLine(currentVehicles.Drive(distance));
                    }
                }
                else if (command == "Refuel")
                {
                    double fuelAmount = double.Parse(commandArgs[2]);
                    Vehicle currentVehicles = vehilcles
                        .FirstOrDefault(x => x.GetType().Name == commandType);

                    try
                    {
                        currentVehicles.Refuel(fuelAmount);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    double distance = double.Parse(commandArgs[2]);
                    Bus currentBus = (Bus)vehilcles
                        .FirstOrDefault(x => x.GetType().Name == commandType);

                    Console.WriteLine(currentBus.DriveEmpty(distance));
                }
            }
            foreach (var vehicle in vehilcles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
