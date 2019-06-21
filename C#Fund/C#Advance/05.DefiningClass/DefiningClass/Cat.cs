using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClass
{
    class Cat
    {
        private string name;

        public int Age { get; private set; }

        public bool IsAsleep { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(value.Length < 2)
                {
                    throw new ArgumentException("Cat name should be more than 2 symbols");
                }

                this.name = value;
            }
        }
    }
}
