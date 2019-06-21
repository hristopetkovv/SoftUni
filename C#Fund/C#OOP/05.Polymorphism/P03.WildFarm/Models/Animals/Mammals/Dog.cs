using System;
using System.Collections.Generic;
using System.Text;
using P03.WildFarm.Models.Foods;

namespace P03.WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            throw new NotImplementedException();
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
