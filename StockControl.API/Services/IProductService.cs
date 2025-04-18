using StockControl.API.DTOs;
using StockControl.API.Entities;

namespace StockControl.API.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAll();
        Task<ProductDTO?> GetByIdAsync(int id);
        Task<AddProductDTO> CreateAsync(AddProductDTO product);
        Task<bool> DeleteByIdAsync(int id);
    }
}