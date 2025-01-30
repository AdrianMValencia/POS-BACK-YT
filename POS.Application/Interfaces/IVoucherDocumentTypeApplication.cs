using POS.Application.Commons.Bases.Response;
using POS.Application.Commons.Select.Response;

namespace POS.Application.Interfaces;

public interface IVoucherDocumentTypeApplication
{
    Task<BaseResponse<IEnumerable<SelectResponse>>> ListSelectVoucherDocumentTypes();
}
