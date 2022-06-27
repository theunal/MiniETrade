using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly DataContext context;
        public WriteRepository(DataContext context)
        {
            this.context = context;
        }

        public DbSet<T> Table => context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            var result = await Table.AddAsync(entity);
            return result.State == EntityState.Added;
        }

        public async Task<bool> AddAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Delete(T entity)
        {
            var result = Table.Remove(entity);
            return result.State == EntityState.Deleted;
        }
        public bool Delete(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return Delete(await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id)));
        }

        public bool Update(T entity)
        {
            var result = Table.Update(entity);
            return result.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
            => await context.SaveChangesAsync();

   
    }
}
