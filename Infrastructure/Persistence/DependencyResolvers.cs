using Microsoft.EntityFrameworkCore;
using Application.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Concrete;
using Persistence.Context;

namespace Persistence
{
    public static class DependencyResolvers
    {
        // persistence için dependency resolvers 
        // autofac kullanmadım
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
            services.AddDbContext<DataContext>(p =>
            p.UseNpgsql("User ID=postgres;Password=12345;Host=localhost;" +
            "Port=5432;Database=MiniETrade;"));
        }
    }
}
