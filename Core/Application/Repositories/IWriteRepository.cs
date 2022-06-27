
using Domain.Entities;

namespace Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddAsync(List<T> entities);

        bool Delete(T entity);
        bool Delete(List<T> entities);
        Task<bool> DeleteAsync(string id);

        bool Update(T entity);

        Task<int> SaveAsync();
    }
}
