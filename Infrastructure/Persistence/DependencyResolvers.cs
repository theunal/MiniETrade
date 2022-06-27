using Application.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Concrete;

namespace Persistence
{
    public static class DependencyResolvers
    {
        // persistence için dependency resolvers 
        // autofac kullanmadım
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
