﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Dessert : Food
    {
        private const int InitialServingSize = 200;

        public Dessert(string name,  decimal price) 
            : base(name, InitialServingSize, price)
        {
        }
    }
}
