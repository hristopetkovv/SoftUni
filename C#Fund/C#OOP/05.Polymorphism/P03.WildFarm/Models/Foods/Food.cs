﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Foods
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
