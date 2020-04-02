namespace AnimalShop.Web.ViewModels.ProductsInCart
{
    using AnimalShop.Data.Models;
    using AnimalShop.Services.Mapping;

    public class FoodCartViewModel : IMapFrom<Food>
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public double Weight { get; set; }

        public decimal Price { get; set; }
    }
}
