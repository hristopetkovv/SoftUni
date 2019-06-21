using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.Factory
{
    public class FoodFactory
    {
        public IFood CreateFood(string foodType, string name, decimal price)
        {
            Type type = Assembly.GetCallingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name == foodType);

            IFood food = (IFood)Activator.CreateInstance(type, name, price);

            return food;
        }

    }
}
