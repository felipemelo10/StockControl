using AutoMapper;
using StockControl.API.DTOs;
using StockControl.API.Entities;

namespace StockControl.API.Mappings
{
    public class StockMovementMappingProfile : Profile
    {   
        public StockMovementMappingProfile(){
            CreateMap<StockMovement, StockMovementDTO>()
                .ReverseMap()
                .ForMember(st => st.Product, st => st.Ignore());
        }
    }
}