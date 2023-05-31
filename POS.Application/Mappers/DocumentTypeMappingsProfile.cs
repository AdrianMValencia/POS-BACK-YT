using AutoMapper;
using POS.Application.Dtos.DocumentType.Response;
using POS.Domain.Entities;

namespace POS.Application.Mappers
{
    public class DocumentTypeMappingsProfile : Profile
    {
        public DocumentTypeMappingsProfile()
        {
            CreateMap<DocumentType, DocumentTypeResponseDto>()
                .ReverseMap();
        }
    }
}
