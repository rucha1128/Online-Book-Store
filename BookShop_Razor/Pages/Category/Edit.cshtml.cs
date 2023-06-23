using BookShop_Razor.Data;
using BookShop_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop_Razor.Pages.Category
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Categories CategoryList { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                CategoryList = _db.categories.FirstOrDefault(u => u.id == id);
            }
            
        }
        public IActionResult OnPost() 
        { 
            if (CategoryList == null)
            {
                return Page();
            }
            _db.categories.Update(CategoryList);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
