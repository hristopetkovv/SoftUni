using System;
using System.Collections.Generic;
using System.Text;

namespace P06.Animal
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name,int age,string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            protected set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || (value != "Male" && value != "Female"))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(this.GetType().Name);
            builder.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            builder.Append($"{this.ProduceSound()}");
            return builder.ToString();
        }
    }
}
