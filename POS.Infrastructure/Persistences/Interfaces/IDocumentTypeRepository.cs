using POS.Domain.Entities;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IDocumentTypeRepository
    {
        Task<IEnumerable<DocumentType>> ListDocumentTypes();
    }
}