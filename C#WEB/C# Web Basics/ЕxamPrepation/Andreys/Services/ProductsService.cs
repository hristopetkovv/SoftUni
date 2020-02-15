namespace Andreys.Services
{
    using Andreys.Data;
    using Andreys.Models;
    using Andreys.ViewModels.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext dbContext;

        public ProductsService(AndreysDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Add(ProductAddInputModel productsAddInputModel)
        {
            var genderAsEnum = Enum.Parse<Gender>(productsAddInputModel.Gender);
            var categoryAsEnum = Enum.Parse<Category>(productsAddInputModel.Category);

            var product = new Product()
            {
                Name = productsAddInputModel.Name,
                Description = productsAddInputModel.Description,
                ImageUrl = productsAddInputModel.ImageUrl,
                Price = productsAddInputModel.Price,
                Gender = genderAsEnum,
                Category = categoryAsEnum
            };

            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();

            return product.Id;
        }

        public IEnumerable<Product> GetAll()
           => this.dbContext.Products.Select(x => new Product
           {
               Id = x.Id,
               Name = x.Name,
               ImageUrl = x.ImageUrl,
               Price = x.Price
           })
           .ToArray();

        public Product GetById(int id)
            => this.dbContext.Products.FirstOrDefault(x => x.Id == id);

        public void DeleteById(int id)
        {
            var product = GetById(id);

            this.dbContext.Products.Remove(product);

            this.dbContext.SaveChanges();
        }
    }
}
