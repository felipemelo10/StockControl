using AutoMapper;
using StockControl.API.DTOs;
using StockControl.API.Entities;

namespace StockControl.API.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, AddProductDTO>().ReverseMap();
        }
    }
}