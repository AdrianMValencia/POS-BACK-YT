using AutoMapper;
using POS.Application.Dtos.Purcharse.Request;
using POS.Application.Dtos.Purcharse.Response;
using POS.Domain.Entities;

namespace POS.Application.Mappers
{
    public class PurcharseMappingsProfile : Profile
    {
        public PurcharseMappingsProfile()
        {
            CreateMap<Purcharse, PurcharseResponseDto>()
                .ForMember(x => x.PurcharseId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Provider, x => x.MapFrom(y => y.Provider!.Name))
                .ForMember(x => x.Warehouse, x => x.MapFrom(y => y.Warehouse.Name))
                .ForMember(x => x.DateOfPurcharse, x => x.MapFrom(y => y.AuditCreateDate))
                .ReverseMap();

            CreateMap<Purcharse, PurcharseByIdResponseDto>()
                 .ForMember(x => x.PurcharseId, x => x.MapFrom(y => y.Id))
                 .ReverseMap();

            CreateMap<PurcharseDetail, PurcharseDetailByIdResponseDto>()
                .ForMember(x => x.ProductId, x => x.MapFrom(y => y.ProductId))
                .ForMember(x => x.Image, x => x.MapFrom(y => y.Product.Image))
                .ForMember(x => x.Code, x => x.MapFrom(y => y.Product.Code))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Product.Name))
                .ForMember(x => x.TotalAmount, x => x.MapFrom(y => y.Total))
                .ReverseMap();

            CreateMap<PurcharseRequestDto, Purcharse>();
            CreateMap<PurcharseDetailRequestDto, PurcharseDetail>();
        }
    }
}