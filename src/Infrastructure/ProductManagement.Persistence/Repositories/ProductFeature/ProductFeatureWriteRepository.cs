using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Domain.Entities;
using ProductManagement.Persistence.Context;

namespace ProductManagement.Persistence.Repositories
{
    public class ProductFeatureWriteRepository : WriteRepository<ProductFeature>, IProductFeatureWriteRepository
    {
        public ProductFeatureWriteRepository(AppDbContext context) : base(context)
        {

        }
    }
}
