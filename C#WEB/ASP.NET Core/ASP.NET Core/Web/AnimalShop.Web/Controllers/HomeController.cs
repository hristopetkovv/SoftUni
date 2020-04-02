﻿namespace AnimalShop.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using AnimalShop.Data.Models;
    using AnimalShop.Services.Data;
    using AnimalShop.Web.ViewModels;
    using AnimalShop.Web.ViewModels.ProductsInCart;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IUsersService usersService, UserManager<ApplicationUser> userManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> MyCart()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var viewModel = new ProductCartListingViewModel
            {
                Count = this.usersService.GetProductsCount(user.Id),
                Products = this.usersService.GetProducts<ProductCartViewModel>(user.Id),
            };

            return this.View(viewModel);
        }
    }
}
