namespace AnimalShop.Web.ViewModels.Toys
{
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Mapping;

    public class ToysViewModel : IMapFrom<Product>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }


        public AnimalType AnimalType { get; set; }

        public ProductCategory Category { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }
    }
}
