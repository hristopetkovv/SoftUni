namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Mapping;

    public class ToysService : IToysService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;

        public ToysService(IDeletableEntityRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public int GetToysCount(AnimalType animalType, ProductCategory product)
        {
            var count = this.productRepository
                .All()
                .Where(x => x.AnimalType == animalType && x.Category == product)
                .Count();

            return count;
        }

        public IEnumerable<T> GetToys<T>(AnimalType animalType, ProductCategory product)
        {
            IQueryable<Product> toys = this.productRepository
                .All()
                .Where(x => x.AnimalType == animalType && x.Category == product);

            return toys.To<T>().ToList();
        }
    }
}
