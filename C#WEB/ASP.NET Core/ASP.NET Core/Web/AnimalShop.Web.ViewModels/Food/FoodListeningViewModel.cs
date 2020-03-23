namespace AnimalShop.Web.ViewModels.Food
{
    using System.Collections.Generic;

    public class FoodListeningViewModel
    {
        public int Count { get; set; }

        public IEnumerable<FoodViewModel> Food { get; set; }
    }
}
