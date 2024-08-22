using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Shared;

namespace Ats.Domain.Services.Interface
{
    public interface IAccountService : IEntityService
    {
        Task<Response<AuthUserIdentityDto>> GetIdentityAsync();

        Task<Response<AuthLoginDto>> LoginAsync(AuthLoginRequestDto loginRequest);

        Task<Response<AuthIdentityResultDto>> LogoutAsync();

        Task<Response<AuthRegisterResponseDto>> RegisterAsync(AuthRegisterRequestDto registerRequest);
    }
}
