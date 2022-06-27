using Application.Repositories;
using Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly DataContext context;
        public ReadRepository(DataContext context)
        {
            this.context = context;
        }



        public DbSet<T> Table => context.Set<T>();

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? Table : Table.Where(filter);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await Table.Where(filter).SingleOrDefaultAsync();
        }

      
    }
}
