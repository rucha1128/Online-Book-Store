using System.ComponentModel;

namespace BookShop.Models
{
    public class Categories
    {
        public int id { get; set; }
        public string Name { get; set; }
        [DisplayName("Orders")]
        public int DisplayOrder { get; set; }
    }
}
