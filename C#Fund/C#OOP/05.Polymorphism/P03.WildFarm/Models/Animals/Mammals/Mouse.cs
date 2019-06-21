using System;
using System.Collections.Generic;
using System.Text;
using P03.WildFarm.Models.Foods;

namespace P03.WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
