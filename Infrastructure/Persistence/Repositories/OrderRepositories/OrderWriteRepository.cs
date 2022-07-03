using Application.Repositories.OrderRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.OrderRepositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(DataContext context) : base(context)
        {
        }
    }
}
