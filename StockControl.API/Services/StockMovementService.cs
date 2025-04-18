using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using StockControl.API.DTOs;
using StockControl.API.Entities;
using StockControl.API.Repositories;

namespace StockControl.API.Services
{
    public class StockMovementService : IStockMovementService
    {

        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IMapper _mapper;

        public StockMovementService(IStockMovementRepository stockMovementRepository, IMapper mapper)
        {
            _stockMovementRepository = stockMovementRepository;
            _mapper = mapper;
        }

        public async Task<StockMovementDTO> CreateAsync(StockMovementDTO stockMovement)
        {
            var stockMovementEntity = _mapper.Map<StockMovement>(stockMovement);

            var createdStockMovement = await _stockMovementRepository.CreateAsync(stockMovementEntity);

            var result = _mapper.Map<StockMovementDTO>(createdStockMovement);
            return result;

        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            bool deleteStockMovement = await _stockMovementRepository.DeleteByIdAsync(id);

            return deleteStockMovement;
        }

        public async Task<StockMovementDTO> GetByIdAsync(int id)
        {
            var stockMovement = await _stockMovementRepository.GetByIdAsync(id);

            if (stockMovement == null)
                return null;

            var result = _mapper.Map<StockMovementDTO>(stockMovement);
            return result;
        }
    }
}
