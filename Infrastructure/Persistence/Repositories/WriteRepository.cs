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



        // add
        public async Task<bool> AddAsync(T entity) // ekleme başarılı ise true döner
            => (await Table.AddAsync(entity)).State is EntityState.Added;

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }



        // delete
        // silme başarılı ise true döner
        public bool Remove(T entity) => Table.Remove(entity).State is EntityState.Deleted;

        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
            => Remove(await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id)));
        



        // update
        public bool Update(T entity) => Table.Update(entity).State is EntityState.Modified;



        // save changes
        public async Task<int> SaveAsync()
            => await context.SaveChangesAsync();
    }
}
