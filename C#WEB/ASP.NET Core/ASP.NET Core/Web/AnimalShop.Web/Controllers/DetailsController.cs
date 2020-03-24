namespace AnimalShop.Web.Controllers
{
    using AnimalShop.Services.Data;
    using AnimalShop.Web.ViewModels.Food;
    using AnimalShop.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;

    public class DetailsController : Controller
    {
        private readonly IFoodService foodService;
        private readonly IProductsService productsService;

        public DetailsController(IFoodService foodService, IProductsService productsService)
        {
            this.foodService = foodService;
            this.productsService = productsService;
        }

        public IActionResult Food(int id)
        {
            var viewModel = this.foodService.GetById<FoodViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public IActionResult Product(int id)
        {
            var viewModel = this.productsService.GetById<ProductViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
