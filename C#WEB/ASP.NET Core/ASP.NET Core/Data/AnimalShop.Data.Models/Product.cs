// ReSharper disable VirtualMemberCallInConstructor
namespace AnimalShop.Data.Models
{
    using System.Collections.Generic;

    using AnimalShop.Data.Common.Models;
    using AnimalShop.Data.Models.Enums;

    public class Product : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public virtual ICollection<ProductOrder> Orders { get; set; } = new HashSet<ProductOrder>();

        public AnimalType AnimalType { get; set; }

        public ProductCategory Category { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }
    }
}
