using BookShop_Razor.Data;
using BookShop_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop_Razor.Pages.Category
{
    public class AddCategoryModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Categories Category { get; set; }
        public AddCategoryModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.categories.Add(Category);
                _db.SaveChanges();
            }
            TempData["success"] = "Category created successfully !";
            return RedirectToPage("Index");
        }
    }
}
