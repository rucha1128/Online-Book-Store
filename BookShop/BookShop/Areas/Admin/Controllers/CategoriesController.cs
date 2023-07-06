using BookShop.DataAccess;
using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _uow;
        public CategoriesController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            List<Categories> objCategory = _uow.Category.GetAll().ToList();
            return View(objCategory);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Categories cat)
        {
            if (ModelState.IsValid)
            {
                _uow.Category.Add(cat);
                _uow.Save();
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
            var categoryFromDb = _uow.Category.GetFirstOrDefault(u => u.id == id);
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Categories cat)
        {
            if (ModelState.IsValid)
            {
                _uow.Category.update(cat);
                _uow.Save();
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
            var categoryFromDb = _uow.Category.GetFirstOrDefault(u => u.id == id);
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Delete(Categories cat)
        {
            _uow.Category.Remove(cat);
            _uow.Save();
            TempData["success"] = "Category Deleted Successfully !";
            return RedirectToAction("Index");
        }
    }
}
