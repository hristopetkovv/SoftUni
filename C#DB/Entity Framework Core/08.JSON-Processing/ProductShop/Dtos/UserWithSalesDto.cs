using System.Collections.Generic;

namespace ProductShop.Dtos
{
    public class UserWithSalesDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<ProductDto> SoldProducts { get; set; } = new List<ProductDto>();
    }
}
