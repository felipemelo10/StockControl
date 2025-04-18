using StockControl.API.Entities;

namespace StockControl.API.Repositories
{
    public interface IStockMovementRepository
    {
        Task<StockMovement> GetByIdAsync(int id);
        Task<StockMovement> CreateAsync(StockMovement stockMovement);
        Task<bool> DeleteByIdAsync(int id);
    }
}
