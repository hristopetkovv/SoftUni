namespace AnimalShop.Web.ViewModels.ProductsInCart
{
    using System.Collections.Generic;

    public class ProductCartListingViewModel
    {
        public int Count { get; set; }

        public IEnumerable<ProductCartViewModel> Products { get; set; }
    }
}
