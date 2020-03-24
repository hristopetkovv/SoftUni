// ReSharper disable VirtualMemberCallInConstructor
namespace AnimalShop.Data.Models
{
    using System.Collections.Generic;

    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Food> Food { get; set; } = new HashSet<Food>();

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
