using BookShop.Models;


namespace BookShop.DataAccess.Repository.IRepository
{
    public interface IProductsRepository : IRepository<Products>
    {
        void update(Products Product);
    }
}
