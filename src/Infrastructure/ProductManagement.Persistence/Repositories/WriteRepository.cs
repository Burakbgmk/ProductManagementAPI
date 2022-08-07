using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Domain.Common;
using ProductManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext context;

        public WriteRepository(AppDbContext context)
        {
            this.context = context;
        }
        public DbSet<TEntity> dbSet => context.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }
        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return entities;
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(List<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<int> CommitAsync() => await context.SaveChangesAsync();
    }
}
