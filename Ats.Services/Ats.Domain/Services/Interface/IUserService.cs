using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Models;

namespace Ats.Domain.Services.Interface
{
    public interface IUserService : IEntityService
    {
        Task<Response<List<AtsUserDto>>> GetUsersAsync(AtsUserFilterDto filter);

        Task<Response<AtsUserDto>> GetUserAsync(Guid id);

        Task<Response<AtsUserDto>> CreateUserAsync(AtsJobListCreateDto user);

        Task<Response<AtsUserDto>> UpdateUserAsync(Guid id, AtsUserUpdateDto user);

        Task<Response<AtsUserDto>> DeleteUserAsync(Guid id);
    }
}
