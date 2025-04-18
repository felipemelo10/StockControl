
using Microsoft.EntityFrameworkCore;
using StockControl.API.Entities;
using StockControl.API.Persistence;

namespace StockControl.API.Repositories
{
    public class StockMovementRepository : IStockMovementRepository
    {
        private readonly StockControlContext _stockControlContext;

        public StockMovementRepository(StockControlContext stockControlContext)
        {
            _stockControlContext = stockControlContext;
        }
        public async Task<StockMovement> CreateAsync(StockMovement stockMovement)
        {
            _stockControlContext.StockMovements.Add(stockMovement);
            await _stockControlContext.SaveChangesAsync();
            return stockMovement;

        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var stockMovementToDelete = await _stockControlContext.StockMovements.FindAsync(id);

            if (stockMovementToDelete == null)
                return false;
            
            _stockControlContext.StockMovements.Remove(stockMovementToDelete);

            int affectedStockMovement = await _stockControlContext.SaveChangesAsync();
            return affectedStockMovement > 0;
            
        }

        public async Task<StockMovement> GetByIdAsync(int id)
        {
            return await _stockControlContext.StockMovements.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
