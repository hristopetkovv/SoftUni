using System;
using System.Collections.Generic;
using System.Text;

namespace P06.Animal
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender = "Male")
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}

