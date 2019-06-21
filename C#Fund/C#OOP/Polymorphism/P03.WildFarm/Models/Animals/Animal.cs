using P03.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string ProduceSound();

        public  void Eat(Food food)
        {
            string typeFood = food.GetType().Name;

            if (typeFood == "Fruit" || typeFood == "Vegetable")
            {
                this.Weight += food.Quantity * 0.10;
                this.FoodEaten += food.Quantity;
                return;
            }

            throw new ArgumentException($"{this.GetType().Name} does not eat {typeFood}!");
        }



    }
}
