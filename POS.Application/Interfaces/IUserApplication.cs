using POS.Application.Commons.Bases.Response;
using POS.Application.Dtos.User.Request;

namespace POS.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto);
    }
}