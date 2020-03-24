namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;

    using AnimalShop.Data.Models.Enums;

    public interface IProductsService
    {
        IEnumerable<T> GetProducts<T>(AnimalType animalType, ProductCategory product);

        int GetProductsCount(AnimalType animalType, ProductCategory product);

        T GetById<T>(int id);
    }
}
