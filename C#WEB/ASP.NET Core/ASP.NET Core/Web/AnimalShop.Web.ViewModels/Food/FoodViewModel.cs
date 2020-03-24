namespace AnimalShop.Web.ViewModels.Food
{
    using System;

    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Mapping;

    public class FoodViewModel : IMapFrom<Food>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int Stock { get; set; }

        public AnimalType AnimalType { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}
