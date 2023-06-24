using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
                new Categories { id = 1, Name = "History", DisplayOrder = 1},
                new Categories { id = 2, Name = "Literature", DisplayOrder = 2 },
                new Categories { id = 3, Name = "Novel", DisplayOrder = 3 }
                );
        }
    }
}
