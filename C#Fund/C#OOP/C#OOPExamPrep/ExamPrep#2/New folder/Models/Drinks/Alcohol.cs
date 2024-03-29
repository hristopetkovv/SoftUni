﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class Alcohol : Drink
    {
        private const decimal AlcoAlcoholPrice = 3.50m;

        public Alcohol(string name, int servingSize, string brand) 
            : base(name, servingSize, AlcoAlcoholPrice, brand)
        {
        }
    }
}
