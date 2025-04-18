using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControl.API.Entities;
using StockControl.API.Persistence;

namespace StockControl.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StockControlContext _stockControlContext;
        public ProductRepository(StockControlContext stockControlContext)
        {
            _stockControlContext = stockControlContext;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            _stockControlContext.Products.Add(product);
            await _stockControlContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var productDeleteByIdAsync = await _stockControlContext.Products.FindAsync(id);
            
            if(productDeleteByIdAsync == null)
                return false;
            
            _stockControlContext.Products.Remove(productDeleteByIdAsync);

            int affectedProduct = await _stockControlContext.SaveChangesAsync();
            return affectedProduct > 0;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _stockControlContext.Products
                .Include(sm => sm.StockMovements)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _stockControlContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
