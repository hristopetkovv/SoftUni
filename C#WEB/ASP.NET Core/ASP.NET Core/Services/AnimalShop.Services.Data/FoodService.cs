namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Mapping;

    public class FoodService : IFoodService
    {
        private readonly IDeletableEntityRepository<Food> foodRepository;

        public FoodService(IDeletableEntityRepository<Food> foodRepository)
        {
            this.foodRepository = foodRepository;
        }

        public IEnumerable<T> GetFood<T>(AnimalType animalType)
        {
            IQueryable<Food> food = this.foodRepository.All().Where(x => x.AnimalType == animalType);

            return food.To<T>().ToList();
        }

        public int GetFoodCount(AnimalType animalType)
        {
            var count = this.foodRepository.All().Where(x => x.AnimalType == animalType).Count();

            return count;
        }
    }
}
