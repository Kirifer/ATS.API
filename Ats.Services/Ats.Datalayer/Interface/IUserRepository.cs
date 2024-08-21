using Ats.Datalayer.Entities;

namespace Ats.Datalayer.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);

        Task<User?> GetByUserNamePasswordAsync(string? username, string? password);
    }
}
