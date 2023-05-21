using POS.Domain.Entities;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> UserByEmail(string email);
    }
}