
using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Datalayer;
using Ats.Domain.Services.Interface;
using Ats.Models;

using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ats.Domain.Services
{
    public class UserService: EntityService, IUserService
    {
        public UserService(
            AtsDbContext dbContext,
            IMapper mapper,
            ILogger<UserService> logger
            
            ) : base(dbContext, mapper, logger)
        {

        }

        public Task<Response<AtsUserDto>> CreateUserAsync(AtsUserCreateDto user)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AtsUserDto>> DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AtsUserDto>> GetUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<AtsUserDto>>> GetUsersAsync(AtsUserFilterDto filter)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AtsUserDto>> UpdateUserAsync(Guid id, AtsUserUpdateDto user)
        {
            throw new NotImplementedException();
        }
    }
}
