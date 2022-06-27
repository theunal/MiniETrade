
using Domain.Entities;

namespace Application.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
    }
}
