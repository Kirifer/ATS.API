﻿using System.Linq.Expressions;

using Ats.Core.Database.Abstraction;
using Ats.Datalayer.Interface;
using Ats.Shared.Enums;
using Ats.Shared.Exceptions;

using Microsoft.EntityFrameworkCore;

namespace Ats.Datalayer.Implementation
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : DbEntityIdBase
    {
        protected readonly AtsDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(AtsDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = (await DbSet.AddAsync(entity)).Entity;
            await Context.SaveChangesAsync();

            return addedEntity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var removedEntity = DbSet.Remove(entity).Entity;
            await Context.SaveChangesAsync();

            return removedEntity;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            var entity = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) { throw new DatabaseAccessException(DbErrorCode.NotFound, $"Record is not found using the id: {id}"); }

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();

            return entity;
        }
    }
}
