using BookShop_Razor.Data;
using BookShop_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop_Razor.Pages.Category
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Categories categoryList { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null || id != 0 )
            {
                categoryList = _db.categories.FirstOrDefault(u => u.id == id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.categories.Remove(categoryList);
                _db.SaveChanges();
            }
            TempData["success"] = "Category deleted successfully !";
            return RedirectToPage("Index");
        }
    }
}
