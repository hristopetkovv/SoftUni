namespace AnimalsShop.Data.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataValidation;

    public class Brand
    {
        public int Id { get; set; }

        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Food> Food { get; set; } = new HashSet<Food>();

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}