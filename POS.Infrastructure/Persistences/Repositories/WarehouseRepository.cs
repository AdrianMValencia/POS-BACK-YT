using POS.Domain.Entities;
using POS.Infrastructure.Persistences.Contexts;
using POS.Infrastructure.Persistences.Interfaces;

namespace POS.Infrastructure.Persistences.Repositories
{
    public class WarehouseRepository: GenericRepository<Warehouse>, IWarehouseRepository
    {
        private readonly POSContext _context;
        public WarehouseRepository(POSContext context) : base(context)
        {
            _context = context;
        }
    }
}