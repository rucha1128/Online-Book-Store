using BookShop.Data;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Categories> objCategory = _db.Categories.ToList();
            return View(objCategory);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
    }
}
