using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Domain.Entities;
using ProductManagement.Persistence.Context;

namespace ProductManagement.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository 
    {
        public ProductReadRepository(AppDbContext context) : base(context)
        {

        }
    }
}
