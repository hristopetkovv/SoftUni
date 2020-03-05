namespace AnimalsShop.Data.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AnimalsShop.Data.Data.Models.Enums;

    using static DataValidation;

    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
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

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public string Image { get; set; }

        public ICollection<FoodOrder> Orders { get; set; } = new HashSet<FoodOrder>();
    }
}
