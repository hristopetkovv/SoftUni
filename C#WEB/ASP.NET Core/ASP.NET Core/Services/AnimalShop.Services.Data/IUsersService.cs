namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;

    public interface IUsersService
    {
        IEnumerable<T> GetProducts<T>(string userId);

        int GetProductsCount(string userId);
    }
}
