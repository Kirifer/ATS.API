using Ats.Datalayer.Entities;

namespace Ats.Datalayer.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);

        Task<User?> GetByUsernameAsync(string username);

        Task<User?> GetByUsernamePasswordAsync(string? username, string? password);
    }
}
