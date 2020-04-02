﻿namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Mapping;
    using AnimalShop.Web.ViewModels.ProductsInCart;

    public class FoodService : IFoodService
    {
        private readonly IDeletableEntityRepository<Food> foodRepository;
        private readonly IDeletableEntityRepository<Order> orderRepository;
        private readonly IDeletableEntityRepository<FoodOrder> foodOrderRepository;
        private readonly IDeletableEntityRepository<Cart> cartRepository;

        public FoodService(IDeletableEntityRepository<Food> foodRepository, IDeletableEntityRepository<Order> orderRepository, IDeletableEntityRepository<FoodOrder> foodOrderRepository, IDeletableEntityRepository<Cart> cartRepository)
        {
            this.foodRepository = foodRepository;
            this.orderRepository = orderRepository;
            this.foodOrderRepository = foodOrderRepository;
            this.cartRepository = cartRepository;
        }

        public async Task AddToCartAsync(int foodId, string userId)
        {
            var food = this.GetById<FoodCartInputModel>(foodId);

            var cartProduct = new Cart
            {
                UserId = userId,
                Name = food.Name,
                Image = food.Image,
                Price = food.Price,
                Weight = food.Weight,
            };

            await this.cartRepository.AddAsync(cartProduct);
            await this.cartRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var food = this.foodRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return food;
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

        public async Task SellFoodToUserAsync(int foodId, string userId)
        {
            var food = this.foodRepository
                .All()
                .FirstOrDefault(x => x.Id == foodId);

            food.Stock--;

            var order = new Order()
            {
                Status = OrderStatus.Proccessed,
                UserId = userId,
            };

            var foodOrder = new FoodOrder()
            {
                FoodId = foodId,
                Order = order,
            };

            await this.orderRepository.AddAsync(order);
            await this.foodOrderRepository.AddAsync(foodOrder);

            await this.orderRepository.SaveChangesAsync();
            await this.foodOrderRepository.SaveChangesAsync();
        }
    }
}
