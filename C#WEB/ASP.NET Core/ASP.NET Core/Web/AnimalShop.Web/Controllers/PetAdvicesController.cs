namespace AnimalShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PetAdvicesController : Controller
    {
        public IActionResult Dog()
        {
            return this.View();
        }

        public IActionResult Cat()
        {
            return this.View();
        }

        public IActionResult Bird()
        {
            return this.View();
        }

        public IActionResult Fish()
        {
            return this.View();
        }

        public IActionResult SmallPet()
        {
            return this.View();
        }
    }
}
