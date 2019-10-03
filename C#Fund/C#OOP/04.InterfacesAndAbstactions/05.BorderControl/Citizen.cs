using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
