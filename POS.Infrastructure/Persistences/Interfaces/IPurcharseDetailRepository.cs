using POS.Domain.Entities;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IPurcharseDetailRepository
    {
        Task<IEnumerable<PurcharseDetail>> 
            GetPurcharseDetailByPurcharseId(int purcharseId);
    }
}
