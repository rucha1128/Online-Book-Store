using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookShop_Razor.Models
{
    public class Categories
    {
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Orders")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}
