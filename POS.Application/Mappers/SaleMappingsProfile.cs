using AutoMapper;
using POS.Application.Dtos.Sale.Request;
using POS.Application.Dtos.Sale.Response;
using POS.Domain.Entities;

namespace POS.Application.Mappers
{
    public class SaleMappingsProfile : Profile
    {
        public SaleMappingsProfile()
        {
            CreateMap<Sale, SaleResponseDto>()
                .ForMember(x => x.SaleId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.VoucherDescription, x => x.MapFrom(y => y.VoucherDocumentType.Description))
                .ForMember(x => x.Client, x => x.MapFrom(y => y.Client.Name))
                .ForMember(x => x.Warehouse, x => x.MapFrom(y => y.Warehouse.Name))
                .ForMember(x => x.DateOfSale, x => x.MapFrom(y => y.AuditCreateDate))
                .ReverseMap();

            CreateMap<Sale, SaleByIdResponseDto>()
                .ForMember(x => x.SaleId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.DateOfSale, x => x.MapFrom(y => y.AuditCreateDate))
                .ReverseMap();

            CreateMap<SaleDetail, SaleDetailByIdResponseDto>()
                .ForMember(x => x.ProductId, x => x.MapFrom(y => y.ProductId))
                .ForMember(x => x.Image, x => x.MapFrom(y => y.Product.Image))
                .ForMember(x => x.Code, x => x.MapFrom(y => y.Product.Code))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Product.Name))
                .ForMember(x => x.TotalAmount, x => x.MapFrom(y => y.Total))
                .ReverseMap();

            CreateMap<Product, ProductStockByWarehouseIdResponseDto>()
                .ForMember(x => x.ProductId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Image, x => x.MapFrom(y => y.Image))
                .ForMember(x => x.Code, x => x.MapFrom(y => y.Code))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Category, x => x.MapFrom(y => y.Category.Name))
                .ForMember(x => x.UnitSalePrice, x => x.MapFrom(y => y.UnitSalePrice))
                .ForMember(x => x.CurrentStock, x => x.MapFrom(y => y.ProductStocks.Sum(x => x.CurrentStock)))
                .ReverseMap();

            CreateMap<SaleRequestDto, Sale>();

            CreateMap<SaleDetailRequestDto, SaleDetail>();
        }
    }
}
