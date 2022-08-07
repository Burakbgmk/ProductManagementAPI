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
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext context;

        public ReadRepository(AppDbContext context)
        {
            this.context = context;
        }
        public DbSet<T> dbSet => context.Set<T>();

        public IQueryable<T> GetAll(bool isTracking = false)
        {
            var querry = dbSet.AsQueryable();
            if (isTracking)
                return querry;
            return querry.AsNoTracking();
        }

        public async Task<T> GetByIdAsync(Guid id, bool isTracking = false)
        {
            if (isTracking)
                return await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
