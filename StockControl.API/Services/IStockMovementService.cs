using StockControl.API.DTOs;
using StockControl.API.Entities;

namespace StockControl.API.Services
{
    public interface IStockMovementService
    {
        Task<StockMovementDTO> GetByIdAsync(int id);
        Task<StockMovementDTO> CreateAsync(StockMovementDTO stockMovement);
        Task<bool> DeleteByIdAsync(int id);
    }
}
