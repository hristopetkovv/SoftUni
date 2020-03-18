namespace AnimalsShop.Data.Data.Models
{
    using AnimalsShop.Data.Data.Models.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public ICollection<ProductOrder> Orders { get; set; } = new HashSet<ProductOrder>();

        public AnimalType AnimalType { get; set; }

        public ProductCategory Category { get; set; }

        public int Stock { get; set; }
    }
}