using Microsoft.Extensions.Configuration;
using POS.Infrastructure.FileStorage;
using POS.Infrastructure.Persistences.Contexts;
using POS.Infrastructure.Persistences.Interfaces;

namespace POS.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly POSContext _context;
        public ICategoryRepository Category { get; private set; }
        public IUserRepository User { get; private set; }
        public IAzureStorage Storage { get; private set; }
        public IProviderRepository Provider { get; private set; }
        public IDocumentTypeRepository DocumentType { get; private set; }

        public UnitOfWork(POSContext context, IConfiguration configuration)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            User = new UserRepository(_context);
            Storage = new AzureStorage(configuration);
            Provider = new ProviderRepository(_context);
            DocumentType = new DocumentTypeRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}