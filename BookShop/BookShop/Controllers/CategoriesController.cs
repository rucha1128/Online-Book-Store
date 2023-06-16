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
        [HttpPost]
        public IActionResult AddCategory(Categories cat)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(cat);
                _db.SaveChanges();
            }
            TempData["success"] = "Category Created Successfully !";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.FirstOrDefault(u => u.id == id);
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Categories cat)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(cat);
                _db.SaveChanges();
            }
            TempData["success"] = "Category Updated Successfully !";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.FirstOrDefault(u => u.id == id);
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Delete(Categories cat)
        {
                _db.Categories.Remove(cat);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully !";
            return RedirectToAction("Index");
        }
    }
}
