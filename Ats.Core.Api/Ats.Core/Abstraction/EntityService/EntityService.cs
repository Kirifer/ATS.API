using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ats.Core.Abstraction
{
    public class EntityService(
        DbContext dbContext,
        IMapper mapper,
        ILogger<EntityService> logger) : IEntityService
    {
        protected DbContext DbContext { get; } = dbContext;
        protected IMapper Mapper { get; } = mapper;
        protected ILogger<EntityService> Logger { get; } = logger;
    }
}
