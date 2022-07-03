using Application.Repositories.CustomerRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.CustomerRepositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(DataContext context) : base(context)
        {
        }
    }
}
