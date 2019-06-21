using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumtion = fuelConsumption;
        }

        public int TankCapacity { get; private set; }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                {
                    if (value > this.TankCapacity)
                    {
                        this.fuelQuantity = 0;
                    }
                    else
                    {
                        this.fuelQuantity = value;
                    }
                }
            }
        }

        public double FuelConsumtion { get; protected set; }

        public virtual void Refuel(double amount)   
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            double totalFuelAmount = this.FuelQuantity + amount;

            if (totalFuelAmount > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
            this.FuelQuantity += amount;
        }

        public string Drive(double distance)
        {
            string vehicleName = GetType().Name;
            double neededFuel = this.FuelConsumtion * distance;

            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;

                return $"{vehicleName} travelled {distance} km";
            }
            else
            {
                return $"{vehicleName} needs refueling";
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
