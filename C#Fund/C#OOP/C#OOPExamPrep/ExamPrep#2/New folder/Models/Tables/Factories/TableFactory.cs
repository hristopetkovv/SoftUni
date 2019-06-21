using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.Factories
{
    public class TableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            ITable table;

            switch (type)
            {
                case "Inside":
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case "OutSide":
                    table = new OutsideTable(tableNumber, capacity);
                    break;
                default:
                    table = null;
                    break;
            }

            return table;
        }
    }
}
