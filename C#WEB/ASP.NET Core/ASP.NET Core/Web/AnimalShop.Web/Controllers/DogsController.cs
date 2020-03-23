namespace AnimalShop.Web.Controllers
{
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Data;
    using AnimalShop.Web.ViewModels.Food;
    using Microsoft.AspNetCore.Mvc;

    public class DogsController : Controller
    {
        private readonly IFoodService foodService;

        public DogsController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        public IActionResult Food()
        {
            AnimalType animalType = AnimalType.Dog;

            var viewModel = new FoodListeningViewModel
            {
                Count = this.foodService.GetFoodCount(animalType),
                Food = this.foodService.GetFood<FoodViewModel>(animalType),
            };

            return this.View(viewModel);
        }
    }
}
