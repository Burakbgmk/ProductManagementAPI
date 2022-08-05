using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Persistence.Context;
using ProductManagement.Persistence.Repositories;

namespace ProductManagement.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPeristanceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));
            serviceCollection.AddTransient<IProductReadRepository, ProductReadRepository>();
            serviceCollection.AddTransient<IProductWriteRepository, ProductWriteRepository>();
            serviceCollection.AddTransient<ICategoryReadRepository, CategoryReadRepository>();
            serviceCollection.AddTransient<ICategoryWriteRepository, CategoryWriteRepository>();
        }
    }
}
