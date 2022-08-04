using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        public DbSet<T> dbSet { get; }
    }
}
