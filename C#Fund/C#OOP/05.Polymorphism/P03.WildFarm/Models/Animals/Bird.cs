using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight,double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }
    }
}
