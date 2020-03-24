namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Mapping;

    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;

        public ProductsService(IDeletableEntityRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public int GetProductsCount(AnimalType animalType, ProductCategory product)
        {
            var count = this.productRepository
                .All()
                .Where(x => x.AnimalType == animalType && x.Category == product)
                .Count();

            return count;
        }

        public IEnumerable<T> GetProducts<T>(AnimalType animalType, ProductCategory product)
        {
            IQueryable<Product> toys = this.productRepository
                .All()
                .Where(x => x.AnimalType == animalType && x.Category == product);

            return toys.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var product = this.productRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return product;
        }
    }
}
