namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Services.Mapping;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<Cart> cartRepository;

        public UsersService(IDeletableEntityRepository<Cart> cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public IEnumerable<T> GetProducts<T>(string userId)
        {
            IQueryable<Cart> products = this.cartRepository
                .All()
                .Where(x => x.UserId == userId);

            return products.To<T>().ToList();
        }

        public int GetProductsCount(string userId)
        {
            var count = this.cartRepository
               .All()
               .Where(x => x.UserId == userId)
               .Count();

            return count;
        }
    }
}
