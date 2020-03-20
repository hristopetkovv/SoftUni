// ReSharper disable VirtualMemberCallInConstructor
namespace AnimalShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AnimalShop.Data.Common.Models;
    using AnimalShop.Data.Models.Enums;

    public class Food : BaseDeletableModel<int>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int Stock { get; set; }

        public AnimalType AnimalType { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public virtual ICollection<FoodOrder> Orders { get; set; } = new HashSet<FoodOrder>();
    }
}