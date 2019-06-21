using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditionConsumption = 1.6;
        private const double WastedFuel = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + AirConditionConsumption,tankCapacity)
        {

        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount);
            this.FuelQuantity -= amount * WastedFuel;
        }
    }
}
