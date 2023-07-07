using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }
        
        public string Title { get; set; }
        
        public string Author { get; set; }
        public string Description { get; set; }
        
        public string ISBN { get; set; }
        
        [Display(Name = "List Price")]
        public int ListPrice { get; set; }
        
        [Range(0, 1000)]
        [Display(Name = "Price for 1-50")]
        public int Price { get; set; }
        
        [Range(0, 1000)]
        [Display(Name = "Price for 50+")]
        public int Price50 { get; set; }
        
        [Range(0, 1000)]
        [Display(Name = "Price for 100+")]
        public int Price100 { get; set; }

    }
}
