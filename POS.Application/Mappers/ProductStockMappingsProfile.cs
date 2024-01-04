using AutoMapper;
using POS.Application.Dtos.ProductStock;
using POS.Domain.Entities;

namespace POS.Application.Mappers
{
    public class ProductStockMappingsProfile : Profile
    {
        public ProductStockMappingsProfile()
        {
            CreateMap<ProductStock, ProductStockByWarehouseResponseDto>()
                .ForMember(x => x.Warehouse, x => x.MapFrom(y => y.Warehouse.Name))
                .ForMember(x => x.CurrentStock, x => x.MapFrom(y => y.CurrentStock))
                .ForMember(x => x.PurchasePrice, x => x.MapFrom(y => y.PurchasePrice))
                .ReverseMap();
        }
    }
}