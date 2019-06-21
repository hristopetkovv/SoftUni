using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private IList<IFood> foodOrders;
        private IList<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.capacity = capacity;
            this.pricePerPerson = pricePerPerson;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.numberOfPeople = 0; // v nachaloto masata e prazna
            this.IsReserved = false;
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (capacity <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                numberOfPeople = value;
            }
        }
        public int TableNumber { get; }
        public bool IsReserved { get; private set; }
        public decimal Price => this.foodOrders.Sum(f => f.Price) 
            + this.drinkOrders.Sum(d => d.Price) 
            + this.pricePerPerson * this.numberOfPeople;

        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Table: {TableNumber}")
            .AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Capacity: {capacity}")
            .AppendLine($"Price per Person: {pricePerPerson:f2}");

            return result.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Table: {TableNumber}")
            .AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Number of people: {numberOfPeople}");

            string foodOrders = this.foodOrders.Count > 0 ? this.foodOrders.Count.ToString() : "None";
            string drinkOrders = this.drinkOrders.Count > 0 ? this.drinkOrders.Count.ToString() : "None";

            result.AppendLine($"Food orders: {foodOrders}");

            foreach (var food in this.foodOrders)
            {
                result.AppendLine(food.ToString());
            }

            result.AppendLine($"Drink orders: {drinkOrders}");

            foreach (var drink in this.drinkOrders)
            {
                result.AppendLine(drink.ToString());
            }

            return result.ToString().TrimEnd();

        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople; // vzemame si propertyto zashtoto poluchave int otvan
            this.IsReserved = true;
        }
    }
}
