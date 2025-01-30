using AutoMapper;
using POS.Application.Commons.Bases.Response;
using POS.Application.Commons.Select.Response;
using POS.Application.Interfaces;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Utilities.Static;
using WatchDog;

namespace POS.Application.Services;

public class VoucherDocumentTypeApplication : IVoucherDocumentTypeApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VoucherDocumentTypeApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<IEnumerable<SelectResponse>>> ListSelectVoucherDocumentTypes()
    {
        var response = new BaseResponse<IEnumerable<SelectResponse>>();

        try
        {
            var voucherDocumentTypes = await _unitOfWork.VoucherDocumentType.GetSelectAsync();

            if (voucherDocumentTypes is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.IsSuccess = true;
            response.Data = _mapper.Map<IEnumerable<SelectResponse>>(voucherDocumentTypes);
            response.Message = ReplyMessage.MESSAGE_QUERY;
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_EXCEPTION;
            WatchLogger.Log(ex.Message);
        }
        
        return response;
    }
}
