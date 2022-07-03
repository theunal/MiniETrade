using Application.Repositories.CustomerRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.CustomerRepositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(DataContext context) : base(context)
        {
        }
    }
}
