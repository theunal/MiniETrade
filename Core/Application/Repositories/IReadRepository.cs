using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true);


        // bu ikisini değiştircem. bir metod şeklinde sadece get yapıcam
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetByIdAsync(Guid id, bool tracking = true);


      //  Task<T> GetAsync(Expression<Func<T, bool>> filter);
    }
}
