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


        /* bu iki metodu teke düşürücem */
        public IQueryable<T> GetAll(bool tracking = true)
            => tracking ? Table : Table.AsNoTracking();


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true)
            => tracking ?
            Table.Where(filter) :
            Table.Where(filter).AsNoTracking();



        /* bu iki metodu teke düşürücem */
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true)
            => tracking ?
            await Table.FirstOrDefaultAsync(filter) :
            await Table.AsQueryable().AsNoTracking().FirstOrDefaultAsync(filter);

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
          => tracking ?
            await Table.FindAsync(Guid.Parse(id)) :
            await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
    }
}
