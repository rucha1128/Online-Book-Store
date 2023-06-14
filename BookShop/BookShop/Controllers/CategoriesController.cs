using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return this.View();
        }
    }
}
