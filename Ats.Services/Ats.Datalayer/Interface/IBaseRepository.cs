﻿using System.Linq.Expressions;

using Ats.Core.Database.Abstraction;

namespace Ats.Datalayer.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : DbEntityIdBase
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(Guid id);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);
    }
}
