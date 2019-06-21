using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AirConditionConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AirConditionConsumption, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumtion -= AirConditionConsumption;
            return base.Drive(distance);
        }
    }
}
