using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IProviderRepository: IGenericRepository<Provider>
    {
        Task<BaseEntityResponse<Provider>> ListProviders(BaseFiltersRequest filters);
    }
}