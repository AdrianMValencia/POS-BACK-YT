using POS.Application.Commons.Bases.Response;
using POS.Application.Dtos.User.Request;

namespace POS.Application.Interfaces
{
    public interface IAuthApplication
    {
        Task<BaseResponse<string>> Login(TokenRequestDto requestDto, string authType);
        Task<BaseResponse<string>> LoginWithGoogle(string credentials, string authType);
    }
}