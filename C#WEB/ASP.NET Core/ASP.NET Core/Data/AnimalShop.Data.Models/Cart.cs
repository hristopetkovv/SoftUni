namespace AnimalShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AnimalShop.Data.Common.Models;

    public class Cart : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public decimal Price { get; set; }

        public double? Weight { get; set; }
    }
}
