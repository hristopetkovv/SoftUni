using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.Factory
{
    public class DrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            return (IDrink)Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type)
                .GetConstructors()
                .FirstOrDefault()
                .Invoke(new object[] { name, servingSize, brand });
        }
    }
}
