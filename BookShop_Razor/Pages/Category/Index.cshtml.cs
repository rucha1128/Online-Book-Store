using BookShop_Razor.Data;
using Microsoft.AspNetCore.Mvc;
using BookShop_Razor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop_Razor.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public List<Categories> CategoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.categories.ToList();
        }
    }
}
