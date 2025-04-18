using AutoMapper;
using StockControl.API.DTOs;
using StockControl.API.Entities;
using StockControl.API.Repositories;

namespace StockControl.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<AddProductDTO> CreateAsync(AddProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            
            var CreateAsyncdEntity = await _productRepository.CreateAsync(productEntity);

            var resultProductDTO = _mapper.Map<AddProductDTO>(CreateAsyncdEntity);
            return resultProductDTO;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            bool DeleteByIdAsyncdProduct = await _productRepository.DeleteByIdAsync(id);
            return DeleteByIdAsyncdProduct;
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            var productEntities = await _productRepository.GetAll();

            var productDTOs = _mapper.Map<List<ProductDTO>>(productEntities);
            return productDTOs;
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);

            if(productEntity == null)
                return null;

            var productDTO = _mapper.Map<ProductDTO>(productEntity);
            return productDTO;
        }

    }
}