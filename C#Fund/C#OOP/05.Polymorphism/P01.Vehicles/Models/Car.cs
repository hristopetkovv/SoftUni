using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AirConditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AirConditionConsumption,tankCapacity)
        {

        }
    }
}
