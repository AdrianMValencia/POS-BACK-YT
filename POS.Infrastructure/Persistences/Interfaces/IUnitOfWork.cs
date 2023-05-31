using POS.Infrastructure.FileStorage;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Declaración o matricula de nuestra interfaces a nivel de repository
        ICategoryRepository Category { get; }
        IUserRepository User { get; }
        IAzureStorage Storage { get; }
        IProviderRepository Provider { get; }
        IDocumentTypeRepository DocumentType { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}