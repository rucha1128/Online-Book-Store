using BookShop.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _context = db;
            Category = new CategoryRepository(db);
        }
        
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
