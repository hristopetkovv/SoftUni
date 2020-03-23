namespace AnimalShop.Web.ViewModels.Toys
{
    using System.Collections.Generic;

    public class ToysListingViewModel
    {
        public int Count { get; set; }

        public IEnumerable<ToysViewModel> Toys { get; set; }
    }
}
