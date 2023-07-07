using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
    internal class ProductsRepository : Repository<Products>, IProductsRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void update(Products Product)
        {
            _db.Update(Product);
        }
    }
}
