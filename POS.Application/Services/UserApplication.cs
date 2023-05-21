using AutoMapper;
using Microsoft.Extensions.Configuration;
using POS.Application.Commons.Bases;
using POS.Application.Dtos.User.Request;
using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Utilities.Static;
using BC = BCrypt.Net.BCrypt;

namespace POS.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var account = _mapper.Map<User>(requestDto);
            account.Password = BC.HashPassword(account.Password);

            if (requestDto.Image is not null)
            {
                account.Image = await _unitOfWork.Storage.SaveFile(AzureContainers.USERS, requestDto.Image);
            }

            response.Data = await _unitOfWork.User.RegisterAsync(account);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }
    }
}