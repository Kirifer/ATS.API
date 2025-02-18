﻿using AutoMapper;

using Microsoft.Extensions.Logging;

namespace Ats.Core.Abstraction
{
    public class EntityService(
        IMapper mapper,
        ILogger<EntityService> logger) : IEntityService
    {
        protected IMapper Mapper { get; } = mapper;
        protected ILogger<EntityService> Logger { get; } = logger;
    }
}
