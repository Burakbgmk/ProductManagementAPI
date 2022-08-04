using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Domain.Entities;
using ProductManagement.Persistence.Context;

namespace ProductManagement.Persistence.Repositories
{
    public class ProductFeatureReadRepository : ReadRepository<ProductFeature>, IProductFeatureReadRepository
    {
        public ProductFeatureReadRepository(AppDbContext context) : base(context)
        {

        }
    }
}
