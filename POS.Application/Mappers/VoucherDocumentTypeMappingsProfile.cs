using AutoMapper;
using POS.Application.Commons.Select.Response;
using POS.Domain.Entities;

namespace POS.Application.Mappers;

public class VoucherDocumentTypeMappingsProfile : Profile
{
    public VoucherDocumentTypeMappingsProfile()
    {
        CreateMap<VoucherDocumentType, SelectResponse>()
            .ReverseMap();
    }
}
