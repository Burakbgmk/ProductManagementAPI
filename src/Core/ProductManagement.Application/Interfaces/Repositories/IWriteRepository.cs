using ProductManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Interfaces.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entities);
        Task<int> CommitAsync();
    }
}
