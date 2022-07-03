using Application.Repositories.OrderRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.OrderRepositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(DataContext context) : base(context)
        {
        }
    }
}
