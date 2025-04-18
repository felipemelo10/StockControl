using StockControl.API.DTOs;
using StockControl.API.Entities;

namespace StockControl.API.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<bool> DeleteByIdAsync(int id);
        
    }
}
