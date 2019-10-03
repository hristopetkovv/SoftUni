using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Ferrari
{
    public class Ferrari : IDrivable
    {
        private string model;

        private string driver;

        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.Model = "488-Spider";
        }

        public string Driver { get; private set; }

        public string Model { get; private set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }
    }
}
