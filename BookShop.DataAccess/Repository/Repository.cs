using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookShop.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;
        public Repository(ApplicationDbContext db) 
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public void RemoveRange(T item)
        {
            _dbSet.RemoveRange(item);
        }
    }
}
