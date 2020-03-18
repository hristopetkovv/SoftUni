namespace AnimalsShop.Data.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public OrderStatus Status { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<FoodOrder> Food { get; set; } = new HashSet<FoodOrder>();

        public ICollection<ProductOrder> Products { get; set; } = new HashSet<ProductOrder>();
    }
}