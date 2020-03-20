namespace AnimalShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DogsController : Controller
    {
        public IActionResult Food()
        {
            return this.View();
        }
    }
}
