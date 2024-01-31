using POS.Application.Commons.Bases.Request;
using POS.Application.Commons.Bases.Response;
using POS.Application.Commons.Select.Response;
using POS.Application.Dtos.Client.Request;
using POS.Application.Dtos.Client.Response;

namespace POS.Application.Interfaces
{
    public interface IClientApplication
    {
        Task<BaseResponse<IEnumerable<ClientResponseDto>>> ListClient(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<SelectResponse>>> ListSelectClients();
        Task<BaseResponse<ClientByIdResponseDto>> ClientById(int clientId);
        Task<BaseResponse<bool>> RegisterClient(ClientRequestDto requestDto);
        Task<BaseResponse<bool>> EditClient(int clientId, ClientRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveClient(int clientId);
    }
}
