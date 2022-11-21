using AutoMapper;
using POS.Application.Dtos.User.Request;
using POS.Domain.Entities;

namespace POS.Application.Mappers
{
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
            CreateMap<UserRequestDto, User>();
            CreateMap<TokenRequestDto, User>();
        }
    }
}