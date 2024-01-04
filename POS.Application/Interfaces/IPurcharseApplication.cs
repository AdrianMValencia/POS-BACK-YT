using POS.Application.Commons.Bases.Request;
using POS.Application.Commons.Bases.Response;
using POS.Application.Dtos.Purcharse.Request;
using POS.Application.Dtos.Purcharse.Response;

namespace POS.Application.Interfaces
{
    public interface IPurcharseApplication
    {
        Task<BaseResponse<IEnumerable<PurcharseResponseDto>>>
            ListPurcharses(BaseFiltersRequest filters);

        Task<BaseResponse<PurcharseByIdResponseDto>> PurcharseById(int purcharseId);
        Task<BaseResponse<bool>> RegisterPurcharse(PurcharseRequestDto requestDto);
        Task<BaseResponse<bool>> CancelPurcharse(int purcharseId);
    }
}