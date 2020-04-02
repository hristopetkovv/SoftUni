namespace AnimalShop.Web.ViewModels.ProductsInCart
{
    using System.Collections.Generic;

    public class FoodCartListinViewModel
    {
        public FoodCartListinViewModel(FoodCartViewModel food)
        {
            this.Food = new List<FoodCartViewModel>
            {
                food,
            };
        }

        public List<FoodCartViewModel> Food { get; }
    }
}
