using BookShop.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using BookShop.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookShop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Products> products = _unitOfWork.Products.GetAll().ToList();
            return View(products);
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Products products)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Products.Add(products);
                _unitOfWork.Save();
            }
            TempData["success"] = "Product Created Successfully !";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ProductFromDB = _unitOfWork.Products.GetFirstOrDefault(u => u.id == id);
            return View(ProductFromDB);
        }
        [HttpPost]
        public IActionResult Edit(Products products)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Products.update(products);
                _unitOfWork.Save();
            }
            TempData["success"] = "Product Updated Successfully !";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            var ProductFromDB = _unitOfWork.Products.GetFirstOrDefault(u => u.id == id);
            return View(ProductFromDB);
        }
        [HttpPost]
        public IActionResult Delete(Products products)
        {
            _unitOfWork.Products.Remove(products);
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted Successfully !";
            return RedirectToAction("Index");
        }
    }
}
