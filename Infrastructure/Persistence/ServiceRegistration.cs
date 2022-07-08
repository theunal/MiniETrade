using Microsoft.Extensions.DependencyInjection;
using Application.Repositories.CustomerRepositories;
using Persistence.Repositories.CustomerRepositories;
using Application.Repositories.OrderRepositories;
using Persistence.Repositories.OrderRepositories;
using Persistence.Repositories.ProductRepositories;
using Application.Repositories.ProductRepositories;
using Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Identity;
using Application.Utilities.Security.JWT;

namespace Persistence
{
    public static class ServiceRegistration
    {
        // persistence için dependency resolvers 
        // autofac kullanmadım
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<ITokenHandler, TokenHandler>();

            // db
            services.AddDbContext<DataContext>(p =>
            p.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database=MiniETrade;
            integrated security=true"));


            // identity
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<DataContext>();
        }
    }
}
