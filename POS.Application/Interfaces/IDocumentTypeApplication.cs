using POS.Application.Commons.Bases.Response;
using POS.Application.Dtos.DocumentType.Response;

namespace POS.Application.Interfaces
{
    public interface IDocumentTypeApplication
    {
        Task<BaseResponse<IEnumerable<DocumentTypeResponseDto>>> ListDocumentTypes();
    }
}
