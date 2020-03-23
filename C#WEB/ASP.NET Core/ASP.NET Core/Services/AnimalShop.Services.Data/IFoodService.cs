namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;

    using AnimalShop.Data.Models.Enums;

    public interface IFoodService
    {
        IEnumerable<T> GetFood<T>(AnimalType animalType);

        int GetFoodCount(AnimalType animalType);
    }
}
