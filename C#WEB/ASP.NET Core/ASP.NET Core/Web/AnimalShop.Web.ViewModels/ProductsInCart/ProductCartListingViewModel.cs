namespace AnimalShop.Web.ViewModels.ProductsInCart
{
    using System.Collections.Generic;

    public class ProductCartListingViewModel
    {
        public IEnumerable<ProductCartViewModel> Products { get; set; }
    }
}
