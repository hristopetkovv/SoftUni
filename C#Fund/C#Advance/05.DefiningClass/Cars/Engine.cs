using System;

namespace Cars
{
    public class Engine
    {
        private int power;
        private double capacity;

        public Engine(int power,double capacity)
        {
            this.Power = power;
            this.Capacity = capacity;
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                if(value<0)
                {
                    throw new ArgumentException("Power must be possitive number!");
                }
                this.power = value;
            }
        }

        public double Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if(value<0)
                {
                    throw new ArgumentException("Capacity must be possitive number!");
                }
                this.capacity = value;
            }
        }


    }
}
