using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Categories
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Orders")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}
