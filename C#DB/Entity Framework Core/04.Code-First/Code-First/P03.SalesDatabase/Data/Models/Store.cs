using System.Collections.Generic;

namespace P03.SalesDatabase.Data.Models
{
    public class Store
    {
        public int StoreId { get; set; }

        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
