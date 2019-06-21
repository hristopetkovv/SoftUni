using System;
using System.Text;

namespace Cars
{
    public class Car
    {
        private string make;
        private string model;
        private int year;

        private Engine engine;

        public Car(string make, string model, int year)

        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model,Engine engine, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Engine = engine;
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Must be more than 1 symbol");
                }

                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Must be more than 1 symbol");
                }

                this.model = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }
            private set
            {
                var maxYear = DateTime.Now.Year;
                if (value < 1950 || value > DateTime.Now.Year + 1)
                {
                    throw new ArgumentException($"Car year must be between 1950 and {maxYear}");
                }
                this.year = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return this.engine;
            }
            private set
            {
                if(value== null)
                {
                    throw new ArgumentNullException(nameof(this.engine), "Engine cannot be null!");
                }
                this.engine = value;
            }
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; private set; }

        public void Drive(double distance)
        {
            var canContinue =
                this.FuelQuantity - this.FuelConsumption * distance >= 0;

            if (canContinue)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
            }
            else
            {
                throw new CarCannotContinueException("Not enough fuel!");

            }
        }

        public string GetInformation()
        {
            var result = new StringBuilder();
            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.Append($"Fuel: {this.FuelQuantity:F2}L");
            return result.ToString();
        }

    }
}
