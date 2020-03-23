namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;

    using AnimalShop.Data.Models.Enums;

    public interface IToysService
    {
        IEnumerable<T> GetToys<T>(AnimalType animalType, ProductCategory product);

        int GetToysCount(AnimalType animalType, ProductCategory product);
    }
}
