using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiseRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiseRegistration));
        }
    }
}
