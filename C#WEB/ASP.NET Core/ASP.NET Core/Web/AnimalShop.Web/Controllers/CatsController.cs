namespace AnimalShop.Web.Controllers
{
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Data;
    using AnimalShop.Web.ViewModels.Food;
    using AnimalShop.Web.ViewModels.Toys;
    using Microsoft.AspNetCore.Mvc;

    public class CatsController : Controller
    {
        private readonly AnimalType animalType = AnimalType.Cat;
        private readonly IFoodService foodService;
        private readonly IToysService toysService;

        public CatsController(IFoodService foodService, IToysService toysService)
        {
            this.foodService = foodService;
            this.toysService = toysService;
        }

        public IActionResult Food()
        {
            var viewModel = new FoodListingViewModel
            {
                Count = this.foodService.GetFoodCount(this.animalType),
                Food = this.foodService.GetFood<FoodViewModel>(this.animalType),
            };

            return this.View(viewModel);
        }

        public IActionResult Toy()
        {
            ProductCategory category = ProductCategory.Toys;

            var viewModel = new ToysListingViewModel
            {
                Count = this.toysService.GetToysCount(this.animalType, category),
                Toys = this.toysService.GetToys<ToysViewModel>(this.animalType, category),
            };

            return this.View(viewModel);
        }
    }
}
